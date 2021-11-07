using Infuller.Prefix;
using Microsoft.Xna.Framework;
using TerrabornLeveling.Players;
using Terraria;
using Terraria.ModLoader;

namespace TerrabornLeveling.Perks.Smithing.RepetitiveTrainingBranch;

[Parents(typeof(BeginnersFlame))]
public class RepetitiveTraining : Perk
{
    public RepetitiveTraining() : base("repetitivetraining")
    {
    }

    public override bool AllowCraftingPrefix(TLPlayer player, Item item, int prefix)
    {
        if (Prefixes.TryGet(prefix, out var alignment) && alignment >= PrefixAlignment.Neutral)
            return true;

        return Main.rand.NextFloat() > BadModifierMod;
    }

    public override string GetDescription(int level)
    {
        return $"Reduces the chance of getting a bad modifier on a crafted item by {(int)(GetBadModifierMod(level) * 100)}%.";
    }

    public override string Name { get; } = "Repetitive Training";

    public override int MaxLevel { get; } = 2;

    public float BadModifierMod => GetBadModifierMod(Level);
    //public float BadModifierMod => 1;

    public override IPerkVisualDescriptor Visuals { get; } = new StandardPerkVisualDescriptor(new Vector2(.5f, .8f));

    public static float GetBadModifierMod(int level)
    {
        return level * 0.25f;
    }
}