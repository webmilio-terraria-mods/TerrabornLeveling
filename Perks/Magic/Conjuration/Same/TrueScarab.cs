using TerrabornLeveling.Perks.Magic.Conjuration.Different;
using TerrabornLeveling.Perks.Visualisers;

namespace TerrabornLeveling.Perks.Magic.Conjuration.Same;

[Parents(typeof(BlessingoftheWitchDoctor))]
public class TrueScarab : Perk
{
    public TrueScarab() : base("truescarab")
    {
    }

    public override string GetDescription(int level)
    {
        return "";
    }

    public override string Name => "True Scarab";

    public override IPerkVisualDescriptor Visuals { get; } = new PerkVisualDescriptor(new(0.6425856f, 0.6217617f));
}