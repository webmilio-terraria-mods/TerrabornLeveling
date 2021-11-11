using Infuller.Items;
using Infuller.Items.Melee;
using TerrabornLeveling.Players;
using TerrabornLeveling.Skills;
using Terraria;
using Terraria.ModLoader;

namespace TerrabornLeveling.Perks.OneHanded;

[Skill(typeof(Skills.OneHanded))]
public class Armsman : Perk
{
    public Armsman() : base("armsman")
    {
    }

    public override void OnModifyWeaponDamage(Item item, ref StatModifier damage, ref float flat)
    {
        if (!Swords.TryGet(item.type, out var record) || !record.Hands.HasFlag(WeaponHands.OneHanded)) return;
        
        damage *= DamageMultiplier;
    }

    public static float GetDamageMultiplier(int level)
    {
        return 0.2f * level;
    }

    public override string GetDescription(int level)
    {
        return $"One-handed weapons do {(int)(GetDamageMultiplier(level) * 100)}% more damage.";
    }

    public override string Name => "Armsman";
    public override int MaxLevel => 5;

    public float DamageMultiplier => 1 + GetDamageMultiplier(Level);

    public override IPerkVisualDescriptor Visuals { get; } = new StandardPerkVisualDescriptor(new(.5f, 1));
}