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
	}
}
