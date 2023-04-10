using AuthenticationManager.DTO.User;

namespace AuthenticationManager.Domain.Configuration
{
    public static class UsersConfig
    {
        public static List<RegisterUser> ConfigNecessaryUsers()
        {
            return new List<RegisterUser>
            {
                new RegisterUser
                {
                    Surname = "Leonenko",
                    Name = "Vladislava",
                    MiddleName = "Jurievna",
                    UserName = "aladka",
                    Email = "aladka03@gmail.com",
                    Password = "admin111",
                    ConfirmPassword = "admin111",
                    Roles = new string[] { "Admin" }
                },
                new RegisterUser
                {
                    Surname = "Ermolenko",
                    Name = "Andrew",
                    MiddleName = "Aleksandrovich",
                    UserName = "ermol",
                    Email = "andrew_ermol@gmail.com",
                    Password = "manager111",
                    ConfirmPassword = "manager111",
                    Roles = new string[] { "Manager" }
                }
            };
        }
    }
}
