using System;
using System.Collections.Generic;

namespace dotnetapp.Models
{
    public partial class Library
    {
        public int LibraryId { get; set; }
        public string Name { get; set; } = null!;
        public string Address { get; set; } = null!;
        public string City { get; set; } = null!;
        public string State { get; set; } = null!;
        public string ZipCode { get; set; } = null!;
        public string PhoneNumber { get; set; } = null!;
    }
}
