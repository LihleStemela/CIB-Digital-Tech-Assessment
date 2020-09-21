using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PhonebookAPI.Models
{
    public class Phonebook
    {
        public int PhoneBookId { get; set; }
        public string Name { get; set; }
        public string Entries { get; set; }

    }

    public class Entry
    {
        public int EntryId { get; set; }

        public string Name { get; set; }
        public string PhoneNumber { get; set; }
    }
}
