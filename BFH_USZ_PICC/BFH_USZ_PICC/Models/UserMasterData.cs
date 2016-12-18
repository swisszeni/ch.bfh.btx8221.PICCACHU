using Realms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BFH_USZ_PICC.Models
{ 
    public enum Gender
    {
        Unspecified,
        Male,
        Female
    }

    public class UserMasterData : RealmObject
    {
        [Ignored]
        public Gender Gender
        {
            get { return (Gender)GenderInt; }
            set { GenderInt = (int)value; }
        }
        public int GenderInt { get; set; }
        public string Surname { get; set; }
        public string Name { get; set; }
        public string Street { get; set; }
        public string Zip { get; set; }
        public string City { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Mobile { get; set; }
        public DateTimeOffset? Birthdate { get; set; }
    }
}
