using Game.Api.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Api.Adventurers
{
    public static class AdventurerNameGenerator
    {
        private readonly static List<string> MaleNames = EnumHelper.GetEnumNames<MaleName>();
        private readonly static List<string> FemaleNames = EnumHelper.GetEnumNames<FemaleName>();
        private readonly static List<string> Surname = EnumHelper.GetEnumNames<AdventurerSurname>();

        private readonly static Dictionary<Gender, List<string>> Names = new Dictionary<Gender, List<string>>() { { Gender.Male, MaleNames }, { Gender.Female, FemaleNames } };
        
        public static (string name, string surname) FullNameGenerate(Gender gender)
        {
            var rng = new Random();
            var name = Names[gender][rng.Next(0, Names[gender].Count)];
            var surname = Surname[rng.Next(0, Surname.Count)];
            return (name, surname);
        }

    }
}
