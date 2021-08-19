using System;
using hr.Domain.Models.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace hr.Domain.Models.Entities
{
    public class People : Entity
    {
        [Required]
        [Column("varchar(100)")]
        public string? Name { get; set; }
        
        [Required]
        public DateTime BirthDate { get; set; }

        [Required]
        public Gender Gender { get; set; }

        [Required]
        [Column("varchar(100)")]
        public string? Email { get; set; }

        [Required]
        [Column("varchar(11)")]
        public string? CPF { get; set; }

        public Team Team { get; set; }
    }
}
