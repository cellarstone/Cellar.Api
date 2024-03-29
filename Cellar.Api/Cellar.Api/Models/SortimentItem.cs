﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cellar.Api.Models
{
    public class SortimentItem
    {
        public string Id { get; set; }

        public string Name { get; set; }

        [JsonIgnore]
        public string Path { get; set; }

        public List<SortimentItem> ChildItems { get; set; }
    }
}
