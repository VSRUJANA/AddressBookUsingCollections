using System;

namespace Address_Book_Using_Collections
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Address Book System!");
            AddressBook AB = new AddressBook();
            //Adding some sample contacts in address book);
            AB.AddContact(new Contact("Devrath", "D", "APHB colony", "Hyderabad", "Telangana", "543234", "1234567890", "devrath@gmail.com"));
            AB.AddContact(new Contact("Tony", "Stark", "Stark Tower", "Manhattan", "New York", "10001", "111111", "Stark@gmail.com"));
            AB.AddContact(new Contact("srujana", "V", "KPHB colony", "Vizag", "Andhra Pradesh", "534260", "9876543219", "srujanaV@gmail.com"));
            bool var = true;
            while (var)
            {
                Console.WriteLine("Enter your choice  1.Add Contact 2.Edit Contact 3.Display Address book 4.Exit ");
                int choice = Convert.ToInt32(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        Console.WriteLine("Enter the person details to be added in the address book");
                        Contact entry = AB.TakeInputForContact();
                        AB.AddContact(entry);
                        Console.WriteLine("Contact added successfully!");
                        break;
                    case 2:
                        Console.WriteLine("Enter the first name of the contact to be edited");
                        string fName = Console.ReadLine();
                        Console.WriteLine("Enter the last name of the contact to be edited");
                        string lName = Console.ReadLine();
                        AB.EditContact(fName, lName);
                        break;

                    case 3:
                        AB.PrintAddressBook();
                        break;

                    default:
                        var = false;
                        Console.WriteLine("Press any key to exit");
                        break;
                }
            }
        }
    }
}
