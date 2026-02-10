using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.Sqlite;
using PortofioApplication.Models;
using PortofioApplication.Services;

namespace PortofioApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PortfolioApiController : ControllerBase
    {
        private readonly IConfiguration _config;

        public PortfolioApiController(IConfiguration config)
        {
            _config = config;
        }

        private SqliteConnection GetConnection()
        {
            return new SqliteConnection("Data Source=portfolio.db");
        }

        // ================= PROFILE =================
        [HttpGet("profile")]
        public IActionResult GetProfile()
        {
            List<Profile> list = new();
            using SqliteConnection con = GetConnection();
            SqliteCommand cmd = new("SELECT * FROM Profile", con);
            con.Open();
            SqliteDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                list.Add(new Profile
                {
                    Id = Convert.ToInt32(dr["Id"]),
                    Name = dr["Name"].ToString(),
                    Title = dr["Title"].ToString(),
                    Summary = dr["Summary"].ToString(),
                    Email = dr["Email"].ToString(),
                    Phone = dr["Phone"].ToString(),
                    LinkedIn = dr["LinkedIn"].ToString(),
                    GitHub = dr["GitHub"].ToString()
                });
            }

            return Ok(list);
        }

        // ================= SKILLS =================
        [HttpGet("skills")]
        public IActionResult GetSkills()
        {
            List<Skill> list = new();
            using SqliteConnection con = GetConnection();
            SqliteCommand cmd = new("SELECT * FROM Skills", con);
            con.Open();
            SqliteDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                list.Add(new Skill
                {
                    Id = Convert.ToInt32(dr["Id"]),
                    SkillName = dr["SkillName"].ToString(),
                    SkillLevel = dr["SkillLevel"].ToString()
                });
            }

            return Ok(list);
        }

        // ================= EXPERIENCE =================
        [HttpGet("experience")]
        public IActionResult GetExperience()
        {
            List<Experience> list = new();
            using SqliteConnection con = GetConnection();
            SqliteCommand cmd = new("SELECT * FROM Experience", con);
            con.Open();
            SqliteDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                list.Add(new Experience
                {
                    Company = dr["Company"].ToString(),
                    Role = dr["Role"].ToString(),
                    StartYear = dr["StartYear"].ToString(),
                    EndYear = dr["EndYear"].ToString(),
                    Description = dr["Description"].ToString()
                });
            }

            return Ok(list);
        }

        // ================= PROJECTS =================
        [HttpGet("projects")]
        public IActionResult GetProjects()
        {
            List<Project> list = new();
            using SqliteConnection con = GetConnection();
            SqliteCommand cmd = new("SELECT * FROM Projects", con);
            con.Open();
            SqliteDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                list.Add(new Project
                {
                    Title = dr["Title"].ToString(),
                    Description = dr["Description"].ToString(),
                    TechStack = dr["TechStack"].ToString()
                });
            }

            return Ok(list);
        }

        [HttpPost("contact")]
        public IActionResult SaveContact(ContactMessage msg)
        {
            using var con = GetConnection();
            con.Open();

            var cmd = new SqliteCommand(
                "INSERT INTO ContactMessages(Name,Email,Message) VALUES(@n,@e,@m)", con);

            cmd.Parameters.AddWithValue("@n", msg.Name);
            cmd.Parameters.AddWithValue("@e", msg.Email);
            cmd.Parameters.AddWithValue("@m", msg.Message);

            cmd.ExecuteNonQuery();

            return Ok();
        }


    }
}
