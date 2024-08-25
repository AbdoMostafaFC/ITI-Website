using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MainProgram.Models
{
	public class instructor
	{
        public int id { get; set; }
        [Required]
        public string name { get; set; }
        [DisplayName("imagee")]
        public string image { get; set; }
        [RegularExpression("(alex|cairo|assuit)",ErrorMessage ="please choise avalide address")]
        public string address { get; set; }
        public int salary { get; set; }
        [ForeignKey("course")]
        public int course_id {  get; set; }
        [ForeignKey("department")]
        public int department_id {  get; set; }
        public virtual course? course { get; set; }
        public virtual Department? department { get; set; }

	}
}
