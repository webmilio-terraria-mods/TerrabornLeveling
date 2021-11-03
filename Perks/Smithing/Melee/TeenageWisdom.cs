using Terraria.ID;

namespace TerrabornLeveling.Perks.Smithing.Melee;

[Parents(typeof(CustomFit))]
public class TeenageWisdom : ModifiersUnlockingPerk
{
    private static readonly int[] _unlocks = { PrefixID.Dull, PrefixID.Dangerous };

    public TeenageWisdom() : base("teenagewisdom")
    {
    }

    public override string GetDescription(int level)
    {
        return string.Format(MeleeFormat, nameof(PrefixID.Dull), nameof(PrefixID.Dangerous));
    }

    public override string Name { get; } = "Teenage Wisdom";

    protected override int[] Unlocks { get; } = _unlocks;

    public override IPerkVisualDescriptor Visuals { get; } = new StandardPerkVisualDescriptor(new(0, .45f));
}