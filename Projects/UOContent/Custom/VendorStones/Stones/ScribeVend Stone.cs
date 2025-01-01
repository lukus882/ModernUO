using System;
using Server.Items;

namespace Server.Items
{
	public class ScribeVendStone : Item
	{
		[Constructible]
		public ScribeVendStone() : base( 0xEDC )
		{
			Movable = false;
			Hue = 0x846;
			Name = "Inscription Vendor Stone";
		}

		public override void OnDoubleClick( Mobile from )
		{
                  // Bag Cost---3800 Gold
		   	//Item[] Token = from.Backpack.FindItemsByType( typeof( Gold ) );
		   	if ( from.Backpack.ConsumeTotal( typeof( Gold ), 3800 ) )
		{
         	   	ScribeVendBag ScribeVendBag = new ScribeVendBag();
		   	from.AddToBackpack( ScribeVendBag );
			from.SendMessage( "3800 gold has been removed from your pack." );
		}
		   	else
		   	{
		   		from.SendMessage( "You do not have enough funds for that." );
		   	}
					
		}

		public ScribeVendStone( Serial serial ) : base( serial )
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
