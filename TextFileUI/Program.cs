// See https://aka.ms/new-console-template for more information
using DataAccessLibrary;
using DataAccessLibrary.Models;
using Microsoft.Extensions.Configuration;

namespace TextFileUi {

    class Program {

        private static IConfiguration _config;
        private static string textFile;
        private static TextFileDataAccess db = new TextFileDataAccess();

        static void Main(string[] args) {

            InitalizeConfiguration();

            textFile = _config.GetValue<string>("TextFile");

            ContactModel user1 = new ContactModel();
            user1.FirstName = "Michelle";
            user1.LastName = "Jose";
            user1.EmailAddresses.Add("emailaddress1@gmail.com");
            user1.EmailAddresses.Add("michellllllll@gmail.com");
            user1.PhoneNumbers.Add("555-2323");
            user1.PhoneNumbers.Add("444-9999");

            ContactModel user2 = new ContactModel();
            user2.FirstName = "Samuel";
            user2.LastName = "Jose";
            user2.EmailAddresses.Add("sjose18@gmail.com");
            user2.EmailAddresses.Add("heybob@gmail.com");
            user2.PhoneNumbers.Add("675-3421");
            user2.PhoneNumbers.Add("999-1212");

            //CreateContact(user1);
            //CreateContact(user2);
            //GetAllContacts();

            //UpdateContactFirstName("Marie");
            //GetAllContacts();
            //RemovePhoneNumberFromUser("2693520288");

            RemoveUser();
            GetAllContacts();

            Console.WriteLine("Done Processing");

            Console.ReadLine();
        }

        private static void RemoveUser()
        {
            var contacts = db.ReadAllRecords(textFile);
            contacts.RemoveAt(0);
            db.WriteAllRecords(contacts, textFile);
        }

        public static void RemovePhoneNumberFromUser(string phoneNumber)
        {
            var contacts = db.ReadAllRecords(textFile);
            contacts[0].PhoneNumbers.Remove(phoneNumber);
            db.WriteAllRecords(contacts, textFile);
        }

        private static void UpdateContactFirstName(string firstName)
        {
            var contacts = db.ReadAllRecords(textFile);
            contacts[0].FirstName = firstName;
            db.WriteAllRecords(contacts, textFile);
        }

        private static void GetAllContacts()
        {
            var contacts = db.ReadAllRecords(textFile);

            foreach (var contact in contacts)
            {
                Console.WriteLine($"{contact.FirstName} {contact.LastName}");
            }
        }

        private static void CreateContact(ContactModel contact)
        {
            var contacts = db.ReadAllRecords(textFile);
            contacts.Add(contact);
            db.WriteAllRecords(contacts, textFile);

        }

        static void InitalizeConfiguration()
        {

            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json");

            _config = builder.Build();

        }
    }
}