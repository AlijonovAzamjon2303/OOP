using ConsoleApp3.IServices;
using ConsoleApp3.Models;
using ConsoleApp3.Services;

internal class Program
{
    private static void Main(string[] args)
    {
        IPhoneBookServices phoneBookServices = new PhoneBookServices(10);
        string input = "";
        do
        {
            PrintMenu();

            input = Console.ReadLine(); 
            switch(input)
            {
                case "1":
                    {
                        Console.Clear();    
                        phoneBookServices.ReadAllPhoneBooks();
                    }
                    break;
                
                case "2":
                    {
                        Console.Clear();
                        PhoneBook phoneBook = new PhoneBook();
                        Console.Write("Id = "); phoneBook.Id = int.Parse(Console.ReadLine());   
                        Console.Write("Ism va familiya : "); phoneBook.Name = Console.ReadLine();
                        Console.Write("Telefon raqam : "); phoneBook.PhoneNumber = Console.ReadLine();

                        phoneBookServices.AddPhoneBook(phoneBook);
                    }
                    break;
                case "3":
                    {
                        Console.Clear();
                        Console.Write("Id = ");
                        int n = int.Parse(Console.ReadLine());
                        phoneBookServices.ReadById(n);
                    }
                    break;
                case "4":
                    {
                        Console.Clear();
                        Console.Write("O'chirmoqchi bo'lgan mijoz Id = ");
                        int n = int.Parse(Console.ReadLine());

                        phoneBookServices.DeletedById(n);
                    }
                    break;
                case "5":
                    {
                        PhoneBook newPhoneBook = new PhoneBook();
                        Console.Clear();
                        Console.Write("O'zgartirmoqchi bo'lgan mijoz Id = ");
                        int id = int.Parse(Console.ReadLine());

                        Console.WriteLine("Avvalgi ma'lumotlari : ");
                        phoneBookServices.ReadById(id);
                        
                            Console.Write("\nYangi ismi : ");
                            newPhoneBook.Name = Console.ReadLine();
                            Console.Write("\nYangi nomeri : ");
                            newPhoneBook.PhoneNumber = Console.ReadLine();
                            newPhoneBook.Id = id;

                        phoneBookServices.UpdateById(id, newPhoneBook);
                    }
                    break;
            }

        } while (input != "0");
    }

    public static void PrintMenu()
    {
        Console.WriteLine();
        Console.WriteLine("1. ReadAllPhoneBooks");
        Console.WriteLine("2. AddPhoneBook");
        Console.WriteLine("3. ReadById");
        Console.WriteLine("4. DeleteById");
        Console.WriteLine("5. UpdateById");
        Console.WriteLine("0. Dasturni tugatish");
    }
}
