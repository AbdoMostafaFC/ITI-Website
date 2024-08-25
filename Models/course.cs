using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.CompilerServices;

namespace MainProgram.Models
{
	public class course
	{
        public int id { get; set; }
		//[Display(Name ="Course name")]
		[Required(ErrorMessage ="You Must Enter NAme")]
		[MaxLength(20,ErrorMessage ="The max length of name =20")]
		[MinLength(2,ErrorMessage ="Them  minum length of name =2")]
		[UniqueName]
		public string name { get; set; }
		[Required]
		[Range(50,100)]
		public int degree { get; set; }
		//	[DataType(DataType.Password)]
		[Required(ErrorMessage ="minum Degree Required!!")]
		[Remote("checkdegree","course",AdditionalFields ="degree")]
		public int min_degree { get; set; }
		////[dividby3
		
		public int? houres { get; set; }
		[ForeignKey("department")]
		public int dep_id {  get; set; }
		public virtual Department? department { get; set; }
		public virtual List<instructor>? instructors { get; set; }
		public virtual List<CrsResult>? CrsResults { get; set; }

	}
}
