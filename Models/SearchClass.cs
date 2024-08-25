using Microsoft.AspNetCore.Mvc;

namespace MainProgram.Models
{
    public class SearchClass
    {
        [Remote("search","course")]
        public string search { get; set; }
    }
}
