﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace TravelBlog.Models
{
    public class Experience
    {
        [Key]
        public int ExperienceId { get; set; }
        public string Description { get; set; } 
        public int LocationId { get; set; }
        public virtual Location location { get; set; }
    }
}
