using System;
using Server;
using Server.Mobiles;
using Server.Items;
using Server.Gumps;
using Server.Network;
using Server.Commands;
using Server.Commands.Generic;
using Server.Targeting;

namespace Server.Gumps
{
	public class AddWallGump : Gump
	{
		public static void Initialize()
		{
				CommandSystem.Register("AddWall", AccessLevel.GameMaster, new CommandEventHandler(AddWall_OnCommand));
		}
        private static void OnLogin(CommandEventArgs e)
        {
            Mobile from = e.Mobile;
            from.CloseGump<AddWallGump>();
            from.SendGump(new AddWallGump(from));
        }
        private static void AddWall_OnCommand(CommandEventArgs e)
        {
	        Mobile from = e.Mobile;
	        from.CloseGump<AddWallGump>();
            from.SendGump(new AddWallGump(from));
        }


		public AddWallGump(Mobile from): base(0, 0)
		{

			Draggable = true;
			Closable = true;
			Resizable = false;
			Disposable = false;

			AddPage(0);
			AddBackground(268, 135, 345, 479, 3500);
			AddHtml(330, 160, 211, 31, "<basefont size=5><center>Walls", false, false);
            
			AddButton(290, 200, 1154, 1155, 1, GumpButtonType.Reply, 0);
			AddHtml(320, 200, 113, 25, "<basefont size=5><center>Part 1", false, false);
			AddButton(450, 200, 1154, 1155, 2, GumpButtonType.Reply, 0);
			AddHtml(480, 200, 113, 25, "<basefont size=5><center>Part 2", false, false);
			AddButton(290, 240, 1154, 1155, 3, GumpButtonType.Reply, 0);
			AddHtml(320, 240, 113, 25, "<basefont size=5><center>Part 3", false, false);
			AddButton(450, 240, 1154, 1155, 4, GumpButtonType.Reply, 0);
			AddHtml(480, 240, 113, 25, "<basefont size=5><center>Part 4", false, false);
			AddButton(290, 280, 1154, 1155, 5, GumpButtonType.Reply, 0);
			AddHtml(320, 280, 113, 25, "<basefont size=5><center>Part 5", false, false);
			AddButton(450, 280, 1154, 1155, 6, GumpButtonType.Reply, 0);
			AddHtml(480, 280, 113, 25, "<basefont size=5><center>Part 6", false, false);
			/*AddButton(290, 320, 1154, 1155, 7, GumpButtonType.Reply, 0);
			AddHtml(320, 320, 113, 25, "<basefont size=5><center>Part 7", false, false);
			AddButton(450, 320, 1154, 1155, 8, GumpButtonType.Reply, 0);
			AddHtml(480, 320, 113, 25, "<basefont size=5><center>Part 8", false, false);
			AddButton(290, 360, 1154, 1155, 9, GumpButtonType.Reply, 0);
			AddHtml(320, 360, 113, 25, "<basefont size=5><center>Part 9", false, false);
			AddButton(450, 360, 1154, 1155, 10, GumpButtonType.Reply, 0);
			AddHtml(480, 360, 113, 25, "<basefont size=5><center>Part 10", false, false);
			AddButton(290, 400, 1154, 1155, 11, GumpButtonType.Reply, 0);
			AddHtml(320, 400, 113, 25, "<basefont size=5><center>Part 11", false, false);
			AddButton(450, 400, 1154, 1155, 12, GumpButtonType.Reply, 0);
			AddHtml(480, 400, 113, 25, "<basefont size=5><center>Part 12", false, false);
			AddButton(290, 440, 1154, 1155, 13, GumpButtonType.Reply, 0);
			AddHtml(320, 440, 113, 25, "<basefont size=5><center>Part 13", false, false);
			AddButton(450, 440, 1154, 1155, 14, GumpButtonType.Reply, 0);
			AddHtml(480, 440, 113, 25, "<basefont size=5><center>Part 14", false, false);
			AddButton(290, 480, 1154, 1155, 15, GumpButtonType.Reply, 0);
			AddHtml(320, 480, 113, 25, "<basefont size=5><center>Part 15", false, false);
			AddButton(450, 480, 1154, 1155, 16, GumpButtonType.Reply, 0);
			AddHtml(480, 480, 113, 25, "<basefont size=5><center>Part 16", false, false);
			AddButton(290, 520, 1154, 1155, 17, GumpButtonType.Reply, 0);
			AddHtml(320, 520, 113, 25, "<basefont size=5><center>Part 17", false, false);
			AddButton(450, 520, 1154, 1155, 18, GumpButtonType.Reply, 0);
			AddHtml(480, 520, 113, 25, "<basefont size=5><center>Part 18", false, false);
			AddButton(290, 560, 1154, 1155, 19, GumpButtonType.Reply, 0);
			AddHtml(320, 560, 113, 25, "<basefont size=5><center>Part 19", false, false);
			AddButton(450, 560, 1154, 1155, 20, GumpButtonType.Reply, 0);
			AddHtml(480, 560, 113, 25, "<basefont size=5><center>Part 20", false, false);*/
		}
		
		 public override void OnResponse(NetState sender, in RelayInfo info)
        {
            Mobile from = sender.Mobile;
            string prefix = CommandSystem.Prefix;

            switch(info.ButtonID)
            {
				case 1:
				{
                    CommandSystem.Handle(from, string.Format("{0}AddWallPt1", prefix));
                    from.SendGump(new AddWallGump(from));
                    break;
				}
                case 2:
				{
                    CommandSystem.Handle(from, string.Format("{0}AddWallPt2", prefix));
                    from.SendGump(new AddWallGump(from));
                    break;
				}
                 case 3:
				{
                    CommandSystem.Handle(from, string.Format("{0}AddWallPt3", prefix));
                    from.SendGump(new AddWallGump(from));
                    break;
				}
                 case 4:
				{
                    CommandSystem.Handle(from, string.Format("{0}AddWallPt4", prefix));
                    from.SendGump(new AddWallGump(from));
                    break;
				}
                 case 5:
				{
                    CommandSystem.Handle(from, string.Format("{0}AddWallPt5", prefix));
                    from.SendGump(new AddWallGump(from));
                    break;
				}
                 case 6:
				{
                    CommandSystem.Handle(from, string.Format("{0}AddWallPt6", prefix));
                    from.SendGump(new AddWallGump(from));
                    break;
				}
                /*case 7:
				{
                    CommandSystem.Handle(from, string.Format("{0}AddWallPt7", prefix));
                    from.SendGump(new AddWallGump(from));
                    break;
				}
                 case 8:
				{
                    CommandSystem.Handle(from, string.Format("{0}AddWallPt8", prefix));
                    from.SendGump(new AddWallGump(from));
                    break;
				}
                 case 9:
				{
                    CommandSystem.Handle(from, string.Format("{0}AddWallPt9", prefix));
                    from.SendGump(new AddWallGump(from));
                    break;
				}
                 case 10:
				{
                    CommandSystem.Handle(from, string.Format("{0}AddWallPt10", prefix));
                    from.SendGump(new AddWallGump(from));
                    break;
				}
                case 11:
				{
                    CommandSystem.Handle(from, string.Format("{0}AddWallPt11", prefix));
                    from.SendGump(new AddWallGump(from));
                    break;
				}
                case 12:
				{
                    CommandSystem.Handle(from, string.Format("{0}AddWallPt12", prefix));
                    from.SendGump(new AddWallGump(from));
                    break;
				}
                case 13:
				{
                    CommandSystem.Handle(from, string.Format("{0}AddWallPt13", prefix));
                    from.SendGump(new AddWallGump(from));
                    break;
				}
                case 14:
				{
                    CommandSystem.Handle(from, string.Format("{0}AddWallPt14", prefix));
                    from.SendGump(new AddWallGump(from));
                    break;
				}
                case 15:
				{
                    CommandSystem.Handle(from, string.Format("{0}AddWallPt15", prefix));
                    from.SendGump(new AddWallGump(from));
                    break;
				}
                case 16:
				{
                    CommandSystem.Handle(from, string.Format("{0}AddWallPt16", prefix));
                    from.SendGump(new AddWallGump(from));
                    break;
				}
                case 17:
				{
                    CommandSystem.Handle(from, string.Format("{0}AddWallPt17", prefix));
                    from.SendGump(new AddWallGump(from));
                    break;
				}
                case 18:
				{
                    CommandSystem.Handle(from, string.Format("{0}AddWallPt18", prefix));
                    from.SendGump(new AddWallGump(from));
                    break;
				}
                case 19:
				{
                    CommandSystem.Handle(from, string.Format("{0}AddWallPt19", prefix));
                    from.SendGump(new AddWallGump(from));
                    break;
				}
                case 20:
				{
                    CommandSystem.Handle(from, string.Format("{0}AddWallPt20", prefix));
                    from.SendGump(new AddWallGump(from));
                    break;
				}*/

            }
        }
    }
}
