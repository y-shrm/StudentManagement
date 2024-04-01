using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace studentManagementSystem.Models
{
    public class Student
    {
        [Key]
        public int Id { get; set; }
        
        [Required]
       
        public string Name { get; set; }
        [Required]
        [DisplayName("Father name")]
        public string FatherName { get; set; }

        [Required]
        [DisplayName("Mother name")]
        public string MotherName { get; set;}

        [Required]
        //[MaxLength(100)]
        public int Age { get; set; }
        [Required]
        public string Address { get; set;}

        [Required]
        [DisplayName("Registration date")]
        public DateTime RegistrationDate { get; set; }

        public bool IsDeleted { get; set; }


    }
}
