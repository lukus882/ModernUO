// Created with UO Weapon Generator
// Created On: 22/12/2024 21:14:11
// By: lukus

using System;
using Server;

namespace Server.Items
{
    public class Staff : Mace
    {
        public override int ArtifactRarity{ get{ return 100; } }
        public override int InitMinHits{ get{ return 1000; } }
        public override int InitMaxHits{ get{ return 1000; } }

        [Constructible]
        public Staff()
        {
            Name = "OwnerStaff";
            Hue = 1151;
            LootType = LootType.Blessed;
            Slayer = SlayerName.Repond;
            Attributes.SpellChanneling = 1;
            Attributes.NightSight = 1;
            Attributes.BonusStr = 100;
            Attributes.BonusInt = 100;
            Attributes.BonusDex = 100;
            Attributes.BonusHits = 100;
            Attributes.BonusStam = 100;
            Attributes.BonusMana = 100;
            Attributes.RegenHits = 100;
            Attributes.RegenStam = 100;
            WeaponAttributes.UseBestSkill = 1;
            WeaponAttributes.HitLeechHits = 100;
            WeaponAttributes.HitLeechStam = 100;
            WeaponAttributes.HitLeechMana = 100;
            Attributes.AttackChance = 100;
            Attributes.DefendChance = 100;
            Attributes.WeaponDamage = 1000;
            Attributes.WeaponSpeed = 1000;
            Attributes.Luck = 1000;
            Attributes.ReflectPhysical = 100;
            Attributes.EnhancePotions = 100;
            Attributes.SpellDamage = 100;
            WeaponAttributes.HitPhysicalArea = 100;
            WeaponAttributes.HitColdArea = 100;
            WeaponAttributes.HitFireArea = 100;
            WeaponAttributes.HitEnergyArea = 100;
            WeaponAttributes.HitPoisonArea = 100;
            WeaponAttributes.ResistPhysicalBonus = 100;
            WeaponAttributes.ResistColdBonus = 100;
            WeaponAttributes.ResistFireBonus = 100;
            WeaponAttributes.ResistEnergyBonus = 100;
            WeaponAttributes.ResistPoisonBonus = 100;
            WeaponAttributes.DurabilityBonus = 1000;
            WeaponAttributes.SelfRepair = 100;
            Attributes.CastSpeed = 100;
            Attributes.CastRecovery = 100;
            Attributes.LowerManaCost = 100;
            Attributes.LowerRegCost = 100;
            WeaponAttributes.HitLowerAttack = 100;
            WeaponAttributes.HitLowerDefend = 100;
            WeaponAttributes.HitHarm = 100;
            WeaponAttributes.HitFireball = 100;
            WeaponAttributes.HitLightning = 100;
            WeaponAttributes.HitDispel = 100;
        }

        public Staff(Serial serial) : base( serial )
        {
        }

        public override void Serialize( IGenericWriter writer )
        {
            base.Serialize( writer );
            writer.Write( (int) 0 );
        }

        public override void Deserialize(IGenericReader reader)
        {
            base.Deserialize( reader );
            int version = reader.ReadInt();
        }
    } // End Class
} // End Namespace
