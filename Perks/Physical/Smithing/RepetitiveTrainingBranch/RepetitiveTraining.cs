using Infuller.Prefix;
using Microsoft.Xna.Framework;
using TerrabornLeveling.Perks.Visualisers;
using Terraria;

namespace TerrabornLeveling.Perks.Physical.Smithing.RepetitiveTrainingBranch;

[Parents(typeof(BeginnersFlame))]
public class RepetitiveTraining : Perk
{
    public RepetitiveTraining() : base("repetitivetraining")
    {
    }

    public override bool AllowCraftingPrefix(Item item, int prefix)
    {
        if (Prefixes.TryGet(prefix, out var alignment) && alignment >= PrefixAlignment.Neutral)
            return true;

        return Main.rand.NextFloat() > BadModifierMod;
    }

    public override string GetDescription(int level)
    {
        return $"Reduces the chance of getting a bad modifier on a crafted item by {(int)(GetBadModifierMod(level) * 100)}%.";
    }

    public override int GetRequiredSkill(int level)
    {
        return level * 15;
    }

    public override string Name => "Repetitive Training";

    public override int MaxLevel => 2;

    public float BadModifierMod => GetBadModifierMod(Level);
    //public float BadModifierMod => 1;

    public override IPerkVisualDescriptor Visuals { get; } = new PerkVisualDescriptor(new Vector2(.69f, .88f));

    public static float GetBadModifierMod(int level)
    {
        return level * 0.25f;
    }
}