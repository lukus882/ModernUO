using System;
using Server.Network;
using Server.Items;
using Server.Targeting;

namespace Server.Items
{
	public class JinBaoriOfGoodFortune : JinBaori

  {
      public override int ArtifactRarity{ get{ return 13; } }

		public override int InitMinHits{ get{ return 255; } }
		public override int InitMaxHits{ get{ return 255; } }

      
      [Constructible]
		public JinBaoriOfGoodFortune()
		{
          Name = "Jin-Baori Of Good Fortune";
          Hue = 2125;
      Attributes.SpellDamage = 5;
      Attributes.Luck = 150;
		}

		public JinBaoriOfGoodFortune( Serial serial ) : base( serial )
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
