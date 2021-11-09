using System;
using System.Text;
using TerrabornLeveling.Players;
using TerrabornLeveling.Skills;
using Terraria;
using WebmilioCommons;

namespace TerrabornLeveling.Perks.Fishing;

[Parents(typeof(MasterBaiter))]
public class Patience : Perk
{
    private const int NoRod = -1;

    private int _currentRod = NoRod;
    private int _timer;

    public Patience() : base("patience")
    {
    }

    public override void OnPlayerPreUpdate()
    {
        if (_currentRod != NoRod)
            _timer++;
    }

    public override void OnPlayerPostUpdate()
    {
        if (_currentRod == NoRod)
            return;

        if (Owner.Player.HeldItem.type != _currentRod)
        {
            _currentRod = NoRod;
            _timer = 0;
        }
    }

    public override void OnPlayerGetFishingLevel(Item fishingRod, Item bait, ref float fishingLevel)
    {
        fishingLevel *= FishingPowerBonus;
    }

    public override void OnPlayerUseItem(Item item)
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
        return $"For every second without reeling in, increase your fishing power by {Math.Round((GetFishingPowerBonus(level) - 1) * 100, 2)}% (compounding).\nEffect is lost upon reeling in.";
    }

    public override string Name { get; } = "Virtuous Patience";

    public override int MaxLevel { get; } = 2;

    public float FishingPowerBonus => GetFishingPowerBonus(Level, _timer / Constants.TicksPerSecond);

    public override IPerkVisualDescriptor Visuals { get; } = new StandardPerkVisualDescriptor(new(0.35f, 0.7f));

    public static float GetFishingPowerBonus(int level)
    {
        return 1 + level * .005f;
    }

    public static float GetFishingPowerBonus(int level, int seconds)
    {
        return (float)Math.Pow(GetFishingPowerBonus(level), seconds);
    }
}