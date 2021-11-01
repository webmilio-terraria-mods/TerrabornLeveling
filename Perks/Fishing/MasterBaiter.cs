using TerrabornLeveling.Skills;

namespace TerrabornLeveling.Perks.Fishing;

[Skill(typeof(Skills.Fishing))]
public class MasterBaiter : StandardPerk
{
    public MasterBaiter() : base("masterbaiter", new(0.5f, 0.9f))
    {
    }

    public override string GetDescription(int level)
    {
        return $"Increases fishing power by {level * 5}.";
    }

    public override string Name { get; } = "Master Baiter";

    public override int MaxLevel { get; } = 5;
}