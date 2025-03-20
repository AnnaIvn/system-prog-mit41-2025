using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShipTreeView
{
    internal class Ship
    {
        public string Name { get; set; } // all class properties
        public int Capacity { get; set; }
        public double Speed { get; set; }
        public List<string> CrewMembers { get; set; } 

        public Ship()                   // default constructor
        {
            Name = "Unnamed";
            Capacity = 0;
            Speed = 0.0;
            CrewMembers = new List<string>();
        }

        public Ship(string name, int capacity, double speed, List<string> crew)   // parameterized constructor
        {
            Name = name;
            Capacity = capacity;
            Speed = speed;
            CrewMembers = crew;
        }

        public void AddCrewMember(string member)          // method to add a crew member
        {
            CrewMembers.Add(member);
        }

        public void RemoveCrewMember(string member)       // method to remove a crew member
        {
            CrewMembers.Remove(member);
        }

        public string GetInfo()                           // method to return ship details as a string
        {
            return $"Ship: {Name}, Capacity: {Capacity}, Speed: {Speed} knots, Crew Members: {CrewMembers.Count}";
        }
    }
}
