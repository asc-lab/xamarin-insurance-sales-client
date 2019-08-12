using System;
namespace InsuranceSales.Models
{
    public class UserCredentialsModel
    {
        public UserCredentialsModel()
        {
        }

        public string Username { get; internal set; }
        public string Password { get; internal set; }
    }
}
