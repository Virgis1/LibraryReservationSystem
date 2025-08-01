﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LibraryReservationSystem.Business
{
    public class Book
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public string Description { get; set; }
        public int Year { get; set; }
        public bool IsInStock { get; set; }
    }
}