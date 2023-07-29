using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var attackingUnit = new Unit(50, 80, Faction.dark, true);
            var defendingUnit = new Unit(40, 50, Faction.light, false);

            var damageDone = attackingUnit.CauseDamage(defendingUnit);

            Console.WriteLine($"УРА! было нанесено {damageDone} урона");
            Console.ReadLine();
        }
    }
}