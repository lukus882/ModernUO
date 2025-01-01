using System;
using Server.Network;
using Server.Items;
using Server.Targeting;

namespace Server.Items
{
	public class FortunateBlades : Daisho
  {
public override int ArtifactRarity{ get{ return 15; } }

		public override int InitMinHits{ get{ return 255; } }
		public override int InitMaxHits{ get{ return 255; } }

      [Constructible]
		public FortunateBlades()
		{
          Name = "Fortunate Blades";
          Hue = 2213;
      WeaponAttributes.MageWeapon = 30;
	Attributes.SpellChanneling = 1;
	Attributes.CastSpeed = 1;
      WeaponAttributes.SelfRepair = 5;
      Attributes.Luck = 200;
      Attributes.RegenMana = 5;
      Attributes.SpellDamage = 15;
		}

		public FortunateBlades( Serial serial ) : base( serial )
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
