using System;
using Infuller.Items;
using Infuller.Items.Melee;
using TerrabornLeveling.Perks.Visualisers;
using TerrabornLeveling.Skills;
using Terraria;
using Terraria.ModLoader;

namespace TerrabornLeveling.Perks.Physical.OneHanded;

[Parents(typeof(Armsman))]
public class Flurry : Perk
{
    public Flurry() : base("flurry")
    {
    }

    public override void OnUpdateEquips()
    {
        if (!Swords.TryGet(Owner.Player.HeldItem.type, out var record) || !record.Hands.HasFlag(WeaponHands.OneHanded)) return;

        Owner.Player.meleeSpeed += MeleeSpeedBonus;
    }

    public static float GetMeleeSpeedBonus(int level)
    {
        return 0.08f * level;
    }

    public override string GetDescription(int level)
    {
        return $"Increases melee speed by {GetMeleeSpeedBonus(level) * 100}% for one-handed weapons.";
    }

    public override int GetRequiredSkill(int level) => StepRequiredLevel(10, 20, level);

    public override string Name => "Flurry";
    public override int MaxLevel => 4;

    public float MeleeSpeedBonus => GetMeleeSpeedBonus(Level);

    public override IPerkVisualDescriptor Visuals { get; } = new PerkVisualDescriptor(new(.5f, .75f));
}