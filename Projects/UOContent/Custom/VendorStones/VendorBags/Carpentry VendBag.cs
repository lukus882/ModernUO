using System;
using Server;
using Server.Items;

namespace Server.Items
{
	public class CarpentryVendBag : Bag
	{
		[Constructible]
		public CarpentryVendBag() : this( 1 )
		{
			Movable = true;
			Hue = 0x83E;
			Name = "Carpentry Vendor Bag";
		}

		[Constructible]
		public CarpentryVendBag( int amount )
		{
			DropItem( new Hammer    ( 280 ) );
			DropItem( new Log       ( 200 ) );
		}
		
		public CarpentryVendBag( Serial serial ) : base( serial )
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
