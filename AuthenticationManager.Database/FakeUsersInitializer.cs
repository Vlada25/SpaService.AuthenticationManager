using AuthenticationManager.DTO.User;

namespace AuthenticationManager.Database
{
    public static class FakeUsersInitializer
    {
        private readonly static string[] _surnames =
        {
            "Smirnov", "Ivanov", "Kuznecov", "Sokolov", "Popov", "Lebedev", "Kozlov", "Novikov", "Morozov",
            "Petrov", "Volkov", "Soloviev", "Vasiliev", "Zaicev", "Pavlov", "Semenov", "Golubev", "Vinogradov",
            "Bogdanov", "Vorobiev", "Fedorov", "Michailov", "Belyaev", "Tarasov", "Belov", "Komarov",
            "Orlov", "Kiselev", "Makarov", "Andreev", "Kovalev", "Iliin", "Gusev"
        };

        private readonly static string[] _womanNames =
        {
            "Anastasiya", "Anna", "Mariya", "Elena", "Daria", "Alina", "Irina", "Ekaterina", "Arina", "Vladislava",
            "Polina", "Olga", "Julia", "Tatiana", "Natalia", "Viktoria", "Elizaveta", "Ksenia", "Milana", "Veronika",
            "Alisa", "Valeria", "Aleksandra", "Uliana", "Christina", "Sophia", "Lilia"
        };

        private readonly static string[] _manNames =
        {
            "Aleksandr", "Dmitriy", "Maksim", "Sergey", "Andrew", "Aleksey", "Artem", "Iliya", "Kirill", "Michail",
            "Nikita", "Matvei", "Roman", "Egor", "Arseniy", "Ivan", "Denis", "Evgeniy", "Daniil", "Timofey",
            "Vladislav", "Igor", "Vladimir", "Pavel", "Ruslan", "Mark", "Konstantin"
        };

        private readonly static string[] _middleNames =
        {
            "Aleksandrov", "Dmitriev", "Maksimov", "Sergeev", "Andreev", "Alekseev", "Kirillov", "Michailov",
            "Matveev", "Romanov", "Egorov", "Arseniev", "Ivanov", "Denisov", "Evgeniev", "Danilov",
            "Timofeev", "Vladislavov", "Igorev", "Vladimirov", "Pavlov", "Raslanov", "Konstantinov"
        };

        private readonly static Guid[] _addressesIds =
        {
            new Guid("a5bb191b-27b0-48eb-9f4b-95a26224146c"),
            new Guid("a42461fc-eac0-4eb6-9962-1f226d86a6c3"),
            new Guid("def07137-7897-4d35-811d-0222e46402b1"),
            new Guid("df9eb31b-061e-4806-bae0-b5fb0727aed3"),
            new Guid("9f43494c-fcec-4666-a632-7312eff9f16e"),
            new Guid("8adaf331-98bf-4b44-af90-5392ff0d51bf"),
            new Guid("6d696342-10f8-4e33-b09d-89c3b35ec238"),
            new Guid("f57a0fc0-e284-4a8e-a6cb-463252c159c6"),
            new Guid("f93061db-6686-4644-b75c-1d5f2adb085e"),
        };

        public static List<RegisterUser> GetFakeClients(int count)
        {
            List<RegisterUser> users = new List<RegisterUser>();

            for (int i = 0; i < count; i++)
            {
                int sex = new Random((int)DateTime.Now.Ticks + i).Next(2);
                int surnameIndex = new Random((int)DateTime.Now.Ticks + i).Next(_surnames.Length);
                int middleNameIndex = new Random((int)DateTime.Now.Ticks + i).Next(_middleNames.Length);

                if (sex == 0)
                {
                    int nameIndex = new Random((int)DateTime.Now.Ticks + i).Next(_womanNames.Length);

                    users.Add(
                        new RegisterUser
                        {
                            Surname = _surnames[surnameIndex] + "a",
                            Name = _womanNames[nameIndex],
                            MiddleName = _middleNames[middleNameIndex] + "na",
                            UserName = _womanNames[nameIndex].ToLower() + i,
                            Email = _womanNames[nameIndex].ToLower() + i + "@gmail.com",
                            Password = _womanNames[nameIndex].ToLower() + i + "123",
                            ConfirmPassword = _womanNames[nameIndex].ToLower() + i + "123",
                            Roles = new string[] { }
                        });
                }
                else
                {
                    int nameIndex = new Random((int)DateTime.Now.Ticks + i).Next(_manNames.Length);

                    users.Add(
                        new RegisterUser
                        {
                            Surname = _surnames[surnameIndex],
                            Name = _manNames[nameIndex],
                            MiddleName = _middleNames[middleNameIndex] + "ich",
                            UserName = _manNames[nameIndex].ToLower() + i,
                            Email = _manNames[nameIndex].ToLower() + i + "@gmail.com",
                            Password = _manNames[nameIndex].ToLower() + i + "123",
                            ConfirmPassword = _manNames[nameIndex].ToLower() + i + "123",
                            Roles = new string[] { }
                        });
                }
            }

            return users;
        }


        public static List<RegisterMasterUser> GetFakeMasters(int count)
        {
            List<RegisterMasterUser> users = new List<RegisterMasterUser>();

            for (int i = 0; i < count; i++)
            {
                int sex = new Random((int)DateTime.Now.Ticks + i).Next(2);
                int surnameIndex = new Random((int)DateTime.Now.Ticks + i).Next(_surnames.Length);
                int middleNameIndex = new Random((int)DateTime.Now.Ticks + i).Next(_middleNames.Length);
                int addressIndex = new Random((int)DateTime.Now.Ticks + i).Next(_addressesIds.Length);

                if (sex == 0)
                {
                    int nameIndex = new Random((int)DateTime.Now.Ticks + i).Next(_womanNames.Length);

                    users.Add(
                        new RegisterMasterUser
                        {
                            Surname = _surnames[surnameIndex] + "a",
                            Name = _womanNames[nameIndex],
                            MiddleName = _middleNames[middleNameIndex] + "na",
                            UserName = _womanNames[nameIndex].ToLower() + i,
                            Email = _womanNames[nameIndex].ToLower() + i + "@gmail.com",
                            AddressId = _addressesIds[addressIndex],
                            Password = _womanNames[nameIndex].ToLower() + i + "123",
                            ConfirmPassword = _womanNames[nameIndex].ToLower() + i + "123",
                            Roles = new string[] { "Master" }
                        });
                }
                else
                {
                    int nameIndex = new Random((int)DateTime.Now.Ticks + i).Next(_manNames.Length);

                    users.Add(
                        new RegisterMasterUser
                        {
                            Surname = _surnames[surnameIndex],
                            Name = _manNames[nameIndex],
                            MiddleName = _middleNames[middleNameIndex] + "ich",
                            UserName = _manNames[nameIndex].ToLower() + i,
                            Email = _manNames[nameIndex].ToLower() + i + "@gmail.com",
                            AddressId = _addressesIds[addressIndex],
                            Password = _manNames[nameIndex].ToLower() + i + "123",
                            ConfirmPassword = _manNames[nameIndex].ToLower() + i + "123",
                            Roles = new string[] { "Master" }
                        });
                }
            }

            return users;
        }
    }
}
