using TerrabornLeveling.Perks.Visualisers;
using Terraria.ID;

namespace TerrabornLeveling.Perks.Magic.Restoration;

public class ManaFlow : Perk
{
    private static UnlockCondition[] _conditions =
    {
        new UnlockCondition.ItemCondition(new(ItemID.BandofStarpower)),
        new UnlockCondition.ItemCondition(new(ItemID.ManaCrystal, 15)),
        new UnlockCondition.ExpertCondition(),
        new UnlockCondition.ItemCondition(new(ItemID.ArcaneFlower)),
        new UnlockCondition.ItemCondition(new(ItemID.CelestialEmblem))
    };

    public ManaFlow() : base("manaflow")
    {
    }

    public override void OnPreUpdate()
    {
        Owner.Player.manaRegen += (int)ManaRegenBuff * 2;
    }

    protected override bool PreTryLevel() => _conditions[Level].Check(Owner);

    protected override bool PreLevel()
    {
        _conditions[Level].PreLevelUp(Owner, Level);
        return true;
    }

    public override void OnContextActionKeybind()
    {
        Owner.Player.statMana -= Owner.Player.statMana - 1;
    }

    public static float GetManaRegenBuffPercentage(int level) => .01f * level;
    public static float GetManaRegenBuff(int maxMana, int level) => GetManaRegenBuffPercentage(level) * maxMana;

    public override string GetDescription(int level)
    {
        var condition = _conditions[level - 1];

        return
            "You gain the Mana Flow buff:\n" +
            $"You regenerate {(int)(GetManaRegenBuffPercentage(level) * 100)}% maximum Mana per second.\n" +
            $"{condition.Text}";
    }

    public override int GetRequiredSkill(int level) => StepRequiredLevel(20, level);

    public override string Name => "Mana Flow";
    public override int MaxLevel => 5;

    public float ManaRegenBuff => GetManaRegenBuff(Owner.Player.statManaMax2, Level);

    public override IPerkVisualDescriptor Visuals { get; } = new AnimatedItemIconVisualDescriptor(new(0, 0.8327922f), ItemID.NebulaPickup3, 4, 6);
}