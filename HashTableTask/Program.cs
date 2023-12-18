using System;
using System.Linq;
using System.Collections.Generic;

namespace HashTableTask
{
    internal class Program
    {
        static HashTable<User, UserData> users = new HashTable<User, UserData>();
        static HashTable<AgeGroup, UserList> age_groups = new HashTable<AgeGroup, UserList>();

        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.Unicode;
            Console.InputEncoding = System.Text.Encoding.Unicode;
            Console.WriteLine("Додавати контрольні дані? Так/Ні");
            while (Console.ReadLine() is string input)
            {
                if (input == "Так")
                {
                    AddUser("user1", "qwerty1", "11@ukr.net", new DateTime(2000, 12, 13));
                    AddUser("user2", "qwerty2", "12@ukr.net", new DateTime(2001, 11, 11));
                    AddUser("user3", "qwerty3", "13@ukr.net", new DateTime(1988, 10, 9));
                    AddUser("user4", "qwerty4", "14@ukr.net", new DateTime(1989, 9, 7));
                    AddUser("user5", "qwerty5", "15@ukr.net", new DateTime(1990, 8, 5));
                    AddUser("user6", "qwerty6", "16@ukr.net", new DateTime(1991, 7, 3));
                    AddUser("user7", "qwerty7", "17@ukr.net", new DateTime(1992, 6, 1));

                    Console.WriteLine("Дані додано");
                    break;
                }
                else if (input == "Ні")
                    break;
                else
                    Console.WriteLine("Некоректний від");
                Console.WriteLine("Додавати контрольні дані? Так/Ні");
            }

            while (true)
            {
                Console.WriteLine("1. Додати користувача");
                Console.WriteLine("2. Знайти користувача");
                Console.WriteLine("3. Видалити користувача");
                Console.WriteLine("4. Вивести всіх користувачів");
                Console.WriteLine("5. Вивести статистичні дані");
                Console.WriteLine("6. Вивести користувачів за віковою групою");
                Console.WriteLine("7. Вихід");

                string com = Console.ReadLine();

                switch (com)
                {
                    case "1":
                        {
                            Console.Write("Введіть логін: ");
                            string username = Console.ReadLine();

                            Console.Write("Введіть пароль: ");
                            string password = Console.ReadLine();

                            Console.Write("Введіть пошту: ");
                            string email = Console.ReadLine();

                            bool success = false;
                            while (!success)
                            {
                                try
                                {
                                    Console.WriteLine("Введіть рік народження");
                                    int year = int.Parse(Console.ReadLine());

                                    Console.WriteLine("Введіть місяць народження");
                                    int month = int.Parse(Console.ReadLine());

                                    Console.WriteLine("Введіть день народження");
                                    int day = int.Parse(Console.ReadLine());

                                    DateTime date = new DateTime(year, month, day);

                                    if (DateTime.Now.AddYears(-18) < date)
                                    {
                                        Console.WriteLine("Неповнолтні користувачі недозволені!");
                                        break;
                                    }

                                    AddUser(username, password, email, date);
                                    Console.WriteLine("Користувача додано!");
                                    success = true;
                                }
                                catch
                                {
                                    Console.WriteLine("Невірний ввід");
                                }
                            }
                        }
                        break;

                    case "2":
                        {
                            Console.Write("Введіть логін: ");
                            string username = Console.ReadLine();

                            Console.Write("Введіть пароль: ");
                            string password = Console.ReadLine();

                            var user = users.FindEntry(new User(username, password));
                            if (user == null)
                            {
                                Console.WriteLine("Такого користувача не існує! ");
                                break;
                            }
                            Console.WriteLine($"Користувач: {user.key.username} Пошта: {user.value.email} Дата народження: {user.value.bd.ToString("d.MMMM.yyyy")} ");
                        }
                        break;

                    case "3":
                        {
                            Console.Write("Введіть логін: ");
                            string username = Console.ReadLine();

                            Console.Write("Введіть пароль: ");
                            string password = Console.ReadLine();

                            var user = users.FindEntry(new User(username, password));
                            if (user == null)
                            {
                                Console.WriteLine("Такого користувача не існує! ");
                                break;
                            }
                            users.RemoveEntry(new User(username, password));
                            Console.WriteLine("Видалено!");
                        }
                        break;

                    case "4":
                        {
                            Console.WriteLine(String.Join("\n", users.table.Where(t => t != null && !t.Deleted).Select(user => $"Користувач: {user.key.username} Пошта: {user.value.email} Дата народження: {user.value.bd.ToString("d.MMMM.yyyy")} ")));
                        }
                        break;

                    case "5":
                        {
                            Console.WriteLine(String.Join("\n", identifyAgeCategories().Select((el, i) => $"{AgeGroup.categories[i]} --> {Math.Round(el * 100)}%")));
                        }
                        break;

                    case "6":
                        {
                            Console.WriteLine(String.Join("\n", AgeGroup.categories.Select((el, i) => $"{i + 1}: {el}")));
                            Console.WriteLine("Введіть номер категорії: ");
                            int cat = 0;
                            while (!int.TryParse(Console.ReadLine(), out cat) && cat <= 0 && cat > AgeGroup.categories.Length)
                            {
                                Console.WriteLine("Некоректний ввід");
                                Console.WriteLine("Введіть номер категорії: ");
                            }

                            cat -= 1;

                            Console.WriteLine($"{AgeGroup.categories[cat]} {Math.Round(identifyAgeCategories()[cat] * 100)}%");

                            var entry = age_groups.FindEntry(new AgeGroup(cat));
                            if (entry != null)
                                Console.WriteLine(String.Join("\n", entry.value.usernames.Select(user => $"Користувач: {user}")));
                            else
                                Console.WriteLine("Користувачів в цій категорії немає");
                        }
                        break;

                    case "7":
                        {
                            Environment.Exit(0);
                        }
                        break;

                    default: Console.WriteLine("Неправильна команда"); break;
                }

                Console.WriteLine("Натисніть будь яку клавішу...");
                Console.ReadKey();
                Console.WriteLine();
            }
        }

        public static void AddUser(string username, string password, string email, DateTime bd)
        {
            users.InsertEntry(new User(username, password), new UserData(email, bd));

            int category = 0;
            if (DateTime.Now.AddYears(-25) > bd) category++;
            if (DateTime.Now.AddYears(-35) > bd) category++;
            if (DateTime.Now.AddYears(-50) > bd) category++;

            var group = age_groups.FindEntry(new AgeGroup(category));
            if (group == null)
                age_groups.InsertEntry(new AgeGroup(category), new UserList(new List<string>() { username }));
            else
                group.value.usernames.Add(username);
        }

        public static void RemoveUser(string username, string password)
        {
            var user = users.FindEntry(new User(username, password));
            if (user != null)
                users.RemoveEntry(new User(username, password));
            else
            {
                Console.WriteLine("Користувача не знайдено");
                return;
            }

            int category = 0;
            if (DateTime.Now.AddYears(-25) < user.value.bd) category++;
            if (DateTime.Now.AddYears(-35) < user.value.bd) category++;
            if (DateTime.Now.AddYears(-50) < user.value.bd) category++;

            age_groups.FindEntry(new AgeGroup(category)).value.usernames.Remove(username);
        }

        static double[] identifyAgeCategories()
        {
            int[] amount_in_group = new int[AgeGroup.categories.Length];
            int usersAmount = 0;
            for (int i = 0; i < AgeGroup.categories.Length; i++)
            {
                var entry = age_groups.FindEntry(new AgeGroup(i));
                if (entry != null)
                {
                    int count = entry.value.usernames.Count;
                    usersAmount += count;
                    amount_in_group[i] = count;
                }
            }

            double[] percents = new double[amount_in_group.Length];
            for (int i = 0; i < amount_in_group.Length; i++)
            {
                percents[i] = (double)amount_in_group[i] / usersAmount;
            }

            return percents;
        }
    }
}