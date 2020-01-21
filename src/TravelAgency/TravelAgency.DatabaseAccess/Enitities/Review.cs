﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace TravelAgency.DatabaseAccess.Entities
{
    internal class Review
    {
        public int Id { get; set; }

        [ForeignKey("User")]
        public int UserId { get; set; }

        public DateTime Date { get; set; }

        public string Header { get; set; }

        public string ImageLink { get; set; }

        public string Text { get; set; }
    }
}
