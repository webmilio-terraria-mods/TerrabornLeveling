using TerrabornLeveling.Perks.Visualisers;

namespace TerrabornLeveling.Perks.Physical.Mining;

[Parents(typeof(CaveDweller))]
public class TunnelBore : Perk
{
    public TunnelBore() : base("tunnelbore")
    {
    }

    public override string GetDescription(int level)
    {
        return "";
    }

    public override string Name => "Tunnel Bore";

    public override IPerkVisualDescriptor Visuals { get; } = new PerkVisualDescriptor(new(.3f, .4f));
}