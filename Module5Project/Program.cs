using System;

namespace Module5Project
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ShowUserInConsole(EnterUser());
        }
        static (string Name,string LastName, int Age, string[] Pets, string[] FavouriteColors) EnterUser()
        {
            (string Name, string LastName, int Age, string[] Pets, string[] FavouriteColors) user;

            Console.Write("Введите своё имя: ");
            user.Name = Console.ReadLine();

            Console.Write("Введите свою фамилию: ");
            user.LastName = Console.ReadLine();

            string numberString;

            do
            {
                Console.Write("Введите свой возраст: ");
                numberString = Console.ReadLine();
            } while (CheckIfNegative(numberString,out user.Age));

            Console.Write("Есть ли у вас питомцы? (Да/Нет): ");
            if (Console.ReadLine() == "Да")
            {
                int petQuantity;
                do
                {
                    Console.Write("Сколько?: ");
                    numberString = Console.ReadLine();
                } while (CheckIfNegative(numberString,out petQuantity));

                var pets = new string[petQuantity];
                for (int i = 0; i < petQuantity; i++)
                {
                    Console.Write("Как зовут питомца номер {0}?: ", i + 1);
                    pets[i] = Console.ReadLine();
                }
                user.Pets = pets;
            }
            else
            {
                user.Pets = new string[0];
            }

            int colorQuantity;
            do
            {
                Console.Write("Сколько у вас любимых цветов?: ");
                numberString = Console.ReadLine();
            } while (CheckIfNegative(numberString, out colorQuantity));

            var colors = new string[colorQuantity];
            for (int i = 0; i < colorQuantity; i++)
            {
                Console.Write("Назовите цвет номер {0}: ", i + 1);
                colors[i] = Console.ReadLine();
            }
            user.FavouriteColors = colors;

            return user;
        }
        static bool CheckIfNegative(string numberString, out int resultNumber)
        {
            if (int.TryParse(numberString,out int parseResult))
            {
                if (parseResult > 0)
                {
                    resultNumber = parseResult;
                    return false;
                }
            }
            resultNumber = 0;
            return true;
        }
        static void ShowUserInConsole((string Name, string LastName, int Age, string[] Pets, string[] FavouriteColors) user)
        {
            Console.WriteLine("Имя: " + user.Name);

            Console.WriteLine("Фамилия: " + user.LastName);

            Console.WriteLine("Возраст: " + user.Age);

            if (user.Pets.Length > 0)
            {
                for (int i = 0; i < user.Pets.Length; i++)
                {
                    Console.WriteLine("Питомец номер {0}: {1}", i + 1, user.Pets[i]);
                }
            }

            for (int i = 0; i < user.FavouriteColors.Length; i++)
            {
                Console.WriteLine("Любимый цвет номер {0}: {1}", i + 1, user.FavouriteColors[i]);
            }
        }
    }
}
