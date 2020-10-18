using System;

namespace Address_Book_Using_Collections
{
	public class Contact
	{
		// Properties Declaration
		public string firstName { get; set; }
		public string lastName { get; set; }
		public string address { get; set; }
		public string city { get; set; }
		public string state { get; set; }
		public string zipCode { get; set; }
		public string phoneNumber { get; set; }
		public string email { get; set; }

		// Constructor Declaration
		public Contact(string fName, string lName, string address, string city, string state, string zip, string phNo, string eId)
		{
			this.firstName = fName;
			this.lastName = lName;
			this.address = address;
			this.city = city;
			this.state = state;
			this.zipCode = zip;
			this.phoneNumber = phNo;
			this.email = eId;
		}
	}
}
