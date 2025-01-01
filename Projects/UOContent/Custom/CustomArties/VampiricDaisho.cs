using System;
using Server.Network;
using Server.Items;
using Server.Targeting;

namespace Server.Items
{
	public class VampiricDaisho : Daisho

  {
      public override int ArtifactRarity{ get{ return 12; } }

		public override int InitMinHits{ get{ return 255; } }
		public override int InitMaxHits{ get{ return 255; } }

      [Constructible]
		public VampiricDaisho()
		{
          Name = "Vampiric Daisho";
          Hue = 1153;
      WeaponAttributes.HitHarm = 50;
      WeaponAttributes.HitLeechHits = 45;
      WeaponAttributes.HitLeechStam = 20;
      Attributes.LowerManaCost = 5;
      Attributes.NightSight = 1;
      Attributes.SpellChanneling = 1;
     Slayer = SlayerName.BloodDrinking ;
		}

		public VampiricDaisho( Serial serial ) : base( serial )
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
