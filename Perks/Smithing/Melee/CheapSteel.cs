using Terraria.ID;

namespace TerrabornLeveling.Perks.Smithing.Melee;

[Parents(typeof(BeginnersFlame))]
public class CheapSteel : ModifiersUnlockingPerk
{
    private static readonly int[] _unlocks = { PrefixID.Light, PrefixID.Bulky };

    public CheapSteel() : base("cheapsteel")
    {
    }

    public override string GetDescription(int level)
    {
        return string.Format(MeleeFormat, "Light", "Bulky");
    }

    public override string Name { get; } = "Cheap Steel";

    protected override int[] Unlocks { get; } = _unlocks;

    public override IPerkVisualDescriptor Visuals { get; } = new StandardPerkVisualDescriptor(new(0, .9f));
}