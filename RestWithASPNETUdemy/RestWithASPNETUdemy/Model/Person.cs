using RestWithASPNETUdemy.Model.Context.Base;
using System.ComponentModel.DataAnnotations.Schema;

namespace RestWithASPNETUdemy.Model
{   
    [Table("person")]
    public class Person : BaseEntity
    {
        
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
