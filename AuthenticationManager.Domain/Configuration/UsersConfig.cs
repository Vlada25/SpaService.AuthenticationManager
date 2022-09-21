using AuthenticationManager.DTO.User;

namespace AuthenticationManager.Domain.Configuration
{
    public static class UsersConfig
    {
        public static List<RegisterUser> ConfigNecessaryUsers()
        {
            return new List<RegisterUser>
            {
                new RegisterUser // 1
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
                new RegisterUser // 2
                {
                    Surname = "Ermolenko",
                    Name = "Andrew",
                    MiddleName = "Aleksandrovich",
                    UserName = "ermol",
                    Email = "andrew_ermol@gmail.com",
                    Password = "manager111",
                    ConfirmPassword = "manager111",
                    Roles = new string[] { "Manager" }
                },
                new RegisterUser // 3
                {
                    Surname = "Shulgovskaya",
                    Name = "Sofia",
                    MiddleName = "Markovna",
                    UserName = "sofia_shu_master",
                    Email = "sofia_shu_master@gmail.com",
                    Password = "sofia_master111",
                    ConfirmPassword = "sofia_master111",
                    Roles = new string[] { "Master" }
                },
                new RegisterUser // 4
                {
                    Surname = "Volkova",
                    Name = "Elena",
                    MiddleName = "Nikolaevna",
                    UserName = "elena_vol_master",
                    Email = "elena_vol_master@gmail.com",
                    Password = "elena_master111",
                    ConfirmPassword = "elena_master111",
                    Roles = new string[] { "Master" }
                },
                new RegisterUser // 5
                {
                    Surname = "Rozhkova",
                    Name = "Vasilisa",
                    MiddleName = "Evgenievna",
                    UserName = "vasilisa_roz_master",
                    Email = "vasilisa_roz_master@gmail.com",
                    Password = "vasilisa_master111",
                    ConfirmPassword = "vasilisa_master111",
                    Roles = new string[] { "Master" }
                },
                new RegisterUser // 6
                {
                    Surname = "Murkin",
                    Name = "Egor",
                    MiddleName = "Valerievich",
                    UserName = "egor_mur_master",
                    Email = "egor_mur_master@gmail.com",
                    Password = "egor_master111",
                    ConfirmPassword = "egor_master111",
                    Roles = new string[] { "Master" }
                },
                new RegisterUser // 7
                {
                    Surname = "Graholskaya",
                    Name = "Irina",
                    MiddleName = "Maratovna",
                    UserName = "irina_gra_master",
                    Email = "irina_gra_master@gmail.com",
                    Password = "irina_master111",
                    ConfirmPassword = "irina_master111",
                    Roles = new string[] { "Master" }
                },
            };
        }
    }
}
