using TerrabornLeveling.Perks.Visualisers;
using TerrabornLeveling.Skills;

namespace TerrabornLeveling.Perks.Physical.Mining;

[Skill(typeof(Skills.Mining))]
public class CaveDweller : Perk
{
    public CaveDweller() : base("cavedweller")
    {
    }

    public override void OnPreUpdate()
    {
        Owner.Player.pickSpeed *= MiningSpeedMultiplier;
    }

    public static float GetMiningSpeedMultiplier(int level)
    {
        return .2f * level;
    }

    public override string GetDescription(int level)
    {
        return $"Mining speed multiplied by {(int)(GetMiningSpeedMultiplier(level) * 100)}%.";
    }

    public override int GetRequiredSkill(int level) => StepRequiredLevel(1, 20, level);

    public override string Name => "Cave Dweller";
    public override int MaxLevel => 5;

    public float MiningSpeedMultiplier => 1 + GetMiningSpeedMultiplier(Level);

    public override IPerkVisualDescriptor Visuals { get; } = new PerkVisualDescriptor(new(0.2851711f, 0.9968944f));
}