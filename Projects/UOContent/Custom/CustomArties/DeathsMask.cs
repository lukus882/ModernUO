using System;
using Server.Network;
using Server.Items;
using Server.Targeting;

namespace Server.Items
{
	public class DeathsMask : BoneHelm
  {
public override int ArtifactRarity{ get{ return 15; } }

		public override int InitMinHits{ get{ return 255; } }
		public override int InitMaxHits{ get{ return 255; } }

		public override int BaseColdResistance{ get{ return 11; } } 
		public override int BaseEnergyResistance{ get{ return 3; } } 
		public override int BasePhysicalResistance{ get{ return 15; } } 
		public override int BasePoisonResistance{ get{ return 12; } } 
		public override int BaseFireResistance{ get{ return 12; } } 
      
      [Constructible]
		public DeathsMask()
		{
          Name = "Death's Mask";
          Hue = 2518;
      ArmorAttributes.MageArmor = 1;
      Attributes.BonusInt = 5;
      Attributes.DefendChance = 10;
      Attributes.LowerManaCost = 10;
      Attributes.NightSight = 1;
      Attributes.SpellDamage = 15;
  		}

		public DeathsMask( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( IGenericWriter writer )
		{
			base.Serialize( writer );
			writer.Write( (int) 0 ); // version
		}

		public override void Deserialize( IGenericReader reader )
		{
			base.Deserialize( reader );

			int version = reader.ReadInt();
		}
	}
}
