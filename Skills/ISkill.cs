using System;
using System.Collections.Generic;
using TerrabornLeveling.Perks;
using WebmilioCommons.Extensions;

namespace TerrabornLeveling.Skills;

public interface ISkill
{
    public void ForUnlockedPerks(Action<IPerk> action)
    {
        Perks.Do(delegate (IPerk perk)
        {
            if (perk.Unlocked)
                action(perk);
        });
    }

    public bool TrueForAllUnlockedPerks(Predicate<IPerk> predicate)
    {
        return Perks.ForAll(predicate);
    }

    public string Identifier { get; }
    public string Name { get; }

    public string Description { get; }

    public float Experience { get; }
    public float ExperienceForLevel { get; }

    public int Level { get; }
    public int MaxLevel { get; }

    public int LegendaryLevel { get; }

    public int Category { get; }

    public IList<IPerk> Perks { get; }
}