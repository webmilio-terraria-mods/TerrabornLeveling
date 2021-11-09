using TerrabornLeveling.Players;
using TerrabornLeveling.Skills;
using Terraria;
using Terraria.ModLoader;
using Infuller.Items.Bow;
using Infuller.Items.Repeater;

namespace TerrabornLeveling.Perks.Archery;

[Skill(typeof(Skills.Archery))]
public class Overdraw : Perk
{
    public Overdraw() : base("overdraw")
    {
    }

    public override void OnPlayerModifyWeaponDamage(Item item, ref StatModifier damage, ref float flat)
    {
        if (!Bows.Is(item.type) && !Repeaters.Is(item.type)) return;

        damage *= DamageMultiplier;
    }

    public static float GetDamageMultiplier(int level)
    {
        return 0.2f * level;
    }

    public override string GetDescription(int level)
    {
        return $"Bows do {(int)(GetDamageMultiplier(level) * 100)}% more damage.";
    }

    public override string Name { get; } = "Overdraw";
    public override int MaxLevel { get; } = 5;

    public float DamageMultiplier => 1 + GetDamageMultiplier(Level);

    public override IPerkVisualDescriptor Visuals { get; } = new StandardPerkVisualDescriptor(new(.5f, 1));
}