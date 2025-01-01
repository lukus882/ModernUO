using System;
using Server.Items;

namespace Server.Items
{
	public class TailorVendStone : Item
	{
		[Constructible]
		public TailorVendStone() : base( 0xEDC )
		{
			Movable = false;
			Hue = 0x55F;
			Name = "Tailor Vendor Stone";
		}

		public override void OnDoubleClick( Mobile from )
		{
                  // Bag Cost---1235 Gold
		   	//Item[] Token = from.Backpack.FindItemsByType( typeof( Gold ) );
		   	if ( from.Backpack.ConsumeTotal( typeof( Gold ), 1235 ) )
		{
         	   	TailorVendBag TailorVendBag = new TailorVendBag();
		   	from.AddToBackpack( TailorVendBag );
			from.SendMessage( "1235 gold has been removed from your pack." );
		}
		   	else
		   	{
		   		from.SendMessage( "You do not have enough funds for that." );
		   	}
					
		}

		public TailorVendStone( Serial serial ) : base( serial )
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
