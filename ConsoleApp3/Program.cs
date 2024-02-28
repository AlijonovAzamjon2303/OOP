using ConsoleApp3.Models;
using ConsoleApp3.Services;
using System.Runtime.CompilerServices;

internal class Program
{
    private static void Main(string[] args)
    {
        PhoneBookServices phoneBookServices = new PhoneBookServices(10);
        string input = "";
        do
        {
            phoneBookServices.PrintMenu();

            input = Console.ReadLine(); 
            switch(input)
            {
                case "1":
                    {
                        Console.Clear();    
                        phoneBookServices.ReadAllPhoneBooks();
                        if(phoneBookServices.Count == 0)
                        {
                            Console.WriteLine("Bizda hali ro'yxat shakllanmagan!");
                        }
                    }
                    break;
                
                case "2":
                    {
                        Console.Clear();
                        PhoneBook phoneBook = new PhoneBook();
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
                        
                        if(phoneBookServices.Contains(n))
                        {
                            phoneBookServices.ReadById(n);
                        }
                        else
                        {
                            Console.WriteLine($"{n} id li mijoz topilmadi!");
                        }
                    }
                    break;
                case "4":
                    {
                        Console.Clear();
                        Console.Write("O'chirmoqchi bo'lgan mijoz Id = ");
                        int n = int.Parse(Console.ReadLine());

                        if(phoneBookServices.Contains(n))
                        {
                            phoneBookServices.DeletedById(n);
                        }
                        else
                        {
                            Console.WriteLine($"{n} id li mijoz topilmadi!");
                        }
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
                        
                        if(phoneBookServices.Contains(id))
                        {
                            Console.Write("\nYangi ismi : ");
                            newPhoneBook.Name = Console.ReadLine();
                            Console.Write("\nYangi nomeri : ");
                            newPhoneBook.PhoneNumber = Console.ReadLine();
                            newPhoneBook.Id = id;
                        }
                        else
                        {
                            Console.WriteLine($"{id} idli mijoz topilmadi!");
                        }

                        phoneBookServices.UpdateById(id, newPhoneBook);
                    }
                    break;
            }

        } while (input != "0");
    }
}
