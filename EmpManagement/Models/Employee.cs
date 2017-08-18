using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EmpManagement.Models
{
    //[Bind (Exclude ="Phone")]

    public interface IEmployee
    {
        string Name { get; set; }
    }
    public class Employee : IEmployee
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        public int Phone { get; set; }
    }
}