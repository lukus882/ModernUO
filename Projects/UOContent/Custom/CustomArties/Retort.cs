using System;
using Server.Network;
using Server.Items;
using Server.Targeting;

namespace Server.Items
{
	public class Retort : WarFork
  {
public override int ArtifactRarity{ get{ return 12; } }

		public override int InitMinHits{ get{ return 255; } }
		public override int InitMaxHits{ get{ return 255; } }

      [Constructible]
		public Retort()
		{
          Name = "Retort";
          Hue = 910;
      WeaponAttributes.HitLeechHits = 20;
      WeaponAttributes.HitLeechStam = 35;
      WeaponAttributes.HitLowerDefend = 30;
      WeaponAttributes.SelfRepair = 3;
      Attributes.BonusDex = 5;
      Attributes.WeaponDamage = 50;
      Attributes.WeaponSpeed = 25;
		}

		public Retort( Serial serial ) : base( serial )
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
