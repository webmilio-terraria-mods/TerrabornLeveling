using TerrabornLeveling.Skills;

namespace TerrabornLeveling.Perks.Destruction;

[Skill()]
public class Intensify : Perk
{
    public Intensify() : base("intensify")
    {
    }

    public override string GetDescription(int level)
    {
        throw new System.NotImplementedException();
    }

    public override string Name => "Intensify";

    public override IPerkVisualDescriptor Visuals { get; } = new StandardPerkVisualDescriptor()
}