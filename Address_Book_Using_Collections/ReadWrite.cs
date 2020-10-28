using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Globalization;
using System.IO;
using System.Linq;
using CsvHelper;

namespace Address_Book_Using_Collections
{
    public class ReadWrite
    {
        static string path = @"C:\Users\sajju2002\AddressBookUsingCollections\Address_Book_Using_Collections\Utilites\ContactFile.txt";

        public static void ClearFile()
        {
            File.WriteAllText(path, string.Empty);
        }

        public static bool FileExists(string filePath)
        {
            if (File.Exists(filePath))
                return true;
            return false;
        }

        // Reading file using StreamReader
        public static void ReadUsingStreamReader()
        {
            if (File.Exists(path))
            {
                using (StreamReader streamReader = File.OpenText(path))
                {
                    String fileData = "";
                    while ((fileData = streamReader.ReadLine()) != null)
                        Console.WriteLine((fileData));
                }
            }
            else
            {
                Console.WriteLine("No file");
            }
        }

        //Writing file using StreamReader
        public static void WriteUsingStreamWriter(string addressBookName,List<Contact> contactList)
        {
            if (File.Exists(path))
            {
                using (StreamWriter streamWriter = File.AppendText(path))
                {
                    streamWriter.WriteLine("Contacts in "+ addressBookName+ " address book : ");
                    foreach (Contact contact in contactList)
                    {
                        streamWriter.WriteLine("Name :" + contact.firstName + " " + contact.lastName + "\tAddress :" + contact.address + ", " + contact.city + ", " + contact.state + "-" + contact.zipCode + "\tPhone No :" + contact.phoneNumber + "\tEmail :" + contact.email + "\n");
                    }
                    streamWriter.Close();
                }
            }
            else
            {
                Console.WriteLine("File Does Not Exist");
            }
        }

        static string csvPath = @"C:\Users\sajju2002\AddressBookUsingCollections\Address_Book_Using_Collections\Utilites\ContactCSVFile.csv";
            
        public static void WriteToCSV(List<Contact> contactList)
        {
            if (FileExists(csvPath))
            {
                using (var writer = new StreamWriter(csvPath))
                using (var csvWrite = new CsvWriter(writer, CultureInfo.InvariantCulture))
                {
                    csvWrite.WriteRecords(contactList);
                }
                Console.WriteLine("Records Added to ContactCSVFile Successfully");
            }
            else
            {
                Console.WriteLine("File does not exist");
            }
        }
        public static void ReadFromCSV()
        {
            if (FileExists(csvPath))
            {
                using (var reader = new StreamReader(csvPath))
                using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
                {
                    var records = csv.GetRecords<Contact>().ToList();
                    Console.WriteLine("Data reading from ContactCSVFile done successfully");
                    foreach (Contact contact in records)
                    {
                        Console.Write("Name :" + contact.firstName + " " + contact.lastName + "\tAddress :" + contact.address + ", " + contact.city + ", " + contact.state + "-" + contact.zipCode + "\tPhone No :" + contact.phoneNumber + "\tEmail :" + contact.email + "\n");
                    }
                }
            }
            else
            {
                Console.WriteLine("No such file found");
            }
        }
    }
}
