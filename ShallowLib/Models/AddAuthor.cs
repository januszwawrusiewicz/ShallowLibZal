﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShallowLibAPI.Models
{
    public class AddAuthor
    {

      
            public Guid Id { get; set; }

            public bool IsDone { get; set; }
            public string Title { get; set; }

            public DateTimeOffset? DueAt { get; set; }

            public string OwnerId { get; set; }

      

    }
}