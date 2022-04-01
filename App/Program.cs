using System;
using System.IO;
using System.Text;

struct User
{
    public string FirstName;
    public string LastName;
    public string Patronymic;
    public DateTime Birthday;

    public User(string lastName, string firstName, string patronymic,DateTime birthday)
    {
        FirstName = firstName;
        LastName = lastName;
        Patronymic = patronymic;
        Birthday = new DateTime(birthday.Ticks);
    }

    public int GetAge()
    {
        DateTime now = DateTime.Now;
        DateTime age = new DateTime(now.Subtract(Birthday).Ticks);
        return age.Year;
    }

    override public string ToString()
    {
        StringBuilder sb = new StringBuilder();
        sb.Append(FirstName + " ");
        sb.Append(LastName + " ");
        sb.Append(Patronymic + " ");
        sb.Append(Birthday.ToShortDateString());
        return sb.ToString();
    }
}
namespace App
{
    class Program
    {
        static void Main(string[] args)
        {
            int size = 5;

            User[] users = Initialization(size);

            Print(users);

            SaveToFile(users);

            User younger = FindYounger(users);
            User older = FindOlder(users);

            SaveToFileOlderYounger(younger, older);

        }

        static User FindYounger(User[] users)
        {
            User younger = users[0];
            for (int i = 1; i < users.Length; i++)
            {
                if (users[i].GetAge() < younger.GetAge())
                    younger = users[i];
            }
            return younger;
        }

        static User FindOlder(User[] users)
        {
            User older = users[0];
            for (int i = 1; i < users.Length; i++)
            {
                if (users[i].GetAge() > older.GetAge())
                    older = users[i];
            }
            return older;
        }

        static void SaveToFileOlderYounger(User younger, User older)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Younger: {younger}");
            sb.AppendLine($"Older: {older}");
            if (File.Exists("olderYounder.txt"))
            {
                try
                {
                    File.AppendAllText("olderYounger.txt", sb.ToString());
                }
                catch (Exception ex)
                {

                    Console.WriteLine(ex.Message);
                }
            }
            else
            {
                File.WriteAllText("olderYounger.txt", sb.ToString());
            }
        }

        static void SaveToFile(User[] users)
        {
            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < users.Length; i++)
            {
                sb.AppendLine(users[i].ToString());
            }

            if (File.Exists("data.txt"))
            {
                try
                {
                    File.AppendAllText("data.txt", sb.ToString());
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            else
            {
                File.WriteAllText("data.txt", sb.ToString());
            }
           
        }

        static void Print(User[] users)
        {
            for (int i = 0; i < users.Length; i++)
            {
                Console.WriteLine(users[i]);
            }
        }

        static User[] Initialization(int size)
        {
             User[] users = new User[size];

            for (int i = 0; i < size; i++)
            {
                Console.Clear();
                Console.Write("Enter last name, name and patronymic ");
                string fioStr = Console.ReadLine();
                Console.Write("Enter birthday (d\\m\\y) ");
                string dateStr = Console.ReadLine();
                var fio = fioStr.Split(" ");
                var date = dateStr.Split("\\");
                users[i] = new User(fio[0], fio[1], fio[2], new DateTime(Convert.ToInt32(date[2]), Convert.ToInt32(date[1]), Convert.ToInt32(date[0])));
            }
            return users;
        }

    }
}
