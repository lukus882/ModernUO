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
	public class NecroVendBag : Bag
	{
		[Constructible]
		public NecroVendBag() : this( 100 )
		{
			Movable = true;
			Hue = 0x83A;
			Name = "Necro Vendor Bag";
		}

		[Constructible]
		public NecroVendBag( int amount )
		{
			DropItem( new BatWing     ( amount ) );
			DropItem( new GraveDust   ( amount ) );
			DropItem( new DaemonBlood ( amount ) );
			DropItem( new NoxCrystal  ( amount ) );
			DropItem( new PigIron     ( amount ) );
		}

		public NecroVendBag( Serial serial ) : base( serial )
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
