using System.Text.Json.Serialization;

namespace RestWithASPNETUdemy.Data.VO
{

    public class PersonVO
    {
        
        public long Id { get; set; }


        public string FirstName { set; get; }


        public string LastName { set; get; }


        public string Address { set; get; }


        public string Gender { set; get; }
    }
}
