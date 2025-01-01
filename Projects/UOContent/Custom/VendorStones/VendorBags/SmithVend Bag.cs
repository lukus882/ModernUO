using System; 
using Server; 
using Server.Items;

namespace Server.Items
{ 
	public class SmithVendBag : Bag 
	{ 
		[Constructible] 
		public SmithVendBag() : this( 100 ) 
		{ 
			Movable = true;
			Hue = 0x551;
			Name = "Blacksmith Vendor Bag";
		} 

		[Constructible] 
		public SmithVendBag( int amount ) 
		{ 
			DropItem( new DullCopperIngot   ( amount ) ); 
			DropItem( new ShadowIronIngot   ( amount ) ); 
			DropItem( new CopperIngot       ( amount ) ); 
			DropItem( new BronzeIngot       ( amount ) ); 
			DropItem( new IronIngot         ( amount ) ); 
		} 

		public SmithVendBag( Serial serial ) : base( serial ) 
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
