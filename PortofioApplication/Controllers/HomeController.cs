using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using PortofioApplication.Models;
using PortofioApplication.Models.ViewModels;
using System.Net.Http;
using PortofioApplication.Services;

namespace PortofioApplication.Controllers
{
    public class HomeController : Controller
    {
        private readonly EmailService _email;

        public HomeController(EmailService email)
        {
            _email = email;
        }
        public async Task<IActionResult> Index()
        {
            HttpClient client = new HttpClient();

            var profileRes = await client.GetStringAsync($"{Request.Scheme}://{Request.Host}/api/portfolioapi/profile");

            var skillsRes = await client.GetStringAsync($"{Request.Scheme}://{Request.Host}/api/portfolioapi/skills");

            var expRes = await client.GetStringAsync($"{Request.Scheme}://{Request.Host}/api/portfolioapi/experience");

            var projRes = await client.GetStringAsync($"{Request.Scheme}://{Request.Host}/api/portfolioapi/projects");


            var vm = new PortfolioViewModel
            {
                Profiles = JsonConvert.DeserializeObject<List<Profile>>(profileRes),
                Skills = JsonConvert.DeserializeObject<List<Skill>>(skillsRes),
                Experiences = JsonConvert.DeserializeObject<List<Experience>>(expRes),
                Projects = JsonConvert.DeserializeObject<List<Project>>(projRes)
            };

            return View(vm);
        }

        [HttpPost]
        public async Task<IActionResult> Contact(ContactMessage msg)
        {
            HttpClient client = new HttpClient();

            // Save to DB via API
            await client.PostAsJsonAsync(
    $"{Request.Scheme}://{Request.Host}/api/portfolioapi/contact",
    msg
);


            // MAIL TO YOU
            _email.Send(
                "vilasmanig@gmail.com",
                "New Portfolio Contact",
                $"Name: {msg.Name}<br>Email: {msg.Email}<br><br>{msg.Message}"
            );

            // CONFIRMATION MAIL TO USER
            _email.Send(
                msg.Email!,
                "Thanks for contacting me",
                $"Hi {msg.Name},<br><br>I received your message:<br><br>{msg.Message}<br><br>I will get back to you soon.<br><br>Regards,<br>Pranesh"
            );

            return RedirectToAction("Index");
        }


    }
}
