using System;
using Server;

namespace Server.Items
{
	public class DupresCollar : PlateGorget
	{
		
		public override int ArtifactRarity{ get{ return 12; } }

		public override int BaseFireResistance{ get{ return 13; } }
		public override int BaseColdResistance{ get{ return 11; } }
		public override int BasePhysicalResistance{ get{ return 8; } }
		public override int BaseEnergyResistance{ get{ return 12; } }

		public override int InitMinHits{ get{ return 255; } }
		public override int InitMaxHits{ get{ return 255; } }

		[Constructible]
		public DupresCollar()
		{
			Name = "Dupre's Collar";
			Hue = 794;
			Attributes.BonusStr = 5;
			Attributes.RegenHits = 2;
			Attributes.DefendChance = 20;
		}

		public DupresCollar( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( IGenericWriter writer )
		{
			base.Serialize( writer );

			writer.Write( (int) 1 );
		}
		
		public override void Deserialize(IGenericReader reader)
		{
			base.Deserialize( reader );

			int version = reader.ReadInt();

		}
	}
}
