using System;
namespace EastonCityGuide.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }

        public User() { }
        public User(string Username, string Password)
        {
            this.Username = Username;
            this.Password = Password;
        }

        public bool CheckInformation()
        {
            if (this.Username.Equals("TOES") && this.Password.Equals("toes"))
                return true;
            else
                return false;
        }
    }
}

