using System;
using System.Collections.Generic;
using System.Text;

namespace Address_Book_Using_Collections
{
    public class AddressBook
    {
        public static List<Contact> contactList;
        public AddressBook()
        {
            contactList = new List<Contact>();
        }

        //Method to take user input from Console
        public Contact TakeInputForContact()
        {
            Console.WriteLine("First Name");
            string fName = Console.ReadLine();
            Console.WriteLine("Last Name");
            string lName = Console.ReadLine();
            Console.WriteLine("Address");
            string address = Console.ReadLine();
            Console.WriteLine("City");
            string city = Console.ReadLine();
            Console.WriteLine("State");
            string state = Console.ReadLine();
            Console.WriteLine("Zip code");
            string zipCode = Console.ReadLine();
            Console.WriteLine("Phone Number");
            string phNumber = Console.ReadLine();
            Console.WriteLine("Email");
            string email = Console.ReadLine();
            Contact newContact = new Contact(fName, lName, address, city, state, zipCode, phNumber, email);
            return newContact;
        }

        //Method to find whether contact is present in AddressBook
        public Contact FindContact(string fname, string lname)
        {
            Contact contact = contactList.Find((person) => person.firstName == fname && person.lastName == lname);
            return contact;
        }

        //Method to add contact to Address book
        public void AddContact(Contact newEntry)
        {
            Contact result = FindContact(newEntry.firstName, newEntry.lastName);
            if (result == null)
            {
                contactList.Add(newEntry);
                Console.WriteLine("Contact added successfully!");
            }
            else
            {
                Console.WriteLine("Contact already exists!");
            }
        }

        //Method to print contacts in Address book
        public void PrintContact()
        {
            if (AddressBook.contactList.Count != 0)
            {
                foreach (Contact person in contactList)
                {
                    Console.WriteLine("-------------------------------------------------------------");
                    Console.WriteLine("Name      : " + person.firstName + " " + person.lastName);
                    Console.WriteLine("Address   : " + person.address + ", " + person.city + ", " + person.state + "-" + person.zipCode);
                    Console.WriteLine("Phone No. : " + person.phoneNumber);
                    Console.WriteLine("Email id  : " + person.email);
                }
            }
            else
            {
                Console.WriteLine("There are no contacts in the address book!");
            }
        }
    }
}
