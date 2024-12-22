using System;
using Server;
using Server.Commands;
using Server.Gumps;
using Server.Network;

namespace Server.Gumps
{
	public class AddPlantPt7Gump : Gump
	{
		public static void Initialize()
		{
			CommandSystem.Register("AddPlantPt7", AccessLevel.GameMaster, new CommandEventHandler(AddPlantPt7_OnCommand));
		}

		[Usage("AddPlantPt7")]
		public static void AddPlantPt7_OnCommand(CommandEventArgs e)
		{
			e.Mobile.CloseGump<AddPlantPt7Gump>();
			e.Mobile.SendGump(new AddPlantPt7Gump());
		}

		public static ItemInfo[] m_Types = new ItemInfo[]
		{
            #region Walls
            new ItemInfo(42115), new ItemInfo(42116), new ItemInfo(42117), new ItemInfo(42118), new ItemInfo(42119), new ItemInfo(42120), new ItemInfo(42121), new ItemInfo(42122), 
            new ItemInfo(42123), new ItemInfo(42124), new ItemInfo(42125), new ItemInfo(42126), new ItemInfo(42127), new ItemInfo(42128), new ItemInfo(42129), new ItemInfo(42130), 
            new ItemInfo(42131), new ItemInfo(42132), new ItemInfo(42133), new ItemInfo(42134), new ItemInfo(42135), new ItemInfo(42136), new ItemInfo(42137), new ItemInfo(42138), 
            new ItemInfo(42139), new ItemInfo(42140), new ItemInfo(42141), new ItemInfo(42142), new ItemInfo(42143), new ItemInfo(42144), new ItemInfo(42145), new ItemInfo(42146), 
            new ItemInfo(42147), new ItemInfo(42148), new ItemInfo(42149), new ItemInfo(42150), new ItemInfo(42151), new ItemInfo(42152), new ItemInfo(42153), new ItemInfo(42154), 
            new ItemInfo(42155), new ItemInfo(42156), new ItemInfo(42157), new ItemInfo(42158), new ItemInfo(42159), new ItemInfo(42160), new ItemInfo(42161), new ItemInfo(42162), 
            new ItemInfo(42163), new ItemInfo(42164), new ItemInfo(42165), new ItemInfo(42166), new ItemInfo(42167), new ItemInfo(42168), new ItemInfo(42169), new ItemInfo(42170), 
            new ItemInfo(42171), new ItemInfo(42172), new ItemInfo(42173), new ItemInfo(42174), new ItemInfo(42175), new ItemInfo(42176), new ItemInfo(42177), new ItemInfo(42178), 
            new ItemInfo(42179), new ItemInfo(42180), new ItemInfo(42181), new ItemInfo(42182), new ItemInfo(42183), new ItemInfo(42184), new ItemInfo(42185), new ItemInfo(42186), 
            new ItemInfo(42187), new ItemInfo(42188), new ItemInfo(42189), new ItemInfo(42190), new ItemInfo(42191), new ItemInfo(42192), new ItemInfo(42193), new ItemInfo(42208), 
            new ItemInfo(42209), new ItemInfo(42210), new ItemInfo(42211), new ItemInfo(42212), new ItemInfo(42213), new ItemInfo(42214), new ItemInfo(42215), new ItemInfo(42216), 
            new ItemInfo(42217), new ItemInfo(42223), new ItemInfo(42224), new ItemInfo(42225), new ItemInfo(42226), new ItemInfo(42227), new ItemInfo(42228), new ItemInfo(42229), 
            new ItemInfo(42230), new ItemInfo(42231), new ItemInfo(42232), new ItemInfo(42233), new ItemInfo(42234), new ItemInfo(42248), new ItemInfo(42249)
			
            #endregion
        };

		private int m_Page;

		//private readonly int m_Type;

		public AddPlantPt7Gump()
			: this(0)
		{ }

		public AddPlantPt7Gump(int page) 
			: base(0, 0)
		{
			int pageCount = 1 + (m_Types.Length / 12);

			if (page >= pageCount)
				page = pageCount - 1;
			else if (page < 0)
				page = 0;

			m_Page = page;

			Closable = true;
			Disposable = true;
			Draggable = true;
			Resizable = false;

			AddPage(0);

			AddBackground(0, 0, 720, 180, 3500);

			AddHtmlLocalized(15, 15, 60, 20, 1042971, page.ToString(), 0x1, false, false); // #

			AddHtmlLocalized(20, 38, 60, 20, 1043353, 0x1, false, false); // Next

			if (page + 1 < pageCount)
				AddButton(15, 55, 0xFA5, 0xFA7, 10000 + (page + 1), GumpButtonType.Reply, 0);
			else
				AddButton(15, 55, 0xFA5, 0xFA7, 10000, GumpButtonType.Reply, 0);

			AddHtmlLocalized(20, 93, 60, 20, 1011393, 0x1, false, false); // Back

			if (page > 0)
				AddButton(15, 110, 0xFAE, 0xFB0, 10000 + (page - 1), GumpButtonType.Reply, 0);
			else
				AddButton(15, 110, 0xFAE, 0xFB0, 10000, GumpButtonType.Reply, 0);

			for (int i = 0; i < 12; ++i)
			{
				int index = (page * 12) + i;
				if(index >= m_Types.Length) break;

				int button = 1000000 + index;
				int offset = (i + 1) * 50;

				if (m_Types[index].m_BaseID > 0)
				{
					AddButton(45 + offset, 20, 0x2624, 0x2625, button, GumpButtonType.Reply, m_Types[index].m_BaseID);
					AddItem(50 + offset, 40, m_Types[index].m_BaseID);
				}
				else
				{
					AddImage(25 + offset, 20, 0x2625, 900);
				}
			}
		}

		public override void OnResponse(NetState sender, in RelayInfo info)
		{
			Mobile from = sender.Mobile;

			int button = info.ButtonID;

			if (button <= 0)
				return;

			int page = m_Page;

			if (button >= 1000000)
			{
				button -= 1000000;

				CommandSystem.Handle(from, string.Format("{0}M Add Static {1}", CommandSystem.Prefix, m_Types[button].m_BaseID));
			}
			else if (button >= 10000)
			{
				button -= 10000;

				page = button;
			}

			from.SendGump(new AddPlantPt7Gump(page));
		}

		public class ItemInfo
		{
			public int m_BaseID;

			public ItemInfo(int baseID)
			{
				m_BaseID = baseID;
			}
		}
	}
}
