using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
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

        private SqlConnection GetConnection()
        {
            return new SqlConnection(_config.GetConnectionString("DB"));
        }

        // ================= PROFILE =================
        [HttpGet("profile")]
        public IActionResult GetProfile()
        {
            List<Profile> list = new();
            using SqlConnection con = GetConnection();
            SqlCommand cmd = new("SELECT * FROM Profile", con);
            con.Open();
            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                list.Add(new Profile
                {
                    Id = (int)dr["Id"],
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
            using SqlConnection con = GetConnection();
            SqlCommand cmd = new("SELECT * FROM Skills", con);
            con.Open();
            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                list.Add(new Skill
                {
                    Id = (int)dr["Id"],
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
            using SqlConnection con = GetConnection();
            SqlCommand cmd = new("SELECT * FROM Experience", con);
            con.Open();
            SqlDataReader dr = cmd.ExecuteReader();

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
            using SqlConnection con = GetConnection();
            SqlCommand cmd = new("SELECT * FROM Projects", con);
            con.Open();
            SqlDataReader dr = cmd.ExecuteReader();

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

    }
}
