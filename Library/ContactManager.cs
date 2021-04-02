using System;
using System.Linq;

namespace Library.ContactManager
{
    /// <summary>
    /// ContactManager class
    ///
    /// PRIVATE PROPERTY:
    ///     _contacts
    ///
    /// PROPERTIES:
    ///     HasContacts
    ///     Contacts
    ///
    /// METHODS:
    ///     CanAddNewContact
    ///     TryAddNewContact
    ///     HasContacts
    ///     FindContact
    ///     TryDeleteContact
    /// </summary>
    public class ContactManager
    {
        /// <summary>
        /// Internal Contact array
        /// </summary>
        Contact[] _contacts;

        /// <summary>
        /// Whether or not the ContactManager has contacts
        /// </summary>
        /// <value></value>
        public bool HasContacts {
            get {
                return !(_contacts.FirstOrDefault(x => x != null) is null);
            }
        }

        /// <summary>
        /// All registered contacts
        /// </summary>
        /// <value>Array of all registered contacts (no empty spaces)</value>
        public Contact[] Contacts {
            get {
                return _contacts.Where(x => x != null).ToArray();
            }
        }

        /// <summary>
        /// ContactManager constructor
        /// </summary>
        /// <param name="maxContacts">Maximum number of contacts that can be held by the contact manager</param>
        public ContactManager(int maxContacts)
        {
            _contacts = new Contact[maxContacts];
        }

        /// <summary>
        /// Checks if we can add a new contact by checking if any index in the contacts array is null
        /// </summary>
        /// <returns>boolean - true if there's room to add more contacts, false otherwise</returns>
        public bool CanAddNewContact()
        {
            return Array.Exists(_contacts, x => x == null);
        }

        /// <summary>
        /// Tries to add a new contact
        /// </summary>
        /// <param name="contact">Contact object to add</param>
        /// <returns>boolean - true if the contact was added, false otherwise</returns>
        public bool TryAddNewContact(Contact contact)
        {
            for (int i=0; i < _contacts.Length; i++)
            {
                if (_contacts[i] == null)
                {
                    _contacts[i] = contact;
                    return true;
                }
            }

            return false;
        }

        /// <summary>
        /// Contact lookup function by full name
        /// </summary>
        /// <param name="fullname">Full name of the contact to lookup</param>
        /// <returns>Contact object representing the contact with the name provided, or null if not found</returns>
        public Contact? FindContact(string fullname)
        {
            if (!HasContacts)
                { return null; }

            return Contacts.FirstOrDefault(x => x.getFullName() == fullname);
        }

        public bool TryDeleteContact(string fullname)
        {
            if (!HasContacts)
                { return false; }

            int _contactsLength = _contacts.Length;

            //Filter out the contact we wish to remove
            _contacts = _contacts.Where(x => x is null || x.getFullName() != fullname).ToArray();

            //Check if any were deleted, return false if not
            if (_contacts.Length == _contactsLength)
                { return false; }

            //Otherwise we need to add the space back and return success
            Array.Resize(ref _contacts, _contactsLength);
            return true;
        }
    }
}
