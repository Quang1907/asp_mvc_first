﻿
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ASP_MVC.Models
{
    public class AppUser : IdentityUser
    {
        //[Column(TypeName = "nvarchar")]
        //[StringLength(400)]
        //public string? HomeAddress { get; set; }

        //[DataType(DataType.Date)]
        //public DateTime? BirthDate { get; set; }
    }
}
