using TerrabornLeveling.Perks.Visualisers;
using TerrabornLeveling.Skills;

namespace TerrabornLeveling.Perks.Magic.Restoration;

[Skill(typeof(Skills.Restoration))]
public class EfficientUse : Perk
{
    public EfficientUse() : base("efficientuse")
    {
    }

    public override string GetDescription(int level)
    {
        return "";
    }

    public override string Name => "Efficient Use";

    public override IPerkVisualDescriptor Visuals { get; } = new PerkVisualDescriptor(new(.5f, 1));
}