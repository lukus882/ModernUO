using System;
using Server.Network;
using Server.Items;
using Server.Targeting;

namespace Server.Items
{
	public class ArcanicRobe : Robe

  {
      public override int ArtifactRarity{ get{ return 12; } }
      [Constructible]
		public ArcanicRobe()
		{

          Name = "Arcanic Robe";
          Hue = 1150;
      Attributes.CastRecovery = 1;
      Attributes.CastSpeed = 1;
      Attributes.LowerRegCost = 10;
      Attributes.LowerManaCost = 5;
      Attributes.Luck = 95;
		}

		public ArcanicRobe( Serial serial ) : base( serial )
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
