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
                Console.WriteLine("------------------------------------------------------------------------------------------------------------------------");
                Console.WriteLine("1.Add Address Book\n2.Edit Or Add Contact in Address Book\n3.View Persons By City\n4.View Persons By State\n5.Get count by City\n6.Get count by State\n7.Exit");
                choice = Convert.ToInt32(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        Console.WriteLine("Enter name of Address Book");
                        addBookName = Console.ReadLine();
                        multipleAddressBooks.AddAddressBook(addBookName);

                        break;
                    case 2:
                        Console.WriteLine("Enter name of Address Book you want to modify");
                        addBookName = Console.ReadLine();
                        addressBook = multipleAddressBooks.GetAddressBook(addBookName);
                        if (addressBook != null)
                        {
                            operation.EditAddOrDeleteContact(addBookName,addressBook);

                        }
                        else
                        {
                            Console.WriteLine("No such Adress Book");
                        }
                        break;
                    case 3:
                        Console.WriteLine("Enter City");
                        string city1 = Console.ReadLine();
                        Console.WriteLine("Contacts in {0} city: ", city1);
                        multipleAddressBooks.SetContactByCityDictionary();
                        multipleAddressBooks.ViewPersonsByCity(city1);
                        break;
                    case 4:
                        Console.WriteLine("Enter State");
                        string state1 = Console.ReadLine();
                        Console.WriteLine("Contacts in {0} state: ",state1);
                        multipleAddressBooks.SetContactByStateDictionary();
                        multipleAddressBooks.ViewPersonsByState(state1);
                        break;
                    case 5:
                        Console.WriteLine("Enter City");
                        string city2 = Console.ReadLine();
                        multipleAddressBooks.SetContactByCityDictionary();
                        Console.WriteLine("Number of Contacts in {0} city: {1} ", city2, multipleAddressBooks.CountByCity(city2));
                        break;
                    case 6:
                        Console.WriteLine("Enter State");
                        string state2 = Console.ReadLine();
                        multipleAddressBooks.SetContactByStateDictionary();
                        Console.WriteLine("Number of Contacts in {0} state: {1} ", state2,multipleAddressBooks.CountByState(state2));
                        break;

                    case 7:
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
