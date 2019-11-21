using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace _403_Project_1.Models
{
    public class Mission
    {
        
        public string Mission_Code { get; set; }

        [Required(ErrorMessage = "This field is required")]
        public string Mission_Name { get; set; }
    }
}