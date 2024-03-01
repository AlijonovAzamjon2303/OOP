using ConsoleApp3.IModels;
using ConsoleApp3.IServices;
using ConsoleApp3.Models;
using System.Net;

namespace ConsoleApp3.Services
{
    internal class PhoneBookServices : IPhoneBookServices
    {
        string path = "C:/Users/alijo/Desktop/New/base.txt";


        IPhoneBook[] phoneBooks;

        public PhoneBookServices(int n)
        {
            phoneBooks = new PhoneBook[n];  
        }

        public void AddPhoneBook(IPhoneBook phoneBook)
        {
            string data = phoneBook.ToString();
            string allData = File.ReadAllText(path);
            if(allData != "") 
            {
                File.WriteAllText(path, allData + "\n" + data);
            }
            else
            {
                File.WriteAllText(path, data);
            }
        }

        public void ReadAllPhoneBooks()
        {
            string [] allLines = File.ReadAllLines(path);
            foreach (string line in allLines)
            {
                Console.WriteLine(line);
            }
        }

        public void ReadById(int id)
        {
            Console.Clear();
            string [] allLines = File.ReadAllLines(path);
            for(int i = 0; i < allLines.Length; i++)
            {
                PhoneBook phoneBook = new PhoneBook();
                string[] data = allLines[i].Split();
                phoneBook.Id = int.Parse(data[0]);
                phoneBook.Name = data[1];
                phoneBook.PhoneNumber = data[2];

                if(phoneBook.Id == id)
                {
                    Console.WriteLine(allLines[i]);
                }
            }
        }

        public void DeletedById(int id)
        {
            string []allLines = File.ReadAllLines(path);
            File.WriteAllText(path, String.Empty);
            for(int i = 0; i < allLines.Length;i++)
            {
                string []data = allLines[i].Split();
                PhoneBook phoneBook = new PhoneBook();
                phoneBook.Id = int.Parse(data[0]);
                phoneBook.Name = data[1];
                phoneBook.PhoneNumber = data[2];

                if (phoneBook.Id != id)
                {
                    this.AddPhoneBook(phoneBook);    
                }
            }
        }

        public void UpdateById(int id, IPhoneBook newPhoneBook)
        {
            string[] allLines = File.ReadAllLines(path);
            for (int i = 0; i < allLines.Length; i++)
            {
                string[] data = allLines[i].Split();
                if (int.Parse(data[0]) == id)
                {
                    allLines[i] = newPhoneBook.ToString();
                    break;
                }
            }
            File.WriteAllText(path, string.Empty);
            File.WriteAllLines(path, allLines);
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