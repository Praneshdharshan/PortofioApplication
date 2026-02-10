using System.Collections.Generic;

namespace PortofioApplication.Models.ViewModels
{
    public class PortfolioViewModel
    {
        public List<Profile>? Profiles { get; set; }
        public List<Skill>? Skills { get; set; }
        public List<Experience>? Experiences { get; set; }
        public List<Project>? Projects { get; set; }
    }
}
