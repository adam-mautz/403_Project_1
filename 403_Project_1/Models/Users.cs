using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _403_Project_1.Models
{
    [Table("Users")]
    public class Users
    {
        [Key]
        [Display(Name = "User ID")]
        [HiddenInput(DisplayValue = false)]
        public int USER_ID { get; set; }

        [Display(Name = "Email Address")]
        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        public string USER_EMAIL { get; set; }

        [Display(Name = "Password")]
        [Required(ErrorMessage = "Password is required")]
        public string PASSWORD { get; set; }

        [Display(Name = "First Name")]
        [Required(ErrorMessage = "First Name is required")]
        public string FIRST_NAME { get; set; }

        [Display(Name = "Last Name")]
        [Required(ErrorMessage = "Last Name is required")]
        public string LAST_NAME { get; set; }
    }
}