using System;
using Server;

namespace Server.Items
{
    public class EternalFlame : MetalShield
    {
        public override int BaseFireResistance{ get{ return 15; } }
        public override int ArtifactRarity{ get{ return 15; } }
        public override int InitMinHits{ get{ return 255; } }
        public override int InitMaxHits{ get{ return 255; } }

        [Constructible]
        public EternalFlame()
        {
            Name = "Eternal Flame";
			ItemID = 2597;
            Hue = Utility.RandomList( 1355, 1356, 1357, 1358, 1359, 1360, 1161, 1260 );
            StrRequirement = 45;
            Attributes.SpellChanneling = 1;
            Attributes.NightSight = 1;
            Attributes.AttackChance = 5;
            Attributes.DefendChance = 10;
			Attributes.ReflectPhysical = 15;
            Attributes.Luck = 150;
            ArmorAttributes.SelfRepair = 3;
			Attributes.NightSight = 1;
            
        }

        public EternalFlame(Serial serial) : base( serial )
        {
        }

		public override void OnDoubleClick( Mobile from )
		{
			if ( !IsChildOf( from.Backpack ) )
			{
				from.SendLocalizedMessage( 1042001 ); // That must be in your pack for you to use it.
			}

			else
			{

				if ( this.ItemID == 2597 )
				{
					this.ItemID = 2594;
				}
				else if ( this.ItemID == 2594 )
				{
					this.ItemID = 2597;
				}
				else if (this.ItemID != 2597 || this.ItemID != 2594 )
				{
					from.SendMessage("There was a problem lighting your lantern. Please contact a staff member");				
				}
				else
				{
					from.SendMessage( "Your lantern is broken. Please contact a staff member to repair it!" );
				}
			}
		}
		
        public override void Serialize( IGenericWriter writer )
        {
            base.Serialize( writer );
            writer.Write( (int) 0 );
        }

        public override void Deserialize(IGenericReader reader)
        {
            base.Deserialize( reader );
            int version = reader.ReadInt();
        }
    } // End Class
} // End Namespace
