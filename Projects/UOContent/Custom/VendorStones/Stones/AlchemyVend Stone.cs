using System;
using Server.Items;

namespace Server.Items
{
	public class AlchemyVendStone : Item
	{
		[Constructible]
		public AlchemyVendStone() : base( 0xEDC )
		{
			Movable = false;
			Hue = 0x4EA;
			Name = "Alchemy Vendor Stone";
		}

		public override void OnDoubleClick( Mobile from )
		{
            if (!from.Player)
                return;
            // Bag Cost---3800 Gold
            from.Backpack.FindItemsByType(typeof(Gold));
            if ( from.Backpack.ConsumeTotal( typeof( Gold ), 3800 ) )
		{
         	      AlchemyVendBag AlchemyVendBag = new AlchemyVendBag();
		      from.AddToBackpack( AlchemyVendBag );
			from.SendMessage( "3800 gold has been removed from your pack." );
		}
		   	else
		      {
		   		from.SendMessage( "You do not have enough funds for that." );
		   	}
					
		}

		public AlchemyVendStone( Serial serial ) : base( serial )
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
