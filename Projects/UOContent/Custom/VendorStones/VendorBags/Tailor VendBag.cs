using System;
using Server;
using Server.Items;

namespace Server.Items
{
	public class TailorVendBag : Bag
	{
		[Constructible]
		public TailorVendBag() : this( 1 )
		{
			Movable = true;
			Hue = 0x55F;
			Name = "Tailor Vendor Bag";
		}

		[Constructible]
		public TailorVendBag( int amount )
		{
			DropItem( new SewingKit   ( 280 ) );
			DropItem( new Leather     ( 200 ) );
		}
		
		public TailorVendBag( Serial serial ) : base( serial )
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
