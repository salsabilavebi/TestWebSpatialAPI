
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace APIplaces.EFCore
{
    [Table("places")]
    public class Place
    {


        [Key, Required]
        public int Id { get; set; }
        public string OwnerName { get; set; }
        public string placename { get; set; }
        public string address { get; set; }
        public string placetype { get; set; }
        public DateTime date { get; set; }


    }
}
