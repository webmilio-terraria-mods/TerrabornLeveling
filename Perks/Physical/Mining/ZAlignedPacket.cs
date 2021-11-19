using System.IO;
using Microsoft.Xna.Framework;
using TerrabornLeveling.Players;
using TerrabornLeveling.Tiles;
using Terraria.ModLoader;
using WebmilioCommons.Networking.Packets;

namespace TerrabornLeveling.Perks.Physical.Mining;

public class ZAlignedPacket : ModPlayerNetworkPacket<TLPlayer>
{
    public ZAlignedPacket()
    {
    }

    public ZAlignedPacket(Point position, int type)
    {
        Position = position;
        Type = type;
    }

    protected override bool PostReceive(BinaryReader reader, int fromWho)
    {
        ModContent.GetInstance<TLGlobalTile>().TryAlignZAxis(ModPlayer, Position, Type);
        return true;
    }

    public Point Position { get; set; }

    public int Type { get; set; }
}