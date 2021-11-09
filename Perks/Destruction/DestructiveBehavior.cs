using Microsoft.Xna.Framework;
using TerrabornLeveling.Skills;

namespace TerrabornLeveling.Perks.Destruction;

[Skill(typeof(Skills.Destruction))]
public class DestructiveBehavior : Perk
{
    public DestructiveBehavior() : base("destructivebehavior")
    {
    }

    public override string GetDescription(int level)
    {
        return ""; // TODO Change this.
    }

    public override string Name => "Destructive Behavior";

    public override IPerkVisualDescriptor Visuals { get; } = new StandardPerkVisualDescriptor(new(.5f, 1));
}