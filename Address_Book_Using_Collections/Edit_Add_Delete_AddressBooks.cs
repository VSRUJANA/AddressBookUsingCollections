using System;
using System.Collections.Generic;
using System.Text;

namespace Address_Book_Using_Collections
{
   public class Edit_Add_Delete_AddressBooks
    {
        public void EditAddOrDeleteContact(string addressBookName,AddressBook addressBook)
        {
            int choice = 0;
            string[] details;
            bool flag = true;

            while (flag)
            {
                Console.WriteLine("1.Add Contact\n2.Edit Contact\n3.Remove a contact\n4.Sort By Name\n5.Sort By City\n6.Sort By State\n7.Sort By ZipCode\n8.Write To File\n9.Read from File\n10.Write to CSV\n11.Read From CSV\n12.Exit");
                choice = Convert.ToInt32(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        Console.WriteLine("Enter the details separated by comma");
                        Console.WriteLine("First Name, Last Name, Address, City, State, ZipCode,Phone No, Email");
                        details = Console.ReadLine().Split(",");
                        string message = addressBook.AddContact(details[0], details[1], details[2], details[3], details[4], details[5], details[6], details[7]);
                        Console.WriteLine(message);
                        break;
                    case 2:
                        Console.WriteLine("Enter the first name of the contact to be edited");
                        string fname = Console.ReadLine();
                        Console.WriteLine("Enter the last name of the contact to be edited");
                        string lname = Console.ReadLine();
                        if (addressBook.CheckName(fname, lname) == true)
                        {
                            Console.WriteLine("Enter the following details separated by comma");
                            Console.WriteLine("FirstName,LastName,Address, City, State, ZipCode, Phone No, Email");
                            details = Console.ReadLine().Split(",");
                            addressBook.EditContact(details[0], details[1], details[2], details[3], details[4], details[5], details[6], details[7]);
                            Console.WriteLine("Details edited successfully");
                        }
                        else
                        {
                            Console.WriteLine("No such contact found");
                        }
                        break;
                    case 3:
                        Console.WriteLine("Enter the first name of the contact to be deleted");
                        string fName = Console.ReadLine();
                        Console.WriteLine("Enter the last name of the contact to be deleted");
                        string lName = Console.ReadLine();
                        if (addressBook.CheckName(fName, lName) == true)
                        {
                            addressBook.RemoveContact(fName, lName);
                            Console.WriteLine("Contact Removed Successfully");
                        }
                        else
                        {
                            Console.WriteLine("No such contact found");
                        }
                        break;
                    case 4:
                        addressBook.SortByName();
                        break;
                    case 5:
                        addressBook.SortByCity();
                        break;
                    case 6:
                        addressBook.SortByState();
                        break;
                    case 7:
                        addressBook.SortByZipCode();
                        break;
                    case 8:
                        ReadWrite.WriteUsingStreamWriter(addressBookName,addressBook.contactList);
                        Console.WriteLine("Written to file successfully");
                        break; 
                    case 9:
                        ReadWrite.ReadUsingStreamReader();
                        break;
                    case 10:
                        ReadWrite.WriteToCSV(addressBook.contactList);

                        break;
                    case 11:
                        ReadWrite.ReadFromCSV();
                        break;
                    case 12:
                        flag = false;
                        break;
                    default:
                        Console.WriteLine("Invalid choice");
                        break;
                }

            }
        }
    }
}
