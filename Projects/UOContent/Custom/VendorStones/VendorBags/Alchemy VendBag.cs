using System;
using Server;
using Server.Items;

namespace Server.Items
{
	public class AlchemyVendBag : Bag
	{
		[Constructible]
		public AlchemyVendBag() : this( 1 )
		{
			Movable = true;
			Hue = 0x4EA;
			Name = "Alchemy Vendor Bag";
		}

		[Constructible]
		public AlchemyVendBag( int amount )
		{
			DropItem( new BlackPearl   ( 100 ) );
			DropItem( new Bloodmoss    ( 100 ) );
			DropItem( new Garlic       ( 100 ) );
			DropItem( new Ginseng      ( 100 ) );
			DropItem( new MandrakeRoot ( 100 ) );
			DropItem( new Nightshade   ( 100 ) );
			DropItem( new SulfurousAsh ( 100 ) );
			DropItem( new SpidersSilk  ( 100 ) );
			DropItem( new Bottle       ( 200 ) );
		}

		public AlchemyVendBag( Serial serial ) : base( serial )
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
