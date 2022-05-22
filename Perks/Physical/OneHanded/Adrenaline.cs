using System;
using Infuller.Items;
using Infuller.Items.Melee;
using TerrabornLeveling.Perks.Visualisers;
using TerrabornLeveling.Skills;
using Terraria;
using Terraria.ModLoader;

namespace TerrabornLeveling.Perks.Physical.OneHanded;

[Parents(typeof(Flurry))]
public class Adrenaline : Perk
{
    public Adrenaline() : base("adrenaline")
    {
    }

    public override void OnHitNPC(Item item, NPC target, ref int damage, ref float knockback, ref bool crit)
    {
        if (!Swords.TryGet(item.type, out var record) || !record.Hands.HasFlag(WeaponHands.OneHanded)) return;


        bool checkHeal = Main.rand.NextDouble() <= HealChance;

        if (checkHeal)
        {
            int healAmount = (int)Math.Max(Owner.Player.statLifeMax2 * HealPercentage, 1);

            Owner.Player.statLife += healAmount;
            Owner.Player.HealEffect(healAmount);
        }
    }

    public static float GetHealChance(int level)
    {
        return 0.0175f * level;
    }

    public override string GetDescription(int level)
    {
        return $"Adds a {GetHealChance(level) * 100}% chance to heal you for {HealPercentage * 100}% life when you strike an enemy.";
    }

    public override int GetRequiredSkill(int level) => StepRequiredLevel(40, 10, level);

    public override string Name => "Adrenaline";
    public override int MaxLevel => 4;

    public float HealChance => GetHealChance(Level);
    public float HealPercentage { get; set; } = 0.01f;

    public override IPerkVisualDescriptor Visuals { get; } = new PerkVisualDescriptor(new(.5f, .3f));
}