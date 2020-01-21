using System.Collections.Generic;

namespace TravelAgency.Interfaces.Dto
{
    public class RegisteredUserData
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Surname { get; set; }

        public string Telephone { get; set; }

        public string Passport { get; set; }

        public string PhotoPath { get; set; }

        public int UserId { get; set; }
    }
}