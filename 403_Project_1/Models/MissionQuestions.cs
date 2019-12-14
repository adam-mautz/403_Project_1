using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _403_Project_1.Models
{
    [Table("MissionQuestions")]
    public class MissionQuestions
    {
        [Key]
        [Display(Name = "Question ID")]
        [HiddenInput(DisplayValue = false)]
        public int QUESTION_ID { get; set; }

        [Display(Name = "Mission ID")]
        [HiddenInput(DisplayValue = false)]
        public int MISSION_ID { get; set; }

        [Display(Name = "User ID")]
        [HiddenInput(DisplayValue = false)]
        public int USER_ID { get; set; }

        [Display(Name = "Question")]
        public string QUESTION { get; set; }

        [Display(Name = "Answer")]
        public string ANSWER { get; set; }

    }
}