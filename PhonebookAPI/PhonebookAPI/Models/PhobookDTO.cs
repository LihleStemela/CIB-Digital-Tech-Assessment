using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PhonebookAPI.Models
{
    public class PhobookDTO
    {
        public int PhoneBookId { get; set; }
        public string Name { get; set; }
        public List<Entry> Entries { get; set; }

    }
}
