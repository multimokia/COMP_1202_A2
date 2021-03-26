using System;
using static Crayon.Output;

namespace Library
{
    /// <summary>
    /// Contact object
    ///
    /// PRIVATE PROPERTIES:
    ///     _firstName
    ///     _lastName
    ///     _phone
    ///     _email
    ///     _dayOfBirth
    ///     _monthOfBirth
    ///     _yearOfBirth
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
        string _firstName;
        /// <summary>
        /// Last name
        /// </summary>
        string _lastName;
        /// <summary>
        /// Phone number
        /// </summary>
        string _phone;
        /// <summary>
        /// Email address
        /// </summary>
        string _email;
        /// <summary>
        /// Birthdate day
        /// </summary>
        int _dayOfBirth;
        /// <summary>
        /// Birthmonth
        /// </summary>
        int _monthOfBirth;
        /// <summary>
        /// Birthyear
        /// </summary>
        int _yearOfBirth;

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
        public Contact(string firstName, string lastName, string phoneNumber, string emailAddress, int dayOfBirth, int monthOfBirth, int yearOfBirth)
        {
            _firstName = firstName;
            _lastName = lastName;
            _phone = phoneNumber;
            _email = emailAddress;
            _dayOfBirth = dayOfBirth;
            _monthOfBirth = monthOfBirth;
            _yearOfBirth = yearOfBirth;
        }

        /// <summary>
        /// Firstname getter
        /// </summary>
        /// <returns>First name of the contact instance</returns>
        public string getFirstName()
        {
            return _firstName;
        }

        /// <summary>
        /// Lastname getter
        /// </summary>
        /// <returns>Last name of the contact instance</returns>
        public string getLastName()
        {
            return _lastName;
        }

        /// <summary>
        /// Fullname getter (unsure why this isn't a property, but whatever the customer wants...)
        /// </summary>
        /// <returns>Full name of the contact instance</returns>
        public string getFullName()
        {
            return $"{_firstName} {_lastName}";
        }

        /// <summary>
        /// Phone number getter for the contact
        /// </summary>
        /// <returns>Formatted phone number of the contact instance</returns>
        public string getPhone()
        {
            return $"{_phone.Substring(0, 3)}-{_phone.Substring(3,3)}-{_phone.Substring(6)}";
        }

        /// <summary>
        /// Date of birth getter (also not sure why this isn't a property)
        /// </summary>
        /// <returns>Formatted birthdate for the contact instance</returns>
        public string getDateOfBirth()
        {
            return $"{_dayOfBirth}/{_monthOfBirth}/{_yearOfBirth}";
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
                + $"  Email Address: {_email}\n"
            );
        }
    }
}
