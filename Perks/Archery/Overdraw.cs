using Infuller.Items.Ranged.Bow;
using Infuller.Items.Ranged.Repeater;
using TerrabornLeveling.Skills;
using Terraria;
using Terraria.ModLoader;

namespace TerrabornLeveling.Perks.Archery;

[Skill(typeof(Skills.Archery))]
public class Overdraw : Perk
{
    public Overdraw() : base("overdraw")
    {
    }

    public override void OnModifyWeaponDamage(Item item, ref StatModifier damage, ref float flat)
    {
        if (!Bows.Is(item.type) && !Repeaters.Is(item.type)) return;

        damage *= DamageMultiplier;
    }

    public static float GetDamageMultiplier(int level)
    {
        return 0.2f * level;
    }

    public override int GetRequiredSkill(int level) => StepRequiredLevel(1, 20, level);

    public override string GetDescription(int level)
    {
        return $"Bows do {(int)(GetDamageMultiplier(level) * 100)}% more damage.";
    }

    public override string Name => "Overdraw";
    public override int MaxLevel => 5;

    public float DamageMultiplier => 1 + GetDamageMultiplier(Level);

    public override IPerkVisualDescriptor Visuals { get; } = new StandardPerkVisualDescriptor(new(.5f, 1));
}