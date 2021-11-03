using On.Terraria;
using TerrabornLeveling.Players;
using Terraria.ModLoader;
using Recipe = Terraria.Recipe;

namespace TerrabornLeveling;

public partial class TLHooks : ModSystem
{
    public override void Load()
    {
        Main.CraftItem += Main_OnCraftItem;
    }

    public override void Unload()
    {
        Main.CraftItem -= Main_OnCraftItem;
    }
}