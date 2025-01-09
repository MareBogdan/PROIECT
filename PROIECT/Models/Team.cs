using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using SQLite;
using SQLiteNetExtensions.Attributes;

namespace PROIECT.Models
{
    public class Team
    {
        [PrimaryKey, AutoIncrement]
        public int TeamId { get; set; }

        [Required(ErrorMessage = "Team Name is required")]
        [StringLength(100, ErrorMessage = "Team Name can't be longer than 100 characters")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Division is required")]
        [StringLength(50, ErrorMessage = "Division can't be longer than 50 characters")]
        public string Division { get; set; }

        // Relația cu Coach (1-1)
        [OneToOne(CascadeOperations = CascadeOperation.All)]
        public Coach? Coach { get; set; }

        // Relația cu Player (1-M)
        [OneToMany(CascadeOperations = CascadeOperation.All)]
        public List<Player>? Players { get; set; }
    }
}
