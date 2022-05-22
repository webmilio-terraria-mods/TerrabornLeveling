using Infuller.Items;
using Infuller.Items.Melee;
using Microsoft.Xna.Framework;
using TerrabornLeveling.Perks.Visualisers;
using Terraria;
using Terraria.GameContent;
using Terraria.ID;

namespace TerrabornLeveling.Perks.Physical.OneHanded;

[Parents(typeof(Flurry))]
public class Parry : Perk
{
    public Parry() : base("parry")
    {
    }

    public override void OnModifyHitByNPC(NPC npc, ref int damage, ref bool crit)
    {
        bool checkParry = Main.rand.NextDouble() <= ParryChance;

        if (!checkParry || Owner.Player.immune || !Swords.TryGet(Owner.Player.HeldItem.type, out var record) || !record.Hands.HasFlag(WeaponHands.OneHanded)) return;

        Owner.Player.endurance = 1 - (1 - Owner.Player.endurance) * (1 - ParryDamageReduction);
        CombatText.NewText(new Rectangle((int)Owner.Player.position.X, (int)Owner.Player.position.Y, Owner.Player.width, Owner.Player.height), Color.Gold, "Parried!!", false, true);
    }

    public static float GetParryChance(int level)
    {
        return 0.08f * level;
    }
    
    public override string GetDescription(int level)
    {

        return $"Adds an {GetParryChance(level) * 100}% chance to parry an attack,\nreducing damage taken by {ParryDamageReduction * 100}%";
    }

    public override int GetRequiredSkill(int level) => StepRequiredLevel(35, 15, level);

    public override string Name => "Parry";
    public override int MaxLevel => 3;

    public float ParryChance => GetParryChance(Level);

    public float ParryDamageReduction { get; set; } = 0.25f;

    public override IPerkVisualDescriptor Visuals { get; } = new PerkVisualDescriptor(new(.2f, .75f));
}