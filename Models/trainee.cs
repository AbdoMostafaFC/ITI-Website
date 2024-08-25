using System.ComponentModel.DataAnnotations.Schema;

namespace MainProgram.Models
{
	public class trainee
	{
        public int id { get; set; }
		
        public string name { get; set; }
        public string image { get; set; }
        public string address { get; set; }
		public int level { get; set; }
		[ForeignKey("department")]
		public int dept_id {  get; set; }
		public virtual Department? department { get; set; }
		public virtual List<CrsResult>?CrsResults { get; set; }

	}
}
