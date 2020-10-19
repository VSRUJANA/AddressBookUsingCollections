using System;
using System.Collections.Generic;
using System.Transactions;

namespace Address_Book_Using_Collections
{
    class Program
    {
        public static Dictionary<string, AddressBook> addressBooks;
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Address Book System!");
            addressBooks = new Dictionary<string, AddressBook>();
            InitialiseHomeAddressBook();
            var quit = false;
            while (!quit)
            {
                Console.WriteLine("Enter your choice 1.Create New Address Book 2.Update existing Address Book 3.Search person in city 4.search person in state 5.Quit");
                int choice = Convert.ToInt32(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        Console.Write("Enter a name for your address book :");
                        string newAddressBookName = Console.ReadLine();
                        if (addressBooks.ContainsKey(newAddressBookName))
                        {
                            Console.WriteLine("Duplicate address book names are not allowed!");
                            break;
                        }
                        else
                        {
                            addressBooks.Add(newAddressBookName, null);
                            addressBooks[newAddressBookName] = InitializeAddressBook(newAddressBookName, new AddressBook());
                            break;
                        }

                    case 2:
                        if (addressBooks.Count == 0)
                        {
                            Console.WriteLine("There are no existing address books");
                            break;
                        }
                        else
                        {
                            Console.WriteLine("The existing Address books are :");
                            foreach (string key in addressBooks.Keys)
                            {
                                Console.WriteLine(key);
                            }
                            Console.WriteLine("Enter the Address Book name you want to update");
                            string addressBookName = Console.ReadLine();
                            if (addressBooks.ContainsKey(addressBookName))
                            {
                                AddressBook existingAddressBook = addressBooks[addressBookName];
                                var updatedAB = InitializeAddressBook(addressBookName, addressBooks[addressBookName]);
                                addressBooks[addressBookName] = updatedAB;
                                break;
                            }
                            else
                            {
                                Console.WriteLine("Entered address book name doesn't exist!");
                                break;
                            }
                        }

                        case 3:
                        Console.WriteLine("Enter a city you want to search");
                        string city = Console.ReadLine();
                        AddressBook.DisplayContactByCity(city);
                        break;
                        case 4:
                        Console.WriteLine("Enter a state you want to search");
                        string state = Console.ReadLine();
                        AddressBook.DisplayContactByState(state);
                        break;
                    case 5:
                        quit = true;
                        break;

                    default:
                        Console.WriteLine("Invalid Input");
                        break;
                }
            }
        }
        public static void InitialiseHomeAddressBook()
        {
            //Add some sample contacts to Home address book

            AddressBook AB = new AddressBook();
            AB.AddContact(new Contact("Devrath", "Dixit", "APHB colony", "Hyderabad", "Telangana", "543234", "1234567890", "devrath@gmail.com"));
            AB.AddContact(new Contact("Anant", "B", "Jubilee Hills", "Hyderabad", "Telangana", "787676", "9876543436", "Anant@gmail.com"));
            AB.AddContact(new Contact("srujana", "Valavala", "KPHB colony", "Vizag", "Andhra Pradesh", "534260", "9876543219", "srujanaV@gmail.com"));
            AB.AddContact(new Contact("Sherlock", "Holmes", "Bakers street", "London", "U.K", "54894", "90909090", "Holmes@gmail.com"));
            AB.AddContact(new Contact("Tony", "Stark", "Stark Tower", "Manhattan", "New York", "10001", "111111", "Stark@gmail.com"));
            var ABHome = AB;
            addressBooks.Add("Home", ABHome);
        }
        public static AddressBook InitializeAddressBook(string addressBookName, AddressBook AB)
        {
            bool var = true;
            while (var)
            {
                Console.WriteLine("Enter your choice  1.Add Contact 2.Edit Contact 3.Delete Contact 4.Display Address book 5.Exit ");
                int choice = Convert.ToInt32(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        Console.WriteLine("Enter the person details to be added in the address book");
                        Contact entry = AB.TakeInputForContact();
                        AB.AddContact(entry);
                        if(entry!=null)
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
                        Console.WriteLine("Enter the first name of the contact to be deleted");
                        string fname = Console.ReadLine();
                        Console.WriteLine("Enter the last name of the contact to be deleted");
                        string lname = Console.ReadLine();
                        AB.DeleteContact(fname, lname);
                        break;

                    case 4:
                        AB.PrintAddressBook();
                        break;

                    default:
                        var = false;
                        break;
                }
            }
            return AB;
        }
    }
}
