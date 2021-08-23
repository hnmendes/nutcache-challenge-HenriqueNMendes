using System;
using hr.Domain.Models.Enums;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace hr.API.ViewModels
{
    public class PeopleViewModel
    {
        [Key]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "The {0} is required.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "The {0} is required.")]
        public DateTime BirthDate { get; set; }

        [Required(ErrorMessage = "The {0} is required.")]
        public Gender Gender { get; set; }

        [Required(ErrorMessage = "The {0} is required.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "The {0} is required.")]
        public DateTime StartDate { get; set; }

        [Required(ErrorMessage = "The {0} is required.")]
        [StringLength(11, ErrorMessage = "The {0} must have 11 digits.")]
        public string CPF { get; set; }

        public Team? Team { get; set; }
    }
}
