using System;
using Infuller.Items;
using Infuller.Items.Melee;
using TerrabornLeveling.Perks.Visualisers;
using TerrabornLeveling.Skills;
using Terraria;
using Terraria.ModLoader;

namespace TerrabornLeveling.Perks.Physical.OneHanded;

[Parents(typeof(Flurry))]
public class Pierce : Perk
{
    public Pierce() : base("pierce")
    {
    }

    public override void OnModifyHitNPC(Item item, NPC target, ref int damage, ref float knockback, ref bool crit)
    {
        if (!Swords.TryGet(Owner.Player.HeldItem.type, out var record) || !record.Hands.HasFlag(WeaponHands.OneHanded)) return;

        Owner.Player.armorPenetration += (int)Math.Round(target.defense * 0.25f);
    }

    public static float GetArmorPenetration(int level)
    {
        return 0.25f * level;
    }

    public override string GetDescription(int level)
    {
        return $"Attacks ignore {GetArmorPenetration(level) * 100}% defense.";
    }

    public override int GetRequiredSkill(int level) => StepRequiredLevel(25, 0, level);

    public override string Name => "Pierce";
    public override int MaxLevel => 1;

    public override IPerkVisualDescriptor Visuals { get; } = new PerkVisualDescriptor(new(.5f, .5f));
}