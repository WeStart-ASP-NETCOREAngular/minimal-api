using System.ComponentModel.DataAnnotations;

namespace MinimalApiIntro.Models
{
    public class Customer
    {
        public int Id { get; set; }
       
        public string FirstName { get; set; }

        public string LastName { get; set; }
    }
}
