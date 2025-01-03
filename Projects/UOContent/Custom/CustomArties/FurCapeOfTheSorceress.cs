using System;
using Server.Network;
using Server.Items;
using Server.Targeting;

namespace Server.Items
{
	public class FurCapeOfTheSorceress : FurCape
  {
public override int ArtifactRarity{ get{ return 16; } }


      
      [Constructible]
		public FurCapeOfTheSorceress()
		{
          Name = "Fur Cape Of The Sorceress";
          Hue = 1266;
      Attributes.BonusInt = 5;
      Attributes.BonusMana = 10;
      Attributes.LowerManaCost = 5;
      Attributes.LowerRegCost = 10;
      Attributes.SpellDamage = 15;
      Attributes.BonusMana = 10;
		}

		public FurCapeOfTheSorceress( Serial serial ) : base( serial )
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
