using System.ComponentModel.DataAnnotations.Schema;

namespace MainProgram.Models
{
	public class CrsResult
	{
        public int id { get; set; }
        public int degree { get; set; }
		[ForeignKey("course")]
		public int coure_id {  get; set; }
        [ForeignKey("Trainee")]
        public int trainee_id {  get; set; }
        public virtual course? course { get; set; }
        public virtual trainee? Trainee { get; set; }
	}
}
