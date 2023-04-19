using AuthenticationMVCCsharp.Models;

namespace AuthenticationMVCCsharp.Repositories
{
    public static class UserRepository
    {
        public static void User(string username, string password)
        {
            var users = new List<User>
            {
                new() {Id = 1, Username = "Batman", Password = "batman", Role= "Manager"},
                new() {Id = 2, Username = "Robin", Password = "robin", Role= "Employee"},

            };
            users
           .FirstOrDefault(x =>
           x.Username == username
           && x.Password == password);
        }
    }
}