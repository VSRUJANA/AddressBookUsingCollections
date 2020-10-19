using System;
using System.Collections.Generic;
using System.Runtime.Versioning;
using System.Text;
using System.Threading;

namespace Address_Book_Using_Collections
{
    public class AddressBook
    {
        public static List<Contact> contactList;
        public AddressBook()
        {
            contactList = new List<Contact>();
        }

        //Method to take user input from console
        public Contact TakeInputForContact()
        {
            Console.WriteLine("First Name");
            string fName = Console.ReadLine();
            Console.WriteLine("Last Name");
            string lName = Console.ReadLine();
            Contact find = FindContact(fName, lName);
            if (find != null)
                return null;
            else
            {
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
            if (newEntry == null)
            {
                Console.WriteLine("Duplicate entries of same person are not allowed!");
            }
            else
            {
                contactList.Add(newEntry);
            }
        }

        //Method to edit an existing contact in Address book
        public void EditContact(string fName, string lName)
        {
            Contact oldContact = FindContact(fName, lName);
            if (oldContact != null)
            {
                Console.WriteLine("The existing contact details are ");
                Console.WriteLine("Name      : " + oldContact.firstName + " " + oldContact.lastName);
                Console.WriteLine("Address   : " + oldContact.address + ", " + oldContact.city + ", " + oldContact.state + "-" + oldContact.zipCode);
                Console.WriteLine("Phone No. : " + oldContact.phoneNumber);
                Console.WriteLine("Email id  : " + oldContact.email);
                Console.WriteLine("Enter new Details ");
                Console.Write("New Address :");
                oldContact.address = Console.ReadLine();
                Console.Write("New City :");
                oldContact.city = Console.ReadLine();
                Console.Write("New State :");
                oldContact.state = Console.ReadLine();
                Console.Write("New ZipCode :");
                oldContact.zipCode = Console.ReadLine();
                Console.Write("New PhoneNumber :");
                oldContact.phoneNumber = Console.ReadLine();
                Console.Write("New Email Id :");
                oldContact.email = Console.ReadLine();
                Console.WriteLine("Details updated succesfully for " + fName + " " + lName);
            }
            else
            {
                Console.WriteLine("There is no contact with name {0} in the address book", fName + " " + lName);
            }
        }

        //Method to delete a contact from address book
        public void DeleteContact(string fName, string lName)
        {
            Contact find = FindContact(fName, lName);
            if (find == null)
            {
                Console.WriteLine("No Record found for {0} in the address book", fName + " " + lName);
            }
            else
            {
                contactList.Remove(find);
                Console.WriteLine("Contact Deleted successfully!");
            }
        }

        //Method to print all contacts in Address book
        public void PrintAddressBook()
        {
            if (AddressBook.contactList.Count != 0)
            {
                Console.WriteLine("Contacts in the Address Book:");
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

        public static void DisplayContactByState(string state)
        {
            int count = 0;
            foreach (var item in contactList)
            {
                if (item.state == state)
                {
                    Console.WriteLine("-------------------------------------------------------------");
                    Display(item);
                    count++;
                }
            }
            if (count == 0)
            {
                Console.WriteLine("No contacts found in {0} state", state);
            }
        }

        public static void DisplayContactByCity(string city)
        {
            int count = 0;
            foreach (var item in contactList)
            {
                if (item.city == city)
                {
                    Console.WriteLine("-------------------------------------------------------------");
                    Display(item);
                }
            }
            if (count == 0)
            {
                Console.WriteLine("No contacts found in {0} city", city);
            }
        }
        public static void Display(Contact person)
        {
            Console.WriteLine("Name      : " + person.firstName + " " + person.lastName);
            Console.WriteLine("Address   : " + person.address + ", " + person.city + ", " + person.state + "-" + person.zipCode);
            Console.WriteLine("Phone No. : " + person.phoneNumber);
            Console.WriteLine("Email id  : " + person.email);
        }
    }
}

