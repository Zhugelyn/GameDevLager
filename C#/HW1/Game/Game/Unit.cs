using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    internal class Unit
    {
        private float BaseDamage { get; set; }
        private float BasicProtection { get; set; }
        private Faction Faction { get; set; }
        private bool IsBerserk { get; set; }  

        public Unit (uint baseDamage, uint basicProtection, Faction faction, bool isBerserk)
        {
            this.BaseDamage = baseDamage; 
            this.BasicProtection = basicProtection;
            this.Faction = faction;
            this.IsBerserk = isBerserk;
        }

        public float CauseDamage(Unit defendingUnit)
        {
            return СalculateTotalIncomingDamage(defendingUnit);
        }

        private float СalculateTotalIncomingDamage(Unit defendingUnit)
        {
            var damage = CalculateDamage(BaseDamage, IsBerserk) *
                DetermineFactionBonusDamageRatio(Faction, defendingUnit.Faction);
            var protection = CalculateProtection(defendingUnit.BasicProtection, defendingUnit.IsBerserk);

            return damage * protection;
        }

        private float DetermineFactionBonusDamageRatio(Faction attackingUnitFaction, Faction defendingUnitFaction)
        {
            if (attackingUnitFaction == Faction.Gray || defendingUnitFaction == Faction.Gray)
                return 1;
            if (attackingUnitFaction == defendingUnitFaction)
                return 0.5f;
            if (attackingUnitFaction != defendingUnitFaction)
                return 2;

            return 0.00f;
        }

        private float CalculateDamage(float baseDamage, bool isBerserk)
        {
            return baseDamage = isBerserk ? baseDamage * 2 : baseDamage;
        }

        private float CalculateProtection(float basicProtection, bool isBerserk)
        {
            basicProtection = isBerserk ? (basicProtection * 0.2f) : basicProtection;
            return (100 - basicProtection) / 100;
        }

    }
}
