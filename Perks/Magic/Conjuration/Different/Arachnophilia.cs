using TerrabornLeveling.Perks.Visualisers;

namespace TerrabornLeveling.Perks.Magic.Conjuration.Different;

[Parents(typeof(BlessingoftheSpiderQueen))]
public class Arachnophilia : Perk
{
    public Arachnophilia() : base("arachnophilia")
    {
    }

    public override string GetDescription(int level)
    {
        return "";
    }

    public override string Name => "Arachnophilia";

    public override IPerkVisualDescriptor Visuals { get; } = new PerkVisualDescriptor(new(0.33079848f, 0.53108805f));
}