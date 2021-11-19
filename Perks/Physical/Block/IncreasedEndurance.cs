using TerrabornLeveling.Perks.Visualisers;
using TerrabornLeveling.Skills;

namespace TerrabornLeveling.Perks.Physical.Block;

[Skill(typeof(Skills.Block))]
public class IncreasedEndurance : Perk
{
    public IncreasedEndurance() : base("increasedendurance")
    {
    }

    public override void OnPreUpdate()
    {
        Owner.Player.endurance = (1 - Owner.Player.endurance) * EnduranceMultiplier + Owner.Player.endurance;
    }

    public static float GetEnduranceMultiplier(int level)
    {
        return .016f * level;
    }

    public override string GetDescription(int level)
    {
        return $"You take {(int)(GetEnduranceMultiplier(level) * 100)}% less damage from all sources.";
    }

    public override string Name => "Increased Endurance";
    public override int MaxLevel => 5;

    public float EnduranceMultiplier => GetEnduranceMultiplier(Level);

    public override IPerkVisualDescriptor Visuals { get; } = new PerkVisualDescriptor(new(.5f, 1));
}