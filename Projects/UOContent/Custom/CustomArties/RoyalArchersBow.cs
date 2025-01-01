using System;
using Server;
namespace Server.Items
{
    public class RoyalArchersBow : Bow
    {
        public override int InitMinHits { get { return 255; } }
        public override int InitMaxHits { get { return 255; } }
public override int ArtifactRarity{ get{ return 15; } }

        [Constructible]
        public RoyalArchersBow()
        {
            Name = "Royal Archer's Bow";
            Hue = 2101;
            WeaponAttributes.HitDispel = 25;
            WeaponAttributes.HitLightning = 35;
            WeaponAttributes.HitLowerAttack = 25;
            WeaponAttributes.SelfRepair = 10;
            Attributes.BonusHits = 15;
            Attributes.ReflectPhysical = 25;
            Attributes.SpellChanneling = 1;
            Attributes.WeaponSpeed = 20;
            Attributes.WeaponDamage = 30;
        }
        public override void GetDamageTypes( Mobile wielder, out int phys, out int fire, out int cold, out int pois, out int nrgy, out int chaos, out int direct )
        {
            phys = 50;
            cold = 10;
            fire = 10;
            nrgy = 10;
            pois = 20;
            chaos = 0;
            direct = 0;
        }
        public RoyalArchersBow( Serial serial )
            : base( serial )
        {
        }
        public override void Serialize( IGenericWriter writer )
        {
            base.Serialize( writer );
            writer.Write( (int)0 );
        }
        public override void Deserialize( IGenericReader reader )
        {
            base.Deserialize( reader );
            int version = reader.ReadInt();
        }
    }
}
