using System;
using TerrabornLeveling.Perks.Visualisers;
using Terraria;
using WebmilioCommons;

namespace TerrabornLeveling.Perks.Agility.Fishing;

[Parents(typeof(MasterBaiter))]
public class Patience : Perk
{
    private const int NoRod = -1;

    private int _currentRod = NoRod;
    private int _timer;

    public Patience() : base("patience")
    {
    }

    public override void OnPreUpdate()
    {
        if (_currentRod != NoRod)
            _timer++;
    }

    public override void OnPostUpdate()
    {
        if (_currentRod == NoRod)
            return;

        if (Owner.Player.HeldItem.type != _currentRod)
        {
            _currentRod = NoRod;
            _timer = 0;
        }
    }

    public override void OnGetFishingLevel(Item fishingRod, Item bait, ref float fishingLevel)
    {
        fishingLevel *= FishingPowerBonus;
    }

    public static float GetFishingPowerBonus(int level)
    {
        return 1 + level * .005f;
    }

    public static float GetFishingPowerBonus(int level, int seconds)
    {
        return (float)Math.Pow(GetFishingPowerBonus(level), seconds);
    }

    public override void OnUseItem(Item item)
    {
        if (item.fishingPole == 0)
        {
            _currentRod = NoRod;
            return;
        }

        _timer = 0;
        _currentRod = item.type;
    }

    public override string GetDescription(int level)
    {
        return
            $"For every second without reeling in, increase your fishing power by {Math.Round((GetFishingPowerBonus(level) - 1) * 100, 2)}% (compounding).\n" +
            "Effect is lost upon reeling in.";
    }

    public override int GetRequiredSkill(int level) => level * 20 + 5;

    public override string Name => "Virtuous Patience";
    public override int MaxLevel => 2;

    public float FishingPowerBonus => GetFishingPowerBonus(Level, _timer / Constants.TicksPerSecond);

    public override IPerkVisualDescriptor Visuals { get; } = new PerkVisualDescriptor(new(0.33460075f, 0.6236559f));
}