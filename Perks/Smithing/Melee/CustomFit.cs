using Terraria.ID;

namespace TerrabornLeveling.Perks.Smithing.Melee;

[Parents(typeof(ExtraMaterial))]
public class CustomFit : ModifiersUnlockingPerk
{
    private static readonly int[] _unlocks = { PrefixID.Small, PrefixID.Large };

    public CustomFit() : base("customfit")
    {
    }

    public override string GetDescription(int level)
    {
        return string.Format(MeleeFormat, nameof(PrefixID.Small), nameof(PrefixID.Large));
    }

    public override string Name { get; } = "Custom Fit";

    protected override int[] Unlocks { get; } = _unlocks;

    public override IPerkVisualDescriptor Visuals { get; } = new StandardPerkVisualDescriptor(new(0, 0.6f));
}