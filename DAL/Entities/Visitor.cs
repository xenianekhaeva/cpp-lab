using System.ComponentModel.DataAnnotations;

namespace DAL.Entities
{
    public class Visitor
    {
        public int VisitorId { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string Gender { get; set; }
        [Required]
        public double Age { get; set; }
        [Required]
        public string Telephone { get; set; }

        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        public string Feedback { get; set; }

    }
}
