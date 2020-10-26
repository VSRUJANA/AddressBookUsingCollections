using System;
using System.Collections.Generic;

namespace Address_Book_Using_Collections
{
    class Program
    {
        static void Main(string[] args)
        {
            AddressBookDict multipleAddressBooks = new AddressBookDict();
            Edit_Add_Delete_AddressBooks operation = new Edit_Add_Delete_AddressBooks();
            AddressBook addressBook = null;
            int choice;
            string addBookName = "";
            Console.WriteLine("Welcome to Address Book System!");
            while (true)
            {
                Console.WriteLine("1.Add Address Book\n2.Edit Or Add Contact in Address Book\n3.View Persons By City\n4.View Persons By State\n5.Exit");
                choice = Convert.ToInt32(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        Console.WriteLine("Enter name of Address Book");
                        addBookName = Console.ReadLine();
                        multipleAddressBooks.AddAddressBook(addBookName);

                        break;
                    case 2:
                        Console.WriteLine("Enter name of Address Book");
                        addBookName = Console.ReadLine();
                        addressBook = multipleAddressBooks.GetAddressBook(addBookName);
                        if (addressBook != null)
                        {
                            operation.EditAddOrDeleteContact(addressBook);

                        }
                        else
                        {
                            Console.WriteLine("No such Adress Book");
                        }
                        break;
                    case 3:
                        Console.WriteLine("Enter City");
                        string city = Console.ReadLine();
                        Console.WriteLine("Contacts in {0} city: ", city);
                        multipleAddressBooks.SetContactByCityDictionary();
                        multipleAddressBooks.ViewPersonsByCity(city);
                        break;
                    case 4:
                        Console.WriteLine("Enter State");
                        string state = Console.ReadLine();
                        Console.WriteLine("Contacts in {0} state: ",state);
                        multipleAddressBooks.SetContactByStateDictionary();
                        multipleAddressBooks.ViewPersonsByState(state);
                        break;
                    case 5:
                        Environment.Exit(0);
                        break;

                    default:
                        Console.WriteLine("Invalid Choice");
                        break;
                }
            }
        }
    }
}
