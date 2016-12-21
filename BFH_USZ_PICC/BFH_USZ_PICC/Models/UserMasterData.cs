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

    public class UserMasterData
    {
        public UserMasterData() { }

        public UserMasterData(UserMasterDataRO realmObject)
        {
            ID = realmObject.ID;
            Gender = (Gender)realmObject.GenderInt;
            Surname = realmObject.Surname;
            Name = realmObject.Name;
            Street = realmObject.Street;
            Zip = realmObject.Zip;
            City = realmObject.City;
            Email = realmObject.Email;
            Phone = realmObject.Phone;
            Mobile = realmObject.Mobile;
            Birthdate = realmObject.Birthdate;
        }

        [SQLite.PrimaryKey]
        public int ID { get; set; }
        public Gender Gender { get; set; }
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

    public class UserMasterDataRO : RealmObject
    {
        [Realms.PrimaryKey]
        public int ID { get; set; }
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

        public void LoadDataFromModelObject(UserMasterData modelObject)
        {
            ID = modelObject.ID;
            GenderInt = (int)modelObject.Gender;
            Surname = modelObject.Surname;
            Name = modelObject.Name;
            Street = modelObject.Street;
            Zip = modelObject.Zip;
            City = modelObject.City;
            Email = modelObject.Email;
            Phone = modelObject.Phone;
            Mobile = modelObject.Mobile;
            Birthdate = modelObject.Birthdate;
        }
    }
}
