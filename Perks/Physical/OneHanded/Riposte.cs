using Infuller.Items;
using Infuller.Items.Melee;
using TerrabornLeveling.Perks.Visualisers;
using Terraria;
using Terraria.ModLoader;

namespace TerrabornLeveling.Perks.Physical.OneHanded;

[Parents(typeof(Parry))]
public class Riposte : Perk
{
    public Riposte() : base("riposte")
    {
    }

    public override void OnUpdateEquips()
    {
        //TODO: Get this to work
        /*if (!Swords.TryGet(Owner.Player.HeldItem.type, out var record) || !record.Hands.HasFlag(WeaponHands.OneHanded)) return;

        Owner.Player.GetDamage(DamageClass.Melee) *= 1 + DamageBonus;
        Owner.Player.meleeSpeed *= MeleeSpeedBonus;*/
    }

    public static float GetDamageBonus(int level)
    {
        return 0.5f * level;
    }
    public static float GetMeleeSpeedBonus(int level)
    {
        return 2f * level;
    }

    public override string GetDescription(int level)
    {
        return $"After performing a parry, damage is increased by {GetDamageBonus(level) * 100}%,\nand melee speed is increased by {GetMeleeSpeedBonus(level) * 100}% for your next attack.";
    }

    public override int GetRequiredSkill(int level) => StepRequiredLevel(75, 10, level);

    public override string Name => "Riposte";
    public override int MaxLevel => 1;

    public float DamageBonus => GetDamageBonus(Level);
    public float MeleeSpeedBonus => GetMeleeSpeedBonus(Level);

    public override IPerkVisualDescriptor Visuals { get; } = new PerkVisualDescriptor(new(.3f, .65f));
}