using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Dapper.Contrib.Extensions;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace HumanResourceApp.Models
{
	public class EmployeeModel
	{
        /*[Computed]*/
        public int id_no { get; set; }

        [Display(Name = "First Name")]
        [Required(ErrorMessage = "First name is required.")]
        public string first_name { get; set; }
        
        [Display(Name = "Last Name")]
        [Required(ErrorMessage = "Last name is required.")]
        public string last_name { get; set; }

        [Display(Name = "Middle Name")]
        public string middle_name { get; set; }

        [Display(Name = "Job Title")]
        [Required(ErrorMessage = "Job Title is required.")]
        public string job_title { get; set; }
        
        [Display(Name = "Level")]
        [Required(ErrorMessage = "Level is required.")]
        public string level_id { get; set; }


        public string level_name { get; set; }

        [Display(Name = "Age")]
        [Required(ErrorMessage = "Age is required.")]
        public int age { get; set; }
        
    }
}
