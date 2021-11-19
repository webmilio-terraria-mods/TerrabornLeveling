using TerrabornLeveling.Perks.Visualisers;
using Terraria.ID;
using WebmilioCommons;

namespace TerrabornLeveling.Perks.Physical.Mining;

[Parents(typeof(CaveDweller))]
public class Spelunker : Perk
{
    public const int CooldownTime = Constants.TicksPerSecond * 60 * 4;

    public Spelunker() : base("spelunker")
    {
    }

    public override void OnPostUpdate()
    {
        if (Cooldown > 0)
            Cooldown--;
    }

    public override void OnContextActionKeybind()
    {
        if (Cooldown > 0)
            return;

        Owner.Player.AddBuff(BuffID.Spelunker, SpelunkerDuration);
        Cooldown = CooldownTime;
    }

    public static int GetSpelunkerDuration(int level)
    {
        return level * Constants.TicksPerSecond * (60 + 20);
    }

    public override string GetDescription(int level)
    {
        return $"Unlocks the [Context Action], allowing you to get the Spelunker buff on command for {GetSpelunkerDuration(level) / 60f} minutes.\n" +
               "This ability has a 4 minutes cooldown.";
    }

    public override int GetRequiredSkill(int level) => StepRequiredLevel(30, 10, level);

    public override string Name => "Spelunker";
    public override int MaxLevel => 3;

    public int SpelunkerDuration => GetSpelunkerDuration(Level);
    public int Cooldown { get; private set; }

    public override IPerkVisualDescriptor Visuals { get; } = new ItemIconVisualDescriptor(new(0.17110266f, 0.54037267f), ItemID.SpelunkerPotion);
}