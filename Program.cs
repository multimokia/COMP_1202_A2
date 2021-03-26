using System;
using Library;
using Library.ContactManager;
using GUI.Menu;
using static GUI.InterfaceUtils;
using static Crayon.Output;

namespace assignment02
{
    class Program
    {
        /// <summary>
        /// Contact manager instance
        /// </summary>
        static ContactManager cm = new ContactManager(5);
        static void Main(string[] args)
        {
            MainMenu();
        }

        static void MainMenu()
        {
            //Loop until the user hits 'Exit'
            bool done = false;
            while (!done)
            {
                //Build the menu and give the respective locations to go to
                MenuOption selectedOption = Menu(
                    "What would you like to do? ",
                    new MenuOption[] {
                        new MenuOption("Add Contact", NewContact),
                        new MenuOption("View Contact List", ListContacts),
                        new MenuOption("View a Specific Contact", GetSpecificContactInfo),
                        new MenuOption("Delete Contact", DeleteContact),
                        new MenuOption("Exit", () => {
                            Console.WriteLine(Bright.Green("Thank you for using the contact manager."));
                            done = true;
                        })
                    }
                );

                //Select the option
                selectedOption.Select();
            }
            //Return back to main to exit
            return;
        }

        /// <summary>
        /// New contact delegate method
        ///
        /// Handles prompting the user for contact info
        /// </summary>
        static void NewContact()
        {
            /// <summary>
            /// Internal function for number prompting
            /// </summary>
            /// <param name="prompt">Text to prompt the user with</param>
            /// <param name="predicate">Function for validation</param>
            /// <returns>integer representing the number prompted for</returns>
            int promptForNumber(string prompt, Func<int, bool> predicate)
            {
                int rv = -1;
                do
                {
                    bool parsed = int.TryParse(Prompt(prompt), out rv) && predicate(rv);
                    if (!parsed)
                        { Error("Please enter a valid number"); }

                } while (!predicate(rv));

                return rv;
            }

            //For ux, we mention if we can add contacts or not off the bat
            if (!cm.CanAddNewContact())
            {
                Error($"Sorry... The contact list is full!\n\n{Bright.Black("› Press enter to return to the main menu")}");
                return;
            }

            //Get requied info
            string fName = Prompt("Please enter the person's first name");
            string lName = Prompt("Please enter the person's last name");
            string email = Prompt("Please enter the person's email address");

            //Do a bit of validation on phone number as it must be at least 7 digits for numbers to format correctly
            string phone = Prompt(
                "Please enter the person's phone number",
                x => x.Replace("-", "").Replace(" ", "").Length > 7
            ).Replace("-", "").Replace(" ", "");

            //Prompt for year first so we can see if it's a leap year
            int yearOfBirth = promptForNumber("Please enter the person's birth year", x => x <= DateTime.Now.Year);
            //Now prompt for month so we know how many days
            int monthOfBirth = promptForNumber("Please enter the person's month of birth", x => x > 0 && x < 13);
            //Now handle getting the year
            int dayOfBirth = promptForNumber(
                "Please enter the person's day of birth",
                x => x > 0 && x <= GetAmountOfDaysInMonth(monthOfBirth, yearOfBirth % 4 == 0)
            );

            //Now add contacts
            bool contactAdded = cm.TryAddNewContact(
                new Contact(fName, lName, phone, email, dayOfBirth, monthOfBirth, yearOfBirth)
            );

            //Just in case something goes wrong, we should write the appropriate message
            if (contactAdded)
                { Success($"Contact added successfully!\n\n{Bright.Black("› Press enter to return to the main menu")}"); }
            else
                { Error($"An error occurred and the contact couldn't be added.\n\n{Bright.Black("› Press enter to return to the main menu")}"); }

            return;
        }

        /// <summary>
        /// Gets specific contact info for a specific contact and prints it out if the contact exists
        ///
        /// If it doesn't, an error message is shown to the user
        /// </summary>
        static void GetSpecificContactInfo()
        {
            string name = Prompt("Please enter the full name of the contact you wish to find.", allowEmpty: true);
            Contact? specifiedContact = cm.FindContact(name);

            //Since a null contact means it wasn't found, let's raise that as an error with the user and return to the main menu
            if (specifiedContact is null)
            {
                Error("Contact does not exist.");
                return;
            }

            //Otherwise we found it and let's print its info
            Console.WriteLine(Bold(specifiedContact.getInfo()));
            Console.WriteLine(Bright.Black("\nPress enter to return to the main menu."));
            Console.ReadLine();
        }

        /// <summary>
        /// Promps the user for a contact and deletes it if it exists.
        ///
        /// If it doesn't, an error message is shown to the user
        /// </summary>
        static void DeleteContact()
        {
            string name = Prompt("Please enter the full name for the contact you wish to delete.", allowEmpty: true);
            //Try and delete the contact
            bool deleted = cm.TryDeleteContact(name);

            //Check if it was deleted. If it wasn't, we know the contact doesn't exit
            if (!deleted)
                { Error("Contact does not exist."); }
            else
                { Success("Contact deleted successfully"); }

            return;
        }

        /// <summary>
        /// Lists all contacts in the contactmanager
        /// </summary>
        static void ListContacts()
        {
            Console.WriteLine(Bold(Underline("List of contacts:")));

            //We don't want to loop for no reason, so if we have no contacts, we simply return here
            if (!cm.HasContacts)
            {
                Console.WriteLine("\tNo contacts.");
                Console.WriteLine(Bright.Black("\nPress enter to return to the main menu."));
                Console.ReadLine();
                return;
            }

            foreach (Contact contact in cm.Contacts)
            {
                if (!(contact is null))
                    { Console.WriteLine($"\t{Bold(contact.getFullName())}"); }
            }

            Console.WriteLine(Bright.Black("\nPress enter to return to the main menu."));
            Console.ReadLine();
            return;
        }

        /// <summary>
        /// Utility method, gets the number of days in the month provided (accounts for leap years)
        /// </summary>
        /// <param name="month">month to get the amount of days for</param>
        /// <param name="isLeapYear">whether or not it's a leap year</param>
        /// <returns>Amount of days in month</returns>
        static int GetAmountOfDaysInMonth(int month, bool isLeapYear)
        {
            int AmtDays = 0;
            switch (month)
            {
                case 1:
                    AmtDays = 31;
                    break;
                case 2:
                    AmtDays = 28;
                    if (isLeapYear)
                        AmtDays++;
                    break;
                case 3:
                    AmtDays = 31;
                    break;
                case 4:
                    AmtDays = 30;
                    break;
                case 5:
                    AmtDays = 31;
                    break;
                case 6:
                    AmtDays = 30;
                    break;
                case 7:
                    AmtDays = 31;
                    break;
                case 8:
                    AmtDays = 31;
                    break;
                case 9:
                    AmtDays = 30;
                    break;
                case 10:
                    AmtDays = 31;
                    break;
                case 11:
                    AmtDays = 30;
                    break;
                case 12:
                    AmtDays = 31;
                    break;
            }

            return AmtDays;
        }
    }
}
