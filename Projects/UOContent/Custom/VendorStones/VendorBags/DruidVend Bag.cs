/*
Special thanks to Ryan.
With RunUO we now have the ability to become our own Richard Garriott.
All Spells System created by x-SirSly-x, Admin of Land of Obsidian.
All Spells System 4.0 created & supported by Lucid Nagual, Admin of The Conjuring.
All Spells System 5.0 created by A_li_N.
    _________________________________
 -=(_)_______________________________)=-
   /   .   .   . ____  . ___      _/
  /~ /    /   / /     / /   )2005 /
 (~ (____(___/ (____ / /___/     (
  \ ----------------------------- \
   \     lucidnagual@gmail.com     \
    \_     ===================      \
     \   -Admin of "The Conjuring"-  \
      \_     ===================     ~\
       )       All Spells System       )
      /~      Version [5].0.1        _/
    _/_______________________________/
 -=(_)_______________________________)=-
 */
using System;
using Server;
using Server.Items;


namespace Server.Items
{
	public class DruidVendBag : Bag
	{

		[Constructible]
		public DruidVendBag() : this( 100 ) 
		{ 
			Movable = true; 
			Hue = 0x4F4; 
			Name = "Druid Vendor Bag";
		}

		[Constructible]
		public DruidVendBag( int amount )
		{
			//DropItem( new PetrifiedWood   ( amount ) );
			//DropItem( new DestroyingAngel ( amount ) );
			//DropItem( new SpringWater     ( amount ) );
		}

		public DruidVendBag( Serial serial ) : base( serial )
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
 
    
