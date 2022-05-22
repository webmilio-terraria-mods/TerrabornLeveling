using System;
using Infuller.Items;
using Infuller.Items.Melee;
using TerrabornLeveling.Perks.Visualisers;
using TerrabornLeveling.Skills;
using Terraria;
using Terraria.ModLoader;

namespace TerrabornLeveling.Perks.Physical.OneHanded;

[Parents(typeof(Malice))]
public class Assassinate : Perk
{
    public Assassinate() : base("assassinate")
    {
    }

    public override void OnModifyHitNPC(Item item, NPC target, ref int damage, ref float knockback, ref bool crit)
    {
        if (!Swords.TryGet(item.type, out var record) || !record.Hands.HasFlag(WeaponHands.OneHanded)) return;

        if (crit)
        {
            damage += (int)(damage * GetCriticalDamageBonus(Level));
        }
    }

    public static float GetCriticalDamageBonus(int level)
    {
        return 0.3f * level;
    }

    public override string GetDescription(int level)
    {
        return $"Increases the damage of critical hits by {GetCriticalDamageBonus(level) * 100}%.";
    }

    public override int GetRequiredSkill(int level) => StepRequiredLevel(50, 20, level);

    public override string Name => "Assassinate";
    public override int MaxLevel => 1;

    public override IPerkVisualDescriptor Visuals { get; } = new PerkVisualDescriptor(new(.7f, .65f));
}