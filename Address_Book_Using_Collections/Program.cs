using System;

namespace Address_Book_Using_Collections
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Address Book System!");
            AddressBook AB = new AddressBook();
            Console.WriteLine("Enter the person details to be added in the address book");
            Contact entry=AB.TakeInputForContact();
            AB.AddContact(entry);
            AB.PrintContact();
        }
    }
}
