using System;
using Server.Items;

namespace Server.Items
{
	[FlippableAttribute( 0x2B02, 0x2B03 )]
	public class Pestilence: BaseQuiver
	{		
	

		
		[Constructible]
		public Pestilence() : base( 0x2B02 )
        {
			Name = "Pestilence";
			Hue = 1151;
            		DamageIncrease = 5;
			Attributes.DefendChance = 5;
			Attributes.AttackChance = 5;
			LowerAmmoCost = 5;
			WeightReduction = 50;
		}

		public Pestilence( Serial serial ) : base( serial )
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
