using System.Collections.Generic;
using TerrabornLeveling.Perks;

namespace TerrabornLeveling.Skills;

public interface ISkill
{
    public string Identifier { get; }
    public string Name { get; }

    public string Description { get; }

    public float Experience { get; }
    public float ExperienceForLevel { get; }

    public int Level { get; }
    public int MaxLevel { get; }

    public int LegendaryLevel { get; }

    public IList<IPerk> Perks { get; }
}