using System.ComponentModel.DataAnnotations;

namespace AppDb.Models
{
    public class Contacts
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
            
        public string Email { get; set; }
        public string Phone { get; set; }
    }
}
