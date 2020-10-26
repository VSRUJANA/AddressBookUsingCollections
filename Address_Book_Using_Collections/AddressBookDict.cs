using System;
using System.Collections.Generic;
using System.Text;

namespace Address_Book_Using_Collections
{
    public class AddressBookDict
    {
        Dictionary<string, AddressBook> addressBooksCollection = new Dictionary<string, AddressBook>();
        public Dictionary<string, List<Contact>> ContactByCity;
        Dictionary<string, List<Contact>> ContactByState;
        List<string> cities;
        List<string> states;
        public AddressBookDict()
        {
            addressBooksCollection = new Dictionary<string, AddressBook>();
            ContactByCity = new Dictionary<string, List<Contact>>();
            ContactByState = new Dictionary<string, List<Contact>>();
            cities = new List<string>();
            states = new List<string>();

        }
        public void AddAddressBook(string name)
        {
            AddressBook addressBook = new AddressBook();
            if (addressBooksCollection.ContainsKey(name) == false)
            {
                addressBooksCollection.Add(name, addressBook);
                Console.WriteLine("Address Book Added Successfully");
            }
            else
            {
                Console.WriteLine("Address Book Already Exist");
            }

        }
        public AddressBook GetAddressBook(string name)
        {
            if (addressBooksCollection.ContainsKey(name))
            {
                return addressBooksCollection[name];
            }
            return null;
        }
        public void GetDistinctCityAndStateList()
        {
            foreach (var addressBook in addressBooksCollection)
            {
                foreach (var contact in addressBook.Value.contactList)
                {
                    if (cities.Contains(contact.city) == false)
                    {
                        cities.Add(contact.city);
                    }
                    if (states.Contains(contact.state) == false)
                    {
                        states.Add(contact.state);
                    }

                }
            }
        }
        public void SetContactByCityDictionary()
        {
            GetDistinctCityAndStateList();

            foreach (string city in cities)
            {
                List<Contact> contacts = new List<Contact>();
                foreach (var addressBook in addressBooksCollection)
                {
                    contacts.AddRange(addressBook.Value.GetPersonByCityOrState(city));
                }
                if (ContactByCity.ContainsKey(city))
                {
                    ContactByCity[city] = contacts;
                }
                else
                {
                    ContactByCity.Add(city, contacts);
                }
            }

        }
        public void SetContactByStateDictionary()
        {
            GetDistinctCityAndStateList();

            foreach (string state in states)
            {
                List<Contact> contacts = new List<Contact>();
                foreach (var addressBook in addressBooksCollection)
                {
                    contacts.AddRange(addressBook.Value.GetPersonByCityOrState(state));
                }
                if (ContactByState.ContainsKey(state))
                {
                    ContactByState[state] = contacts;
                }
                else
                {
                    ContactByState.Add(state, contacts);
                }
            }

        }
        public void ViewPersonsByCity(string city)
        {
            if (ContactByCity.ContainsKey(city))
            {
                foreach (Contact contact in ContactByCity[city])
                {
                    Console.WriteLine("Name :" + contact.firstName + " " + contact.lastName + "\tAddress :" + contact.address + "\tZipCode :" + contact.zipCode + "\tPhone No :" + contact.phoneNumber + "\tEmail :" + contact.email);
                }
            }
            else
            {
                Console.WriteLine("No Contact found");
            }
        }
        public void ViewPersonsByState(string state)
        {
            if (ContactByState.ContainsKey(state))
            {
                foreach (Contact contact in ContactByState[state])
                {
                    Console.WriteLine("Name :" + contact.firstName + " " + contact.lastName + "\tAddress :" + contact.address + "\tZipCode :" + contact.zipCode + "\tPhone No :" + contact.phoneNumber + "\tEmail :" + contact.email);
                }
            }
            else
            {
                Console.WriteLine("No Contact found");
            }
        }
    }
}

