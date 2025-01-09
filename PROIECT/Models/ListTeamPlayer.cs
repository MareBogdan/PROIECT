using SQLite;
using SQLiteNetExtensions.Attributes;

namespace PROIECT.Models
{
    public class ListTeamPlayer
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }

        [ForeignKey(typeof(Team))]
        public int TeamID { get; set; }

        [ForeignKey(typeof(Player))]
        public int PlayerID { get; set; }
    }
}
