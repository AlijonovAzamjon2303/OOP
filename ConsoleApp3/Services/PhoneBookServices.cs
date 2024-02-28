using ConsoleApp3.Models;

namespace ConsoleApp3.Services
{
    internal class PhoneBookServices
    {
        PhoneBook[] phoneBooks;

        int count = 0;
        public int Count 
        {
           get => count;
        }
        private int id = 1;
        public PhoneBookServices(int n)
        {
            phoneBooks = new PhoneBook[n];  
        }

        public void AddPhoneBook(PhoneBook phoneBook)
        {
            count++;
            phoneBook.Id = id++;
            for(int iteration = 0; iteration < phoneBooks.Length; iteration++)
            {
                if (phoneBooks[iteration] == null) 
                {
                    phoneBooks[iteration] = phoneBook;
                    break;
                }
            }
        }

        public void ReadAllPhoneBooks()
        {
            for(int i = 0; i < phoneBooks.Length; i++)
            {
                if (phoneBooks[i] != null)
                {
                    Console.WriteLine($"{phoneBooks[i].Name} : {phoneBooks[i].PhoneNumber}");    
                }
            }
        }

        public void ReadById(int id)
        {
            Console.Clear();
            for(int i = 0; i < phoneBooks.Length; i++)
            {
                if (phoneBooks[i] != null && phoneBooks[i].Id == id)
                {  
                    Console.WriteLine($"{phoneBooks[i].Name} : {phoneBooks[i].PhoneNumber}");
                }
            }
        }

        public void DeletedById(int id)
        {
            bool isDeleted = false;
            for(int i = 0; i < phoneBooks.Length; i++) 
            {
                if (phoneBooks[i] != null && phoneBooks[i].Id == id)
                {
                    phoneBooks[i] = null;
                    isDeleted = true;   
                    count--;
                }
            }

            if(isDeleted)
            {
                Console.WriteLine($"{id} idli mijoz o'chirildi!");
            }
        }

        public void UpdateById(int id, PhoneBook newPhoneBook)
        {
            for(int i = 0; i < phoneBooks.Length; i++)
            {
                if (phoneBooks[i] != null && phoneBooks[i].Id == id)
                {
                    phoneBooks[i] = newPhoneBook;
                }
            }
        }

        public void PrintMenu()
        {
            Console.WriteLine();
            Console.WriteLine("1. ReadAllPhoneBooks");
            Console.WriteLine("2. AddPhoneBook");
            Console.WriteLine("3. ReadById");
            Console.WriteLine("4. DeleteById");
            Console.WriteLine("5. UpdateById");
            Console.WriteLine("0. Dasturni tugatish");
        }

        public bool Contains(int id)
        {
            for(int i = 0;i < phoneBooks.Length;i++)
            {
                if (phoneBooks[i] != null && phoneBooks[i].Id == id)
                {
                    return true;
                }
            }

            return false;   
        }
    }
}