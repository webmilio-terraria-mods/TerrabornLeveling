using System;
using Infuller.Items;
using Infuller.Items.Melee;
using TerrabornLeveling.Perks.Visualisers;
using TerrabornLeveling.Skills;
using Terraria;
using Terraria.ModLoader;

namespace TerrabornLeveling.Perks.Physical.OneHanded;

[Parents(typeof(Flurry))]
public class Malice : Perk
{
    public Malice() : base("malice")
    {
    }

    public override void OnUpdateEquips()
    {
        if (!Swords.TryGet(Owner.Player.HeldItem.type, out var record) || !record.Hands.HasFlag(WeaponHands.OneHanded)) return;

        Owner.Player.GetCritChance(DamageClass.Melee) += GetCriticalChanceBonus(Level);
    }

    public static int GetCriticalChanceBonus(int level)
    {
        return 2 * level;
    }

    public override string GetDescription(int level)
    {
        return $"Increase critical chance by {GetCriticalChanceBonus(level)}%.";
    }

    public override int GetRequiredSkill(int level) => StepRequiredLevel(15, 15, level);

    public override string Name => "Malice";
    public override int MaxLevel => 5;

    public override IPerkVisualDescriptor Visuals { get; } = new PerkVisualDescriptor(new(.8f, .75f));
}