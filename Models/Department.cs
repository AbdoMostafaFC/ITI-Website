using System.ComponentModel.DataAnnotations;

namespace MainProgram.Models
{
	public class Department
	{
        public int id { get; set; }
        [Required]
        [MaxLength(5)]
        public string name { get; set; }
        public string manager { get; set; }
        public virtual List<course>?Courses { get; set; }
        public virtual List<instructor>? Instructors { get; set;}
		public virtual List<trainee>? Trainees { get; set;}

    }
}
