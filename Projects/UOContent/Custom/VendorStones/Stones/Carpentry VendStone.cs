using System;
using Server.Items;

namespace Server.Items
{
	public class CarpentryVendStone : Item
	{
		[Constructible]
		public CarpentryVendStone() : base( 0xEDC )
		{
			Movable = false;
			Hue = 0x83E;
			Name = "Carpentry Vendor Stone";
		}

		public override void OnDoubleClick( Mobile from )
		{
                  // Bag Cost---1235 Gold
		   	//Item[] Token = from.Backpack.FindItemsByType( typeof( Gold ) );
		   	if ( from.Backpack.ConsumeTotal( typeof( Gold ), 1235 ) )
		{
         	   	CarpentryVendBag CarpentryVendBag = new CarpentryVendBag();
		   	from.AddToBackpack( CarpentryVendBag );
			from.SendMessage( "1235 gold has been removed from your pack." );
		}
		   	else
		   	{
		   		from.SendMessage( "You do not have enough funds for that." );
		   	}
					
		}

		public CarpentryVendStone( Serial serial ) : base( serial )
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
