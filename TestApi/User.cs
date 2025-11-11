using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema; // ← ye add karein

namespace TestApi.Models
{
    [Table("users")] // ← Ye ensure karega table ka naam "Users" ho
    public class User
    {
        [Key]
        public int id { get; set; }

        [Required]
        public string name { get; set; }

        [Required]
        [EmailAddress]
        public string email { get; set; }
    }
}
