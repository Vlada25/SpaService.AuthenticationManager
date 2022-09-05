using AuthenticationManager.DTO.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public static List<RegisterUser> GetFakeUsers(int count)
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
                            Password = _manNames[nameIndex].ToLower() + i + "12345",
                            ConfirmPassword = _manNames[nameIndex].ToLower() + i + "12345",
                            Roles = new string[] {}
                        });
                }
            }

            return users;
        }
    }
}
