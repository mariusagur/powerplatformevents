﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace powerplatformevents.Models
{
    [Serializable]
    public class MessageViewModel
    {
        public string CssClassName { get; set; }
        public string Title { get; set; }
        public string Message { get; set; }
    }
}
