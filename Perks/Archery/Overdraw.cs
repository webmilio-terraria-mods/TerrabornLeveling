using TerrabornLeveling.Players;
using TerrabornLeveling.Skills;
using Terraria;
using Terraria.ModLoader;
using Infuller.Items.Bow;

namespace TerrabornLeveling.Perks.Archery;

[Skill(typeof(Skills.Archery))]
public class Overdraw : Perk
{
    public Overdraw() : base("overdraw")
    {
    }

    public override void OnPlayerModifyWeaponDamage(TLPlayer player, Item item, ref StatModifier damage, ref float flat)
    {
        if (item.DamageType != DamageClass.Ranged || !Bows.Is(item.type)) return;

        damage *= 1 + GetDamageMultiplier(Level);
    }

    public override string Name { get; } = "Overdraw";
    public override int MaxLevel { get; } = 5;

    public override IPerkVisualDescriptor Visuals { get; } = new StandardPerkVisualDescriptor(new(0.5f, 1));

    public override string GetDescription(int level)
    {
        return $"Bows do {GetDamageMultiplier(level)*100}% more damage.";
    }

    public static float GetDamageMultiplier(int level)
    {
        return 0.2f * level;
    }
}