using System;
using Server;
using Server.Items;

namespace Server.Items
{
	public class ScribeVendBag : Bag
	{
		[Constructible]
		public ScribeVendBag() : this( 1 )
		{
			Movable = true;
			Hue = 0x846;
			Name = "Inscription Vendor Bag";
		}

		[Constructible]
		public ScribeVendBag( int amount )
		{
			DropItem( new BlackPearl   ( 100 ) );
			DropItem( new Bloodmoss    ( 100 ) );
			DropItem( new Garlic       ( 100 ) );
			DropItem( new Ginseng      ( 100 ) );
			DropItem( new MandrakeRoot ( 100 ) );
			DropItem( new Nightshade   ( 100 ) );
			DropItem( new SulfurousAsh ( 100 ) );
			DropItem( new SpidersSilk  ( 100 ) );
			DropItem( new BlankScroll  ( 200 ) );
		}

		public ScribeVendBag( Serial serial ) : base( serial )
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
