using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace devgalop.learning.esp.solid.provider
{
    public class Provider
    {
        public string Id { get; set; }
        public string Name { get; set; }

        public Provider(string id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}