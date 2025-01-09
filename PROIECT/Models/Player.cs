using System;
using System.ComponentModel.DataAnnotations;
using SQLite;
using SQLiteNetExtensions.Attributes;

namespace PROIECT.Models
{
    public class Player
    {
        [PrimaryKey, AutoIncrement]
        public int PlayerId { get; set; }

        [Display(Name = "First Name")]
        [Required(ErrorMessage = "First Name is required")]
        [StringLength(50, ErrorMessage = "First Name can't be longer than 50 characters")]
        public string FirstName { get; set; }

        [Display(Name = "Last Name")]
        [Required(ErrorMessage = "Last Name is required")]
        [StringLength(50, ErrorMessage = "Last Name can't be longer than 50 characters")]
        public string LastName { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Date of Birth")]
        [Required(ErrorMessage = "Date of Birth is required")]
        public DateTime DateOfBirth { get; set; }

        public string Position { get; set; }

        // Cheia străină către Team
        [ForeignKey(typeof(Team))]
        public int TeamId { get; set; }

        // Relația Many-to-One cu Team
        [ManyToOne]
        public Team Team { get; set; }
    }
}
