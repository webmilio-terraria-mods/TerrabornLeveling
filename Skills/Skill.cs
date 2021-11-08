using System;
using System.Collections.Generic;
using TerrabornLeveling.Perks;
using WebmilioCommons.Extensions;

namespace TerrabornLeveling.Skills;

public abstract class Skill : ISkill
{
    protected Skill(IList<IPerk> perks)
    {
        Perks = perks;
    }

    public abstract string Identifier { get; }
    public abstract string Name { get; }

    public abstract string Description { get; }

    public virtual float Experience { get; }

    public virtual float ExperienceForLevel => ExperienceRequired(Level + 1);

    public virtual int Level { get; } = 1;
    public virtual int MaxLevel { get; } = 100;

    public virtual int LegendaryLevel { get; }

    public virtual IList<IPerk> Perks { get; }

    public float ExperienceRequired(int target) => ExperienceRequried(Level, target);

    public static float ExperienceRequried(int current, int target)
    {
        double xp = 0;

        for (int i = current; i <= target; i++)
            xp += Math.Pow(i, 1.95f);

        return (float) xp;
    }
}