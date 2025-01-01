using System;
using Server.Items;

namespace Server.Items
{
	public class SmithVendStone : Item
	{
		[Constructible]
		public SmithVendStone() : base( 0xEDC )
		{
			Movable = false;
			Hue = 0x551;
			Name = "Blacksmith Vendor Stone";
		}

		public override void OnDoubleClick( Mobile from )
		{
                  // Bag Cost---3500 Gold
		   	//Item[] Token = from.Backpack.FindItemsByType( typeof( Gold ) );
		   	if ( from.Backpack.ConsumeTotal( typeof( Gold ), 3500 ) )
		{
         	   	SmithVendBag SmithVendBag = new SmithVendBag();
		   	from.AddToBackpack( SmithVendBag );
			from.SendMessage( "3500 gold has been removed from your pack." );
		}
		   	else
		   	{
		   		from.SendMessage( "You do not have enough funds for that." );
		   	}
					
		}

		public SmithVendStone( Serial serial ) : base( serial )
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
