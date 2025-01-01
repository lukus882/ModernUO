using System;
using Server;
namespace Server.Items
{
    public class DarkLordsPitchfork : Pitchfork
    {
        public override int InitMinHits { get { return 225; } }
        public override int InitMaxHits { get { return 225; } }
public override int ArtifactRarity{ get{ return 14; } }
        [Constructible]
        public DarkLordsPitchfork()
        {
            Name = "The Dark Lord's PitchFork";
            Hue = 1157;
            Attributes.WeaponDamage = 50;
            WeaponAttributes.HitFireArea = 50;
            WeaponAttributes.HitFireball = 50;
            WeaponAttributes.ResistFireBonus = 5;
            Attributes.SpellChanneling = 1;
            Attributes.WeaponSpeed = -25;
        }
        public override void GetDamageTypes( Mobile wielder, out int phys, out int fire, out int cold, out int pois, out int nrgy, out int chaos, out int direct )
        {
            phys = 0;
            cold = 0;
            fire = 100;
            nrgy = 0;
            pois = 0;
            chaos = 0;
            direct = 0;
        }
        public DarkLordsPitchfork( Serial serial )
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
