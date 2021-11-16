using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using TerrabornLeveling.Perks.Mining;
using TerrabornLeveling.Players;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using WebmilioCommons;
using WebmilioCommons.Extensions;
using WebmilioCommons.Networking;

namespace TerrabornLeveling.Tiles;

public class TLGlobalTile : GlobalTile
{
    private List<ZAlignedTile> _alignedTiles;

    public override void Load()
    {
        _alignedTiles = new();
    }

    public override void Unload()
    {
        _alignedTiles = null;
    }

    public override void RightClick(int i, int j, int type)
    {
        var player = TLPlayer.Get();
        player.ForUnlockedPerks(perk => perk.OnRightClickTile(i, j, type));
    }

    public void PreUpdatePlayers()
    {
        _alignedTiles.DoInverted(delegate(ZAlignedTile tile, int i)
        {
            tile.TTL--;

            if (tile.TTL <= 0)
                _alignedTiles.RemoveAt(i);
        });
    }

    public void PreUpdateWorld()
    {
        _alignedTiles.Do(tile =>
        {
            if (Main.tile[tile.Position.X, tile.Position.Y].type == 0)
            {
                WorldGen.PlaceTile(tile.Position.X, tile.Position.Y, tile.Type);
            }
        });
    }

    public bool TryAlignZAxis(TLPlayer owner, Point position, int type)
    {
        if (_alignedTiles.Any(t => t.Owner == owner.Player.whoAmI))
            return false;

        _alignedTiles.Add(new(owner.Player.whoAmI, position, type, Constants.TicksPerSecond * 60 * 24));
        owner.SendIfLocal(new ZAlignedPacket(position, type));

        return true;
    }
}

public struct ZAlignedTile
{
    public ZAlignedTile(int owner, Point position, int type, int ttl)
    {
        Owner = owner;
        Position = position;
        Type = type;
        TTL = ttl;
    }

    public int Owner { get; }

    public Point Position { get; }
    
    public int Type { get; set; }
    public int TTL { get; set; }
}