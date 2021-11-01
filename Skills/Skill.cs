using System.Collections.Generic;
using TerrabornLeveling.Perks;

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
    public virtual float ExperienceForLevel { get; }

    public virtual int Level { get; } = 1;
    public virtual int MaxLevel { get; } = 100;

    public virtual int LegendaryLevel { get; }

    public virtual IList<IPerk> Perks { get; }
}