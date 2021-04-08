using System.ComponentModel.DataAnnotations.Schema;

namespace RestWithASPNETUdemy.Model
{   
    [Table("person")]
    public class Person
    {
        [Column("id")]
        public long  Id { get; set; }

        [Column("first_name")]
        public string FirstName { set; get; }

        [Column("last_name")]
        public string LastName { set; get; }

        [Column("address")]
        public string Address { set; get; }

        [Column("gender")]
        public string Gender { set; get; }
    }
}
