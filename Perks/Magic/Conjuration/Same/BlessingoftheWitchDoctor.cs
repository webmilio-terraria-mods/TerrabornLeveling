using TerrabornLeveling.Perks.Visualisers;

namespace TerrabornLeveling.Perks.Magic.Conjuration.Same;

[Parents(typeof(OtherworldAttunement))]
public class BlessingoftheWitchDoctor : Perk
{
    public BlessingoftheWitchDoctor() : base("blessingofthewitchdoctor")
    {
    }

    public override string GetDescription(int level)
    {
        return "";
    }

    public override string Name => "Blessing of the Witch Doctor";
    public override IPerkVisualDescriptor Visuals { get; } = new PerkVisualDescriptor(new(0.7414449f, 0.8212435f));
}