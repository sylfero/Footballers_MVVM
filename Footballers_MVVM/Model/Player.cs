using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Footballers_MVVM.Model
{
    class Player
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public int Weight { get; set; }

        public Player() { }

        public Player(string firstName, string lastName, int age, int weight)
        {
            FirstName = firstName;
            LastName = lastName;
            Age = age;
            Weight = weight;
        }

        public override string ToString()
        {
            return $"Imię: {FirstName}  Nazwisko: {LastName}  Wiek: {Age}  Waga: {Weight}";
        }
    }
}
