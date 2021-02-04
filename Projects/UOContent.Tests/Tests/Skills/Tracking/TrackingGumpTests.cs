using System;
using Server.Mobiles;
using Server.Network;
using Server.SkillHandlers;
using Server.Tests;
using Server.Tests.Network;
using Xunit;

namespace UOContent.Tests
{
    public class TrackingGumpTests : IClassFixture<ServerFixture>
    {
        [Theory]
        [InlineData(ProtocolChanges.None)]
        [InlineData(ProtocolChanges.Unpack)]
        // Regression test used to identify an issue with AddItem compilation of the packet
        public void TestTrackingGump(ProtocolChanges changes)
        {
            var pm = new PlayerMobile();
            pm.Skills.Tracking.BaseFixedPoint = 1000;
            var g = new TrackWhatGump(pm);

            using var ns = PacketTestUtilities.CreateTestNetState();
            ns.ProtocolChanges = changes;

            var expected = g.Compile(ns).Compile();
            ns.SendDisplayGump(g, out var switches, out var entries);

            var result = ns.SendPipe.Reader.TryRead();
            AssertThat.Equal(result.Buffer[0].AsSpan(0), expected);
        }
    }
}