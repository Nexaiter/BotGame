using Game.Api.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Api.Adventurers
{
    public class Adventurer
    {
        private static uint nextId = 1;
        public uint AdventurerId { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public Gender Gender { get; set; }
        public Race Race { get; set; }

        public int Health { get; set; } = 100;
        public int Damage { get; set; } = 5;
        public int Strength { get; set; } = 10;
        public int Magic { get; set; } = 10;
        public int Endurance { get; set; } = 10;
        public int Agility { get; set; } = 10;
        public int TotalStats { get; set; } = 40;

        public RarityType Rarity { get; set; }

        public Adventurer(Gender gender, Race race, RarityType rarity)
        {
            AdventurerId = Interlocked.Increment(ref nextId);
            Race = race;
            Gender = gender;
            Rarity = rarity;
            (string name, string surname) = AdventurerNameGenerator.FullNameGenerate(gender);
            Name = name;
            Surname = surname;
        }
    }
}
