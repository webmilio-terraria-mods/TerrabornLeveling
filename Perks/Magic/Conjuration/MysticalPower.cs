using TerrabornLeveling.Perks.Visualisers;
using Terraria;
using Terraria.ModLoader;

namespace TerrabornLeveling.Perks.Magic.Conjuration;

[Parents(typeof(OtherworldAttunement))]
public class MysticalPower : Perk
{
    public MysticalPower() : base("mysticalpower")
    {
    }

    public override void OnModifyWeaponDamage(Item item, ref StatModifier damage, ref float flat)
    {
        if (item.DamageType != DamageClass.Summon) return;

        damage *= DamageMultiplier;
    }

    public static float GetDamageMultiplier(int level)
    {
        return .1f * level;
    }

    public override string GetDescription(int level)
    {
        return "";
    }

    public override int GetRequiredSkill(int level) => StepRequiredLevel(10, 20, level);

    public override string Name => "Mystical Power";
    public override int MaxLevel => 5;

    public float DamageMultiplier => 1 + GetDamageMultiplier(Level);

    public override IPerkVisualDescriptor Visuals { get; } = new PerkVisualDescriptor(new(0.21102661f, 0.8445596f));
}