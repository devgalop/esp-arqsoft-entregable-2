using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace devgalop.learning.esp.solid.patient
{
    public class Patient
    {
        public string Id { get; set; }
        public string Name { get; set; }
        
        public Patient(string id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}