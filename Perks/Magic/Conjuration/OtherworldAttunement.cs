using TerrabornLeveling.Perks.Visualisers;
using TerrabornLeveling.Skills;
using Terraria;
using Terraria.ModLoader;

namespace TerrabornLeveling.Perks.Magic.Conjuration;

[Skill(typeof(Skills.Conjuration))]
public class OtherworldAttunement : Perk
{
    public OtherworldAttunement() : base("otherworldattunement")
    {
    }

    public override void OnModifyManaCost(Item item, ref float reduce, ref float mult)
    {
        if (item.DamageType != DamageClass.Summon) return;

        mult -= SummonCostReduction;
    }

    public override string GetDescription(int level)
    {
        return "";
    }

    public static float GetSummonCostReduction(int level) => level * .5f;

    public override int GetRequiredSkill(int level) => StepRequiredLevel(1, 20, level);

    public override string Name => "Otherworld Attunement";
    public override int MaxLevel => 2;

    public float SummonCostReduction => GetSummonCostReduction(Level);

    public override IPerkVisualDescriptor Visuals { get; } = new PerkVisualDescriptor(new(.5f, 1));
}