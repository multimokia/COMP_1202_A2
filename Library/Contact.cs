using System;
using static Crayon.Output;

namespace Library
{
    /// <summary>
    /// Contact object
    ///
    /// PRIVATE PROPERTIES:
    ///     firstName
    ///     lastName
    ///     phone
    ///     email
    ///     dayOfBirth
    ///     monthOfBirth
    ///     yearOfBirth
    ///
    /// METHODS:
    ///     getFirstName
    ///     getLastName
    ///     getPhone
    ///     getDateOfBirth
    ///     getInfo
    /// </summary>
    public class Contact
    {
        /// <summary>
        /// First name
        /// </summary>
        string firstName;
        /// <summary>
        /// Last name
        /// </summary>
        string lastName;
        /// <summary>
        /// Phone number
        /// </summary>
        string phone;
        /// <summary>
        /// Email address
        /// </summary>
        string email;
        /// <summary>
        /// Birthdate day
        /// </summary>
        int dayOfBirth;
        /// <summary>
        /// Birthmonth
        /// </summary>
        int monthOfBirth;
        /// <summary>
        /// Birthyear
        /// </summary>
        int yearOfBirth;

        /// <summary>
        /// Contact constructor
        /// </summary>
        /// <param name="firstName">First name of the contact</param>
        /// <param name="lastName">Last name of the contact</param>
        /// <param name="phoneNumber">Phone number of the contact</param>
        /// <param name="emailAddress">Email address of the contact</param>
        /// <param name="dayOfBirth">Birthday day of the contact</param>
        /// <param name="monthOfBirth">Birthmonth of the contact</param>
        /// <param name="yearOfBirth">Birthyear of the contact</param>
        public Contact(
            string firstname,
            string lastname,
            string phonenumber,
            string emailaddress,
            int dayofbirth,
            int monthofbirth,
            int yearofbirth
        )
        {
            firstName = firstname;
            lastName = lastname;
            phone = phonenumber;
            email = emailaddress;
            dayOfBirth = dayofbirth;
            monthOfBirth = monthofbirth;
            yearOfBirth = yearofbirth;
        }

        /// <summary>
        /// Firstname getter
        /// </summary>
        /// <returns>First name of the contact instance</returns>
        public string getFirstName()
        {
            return firstName;
        }

        /// <summary>
        /// Lastname getter
        /// </summary>
        /// <returns>Last name of the contact instance</returns>
        public string getLastName()
        {
            return lastName;
        }

        /// <summary>
        /// Fullname getter (unsure why this isn't a property, but whatever the customer wants...)
        /// </summary>
        /// <returns>Full name of the contact instance</returns>
        public string getFullName()
        {
            return $"{firstName} {lastName}";
        }

        /// <summary>
        /// Phone number getter for the contact
        /// </summary>
        /// <returns>Formatted phone number of the contact instance</returns>
        public string getPhone()
        {
            return $"{phone.Substring(0, 3)}-{phone.Substring(3,3)}-{phone.Substring(6)}";
        }

        /// <summary>
        /// Date of birth getter (also not sure why this isn't a property)
        /// </summary>
        /// <returns>Formatted birthdate for the contact instance</returns>
        public string getDateOfBirth()
        {
            return $"{dayOfBirth}/{monthOfBirth}/{yearOfBirth}";
        }

        /// <summary>
        /// Essentially a ToString equivalent
        /// </summary>
        /// <returns>All contact info formatted to print to ui</returns>
        public string getInfo()
        {
            return (
                $"Name: {getFullName()}\n"
                + $"Birthdate: {getDateOfBirth()} (dd/mm/yyyy)\n\n"
                + $"{Underline("Contact Info:")}\n"
                + $"  Phone Number: {getPhone()}\n"
                + $"  Email Address: {email}\n"
            );
        }
    }
}
