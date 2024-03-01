using ConsoleApp3.IModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp3.Models
{
    internal class PhoneBook : IPhoneBook
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string PhoneNumber { get; set; }

        public override string ToString()
        {
            return Id + " " + Name + " " + PhoneNumber;
        }
    }
}
