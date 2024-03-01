using ConsoleApp3.IModels;
using ConsoleApp3.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp3.IServices
{
    internal interface IPhoneBookServices
    {
        void AddPhoneBook(IPhoneBook phoneBook);

        void ReadAllPhoneBooks();

        void ReadById(int id);

        void DeletedById(int id);

        void UpdateById(int id, IPhoneBook newPhoneBook);

        bool Contains(int id);
    }
}
