using System;
struct User
{
    public string firstName;
    public string lastName;
    public string patronymic;
    public DateTime birthday;

    public User(string firstName, string lastName, string patronymic,DateTime birthday)
    {
        this.firstName = firstName;
        this.lastName = lastName;
        this.patronymic = patronymic;
        this.birthday = new DateTime(birthday.Ticks);
    }
}
namespace App
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }
}
