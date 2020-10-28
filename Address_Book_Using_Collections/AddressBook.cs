using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace Address_Book_Using_Collections
{
    public class AddressBook
    {
        public List<Contact> contactList;

        public AddressBook()
        {
            contactList = new List<Contact>();
        }

        public string AddContact(string firstName, string lastName, string address, string city, string state, string zipCode, string phoneNo, string eMail)
        {
            if (CheckName(firstName, lastName) == false)
            {
                Contact contact = new Contact(firstName, lastName, address, city, state, zipCode, phoneNo, eMail);
                contactList.Add(contact);
                return "Details Added Successfully";
            }
            return "Name already exists";
        }

        public void EditContact(string firstName, string lastName, string address, string city, string state, string zipCode, string phoneNo, string eMail)
        {
            foreach (Contact c in contactList)
            {
                if (c.firstName.Equals(firstName))
                {
                    c.lastName = lastName;
                    c.address = address;
                    c.city = city;
                    c.state = state;
                    c.zipCode = zipCode;
                    c.phoneNumber = phoneNo;
                    c.email = eMail;
                    return;
                }
            }
        }

        public void RemoveContact(string firstName, string lastName)
        {
            foreach (Contact c in contactList)
            {
                if (c.firstName.Equals(firstName) && c.lastName.Equals(lastName))
                {
                    contactList.Remove(c);

                    return;
                }
            }
        }

        public bool CheckName(string firstName, string lastName)
        {
            foreach (Contact c in contactList)
            {
                if (c.firstName.Equals(firstName) && c.lastName.Equals(lastName))
                {
                    return true;
                }
            }
            return false;
        }

        public List<Contact> GetPersonByCityOrState(string cityOrState)
        {
            List<Contact> contact = new List<Contact>();
            foreach (Contact c in contactList)
            {
                if (c.city.Equals(cityOrState) || c.state.Equals(cityOrState))
                    contact.Add(c);

            }
            return contact;
        }

        public void SortByName()
        {
            contactList.Sort((contact1, contact2) => contact1.firstName.CompareTo(contact2.firstName));
            foreach (Contact contact in contactList)
            {
                Console.WriteLine("Name :" + contact.firstName + " " + contact.lastName + "\tAddress :" + contact.address + ", " + contact.city + ", " + contact.state + "-" + contact.zipCode + "\tPhone No :" + contact.phoneNumber + "\tEmail :" + contact.email);
            }
        }

        public void SortByCity()
        {
            contactList.Sort((contact1, contact2) => contact1.city.CompareTo(contact2.city));
            foreach (Contact contact in contactList)
            {
                Console.WriteLine("Name :" + contact.firstName + " " + contact.lastName + "\tAddress :" + contact.address + ", " + contact.city + ", " + contact.state + "-" + contact.zipCode + "\tPhone No :" + contact.phoneNumber + "\tEmail :" + contact.email);
            }

        }

        public void SortByState()
        {
            contactList.Sort((contact1, contact2) => contact1.state.CompareTo(contact2.state));
            foreach (Contact contact in contactList)
            {
                Console.WriteLine("Name :" + contact.firstName + " " + contact.lastName + "\tAddress :" + contact.address + ", " + contact.city + ", " + contact.state + "-" + contact.zipCode + "\tPhone No :" + contact.phoneNumber + "\tEmail :" + contact.email);
            }

        }

        public void SortByZipCode()
        {
            contactList.Sort((contact1, contact2) => contact1.zipCode.CompareTo(contact2.zipCode));
            foreach (Contact contact in contactList)
            {
                Console.WriteLine("Name :" + contact.firstName + " " + contact.lastName + "\tAddress :" + contact.address + ", " + contact.city + ", " + contact.state + "-" + contact.zipCode + "\tPhone No :" + contact.phoneNumber + "\tEmail :" + contact.email);
            }

        }
    }
}

