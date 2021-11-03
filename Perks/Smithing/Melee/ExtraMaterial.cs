using Terraria.ID;

namespace TerrabornLeveling.Perks.Smithing.Melee;

[Parents(typeof(CheapSteel))]
public class ExtraMaterial : ModifiersUnlockingPerk
{
    private static readonly int[] _unlocks = { PrefixID.Heavy, PrefixID.Pointy };

    public ExtraMaterial() : base("extramaterial")
    {
    }

    public override string GetDescription(int level)
    {
        return string.Format(MeleeFormat, "Heavy", "Pointy");
    }

    public override string Name { get; } = "Extra Material";
    protected override int[] Unlocks { get; } = _unlocks;

    public override IPerkVisualDescriptor Visuals { get; } = new StandardPerkVisualDescriptor(new(0, .75f));
}