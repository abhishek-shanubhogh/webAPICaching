using Microsoft.AspNetCore.Cors;
using Microsoft.VisualBasic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace webAPICaching.Model
{
    public class Movies
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }

        public string Description { get; set; }

        [DataType(DataType.Date)]
        public DateTime Date { get; set; }

        public string TagLine { get; set; }


    }
}
