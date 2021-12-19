using TerrabornLeveling.Perks.Visualisers;
using Terraria.GameContent;
using Terraria.ID;

namespace TerrabornLeveling.Perks.Physical.Block;

[Parents(typeof(IncreasedEndurance))]
public class GolemsStrength : Perk
{
    private const int LevelCount = 5;

    private static UnlockCondition[] _conditions =
    {
        new UnlockCondition.ItemCondition(new(ItemID.BandofRegeneration)),
        new UnlockCondition.ItemCondition(new(ItemID.LifeCrystal, 5)),
        new UnlockCondition.ExpertCondition(),
        new UnlockCondition.ItemCondition(new(ItemID.LifeFruit, 5)),
        new UnlockCondition.ItemCondition(new(ItemID.ShinyStone))
    };

    public GolemsStrength() : base("golemsstrength")
    {
    }

    public static float GetHealthRegenBuffPercentage(int level) => .01f * level;
    public static float GetHealthRegenBuff(int maxHealth, int level) => GetHealthRegenBuffPercentage(level) * maxHealth;

    public override void OnUpdateLifeRegen()
    {
        Owner.Player.lifeRegen += (int) HealthRegenBuff * 2;
    }
    
    protected override bool PreTryLevel() => _conditions[Level].Check(Owner);

    protected override bool PreLevel()
    {
        _conditions[Level].PreLevelUp(Owner, Level);
        return true;
    }

    public override string GetDescription(int level)
    {
        var condition = _conditions[level - 1];

        return "You gain the Golem's Strength buff:\n" +
               $"You regenerate {(int)(GetHealthRegenBuffPercentage(level) * 100)}% maximum HP per second.\n" +
               $"{condition.Text}";
    }

    public override int GetRequiredSkill(int level) => StepRequiredLevel(20, level);

    public override string Name => "Golem's Strength";
    public override int MaxLevel => LevelCount;

    public float HealthRegenBuff => GetHealthRegenBuff(Owner.Player.statLifeMax2, Level);

    public override IPerkVisualDescriptor Visuals { get; } = new AnimatedTypeIconVisualDescriptor(new(0.2f, 0.8327922f), 
        TextureAssets.Item, ItemID.NebulaPickup2, 4, 6);
}