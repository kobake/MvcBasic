﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace MvcBasic.Models
{
    public class Member
    {
        public int Id { get; set; }

        [DisplayName("氏名")]
        public string Name { get; set; }
        public string Email { get; set; }
        public DateTime Birth { get; set; }
        public bool Married { get; set; }
        public string Memo { get; set; }
    }
}
