using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _403_Project_1.Models
{
    [Table("Missions")]
    public class Missions
    {
        [Key]
        [Display(Name = "Mission ID")]
        [HiddenInput(DisplayValue = false)]
        public int MISSION_ID { get; set; }

        public string MISSION_NAME { get; set; }

        public string PRESIDENT_NAME { get; set; }

        public string ADDRESS { get; set; }

        public string LANGUAGE { get; set; }

        public string CLIMATE { get; set; }

        public string DOMINANT_RELIGION { get; set; }

        public string SYMBOL { get; set; }

        [NotMapped]
        public List<Missions> lstMissions { get; set; }
    }
}