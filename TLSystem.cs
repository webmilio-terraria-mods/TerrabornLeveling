using TerrabornLeveling.Players;
using TerrabornLeveling.Tiles;
using TerrabornLeveling.UI;
using Terraria.ModLoader;

namespace TerrabornLeveling;

public class TLSystem : ModSystem
{
    private TLGlobalTile _globalTile;

    public override void Load()
    {
        _globalTile = ModContent.GetInstance<TLGlobalTile>();
    }

    public override void Unload()
    {
        _globalTile = null;
    }

    public override void PostUpdateInput()
    {
        if (TerrabornLeveling.Instance.SkillMenu.JustPressed)
        {
            Layer.Show();
        }

        if (TerrabornLeveling.Instance.ContextAction.JustPressed)
        {
            TLPlayer.Get().ForUnlockedPerks(perk => perk.OnContextActionKeybind());
        }

        if (TerrabornLeveling.Instance.RebuildSkillMenu.JustPressed)
        {
            Layer.State.PopulateSkills(TLPlayer.Get());
        }
    }

    public override void PreUpdatePlayers()
    {
        _globalTile.PreUpdatePlayers();
    }

    public override void PreUpdateWorld()
    {
        _globalTile.PreUpdateWorld();
    }

    public SkillsLayer Layer { get; } = new();
}