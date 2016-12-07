using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BFH_USZ_PICC.Models
{ 
    public enum Salutation
    {
        GenderFree,
        Male,
        Female
    }
    //This class contains a glossary entry with the word that needs to be explained and the statement
    public class UserMasterData
    {
        public Salutation Salutation { get; set; }
        public string Surname { get; set; }
        public string Name { get; set; }
        public string Street { get; set; }
        public string Zip { get; set; }
        public string City { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Mobile { get; set; }
        public DateTimeOffset? Birthdate { get; set; }

        private static UserMasterData masterData;

        private UserMasterData() { }

        public static UserMasterData MasterData {

            get
            {
                if (masterData == null)
                {
                    masterData = new UserMasterData();
                }
                return masterData;
            }

            set
            {
                if (masterData != null)
                {
                    masterData = null;
                }

            }
        }
        //}
        //(Sex salutation, string surname, string name, string street, string zip, string place,
        //       string email, string phone, string mobile, DateTimeOffset birthdate)
        //{
        //    MasterData.Salutation = salutation;
        //    MasterData.Surname = surname;
        //    MasterData.Name = name;
        //    MasterData.Street = street;
        //    MasterData.Zip = zip;
        //    MasterData.Place = place;
        //    MasterData.Email = email;
        //    MasterData.Phone = phone;
        //    MasterData.Mobile = mobile;
        //    MasterData.Birthdate = birthdate;

        //}

    }
}
