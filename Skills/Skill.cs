using System;
using System.Collections.Generic;
using TerrabornLeveling.Perks;
using Terraria.Localization;

namespace TerrabornLeveling.Skills;

public abstract class Skill : ISkill
{
    private const string
        LocalizationPrefix = TerrabornLeveling.LocalizationPrefix + "Skills.",
        LocalizationName = LocalizationPrefix + "{0}.Name",
        LocalizationDesc = LocalizationPrefix + "{0}.Desc";

    private readonly LocalizedText _name, _description;

    protected Skill(IList<IPerk> perks)
    {
        Perks = perks;

        _name = GetLocalizedText(LocalizationName);
        _description = GetLocalizedText(LocalizationDesc);
    }

    public abstract string Identifier { get; }

    public virtual string Name => _name.ToString();
    public virtual string Description => _description.ToString();

    private LocalizedText GetLocalizedText(string path) => Language.GetText(string.Format(path, Identifier));

    public virtual float Experience { get; }
    public virtual float ExperienceForLevel => ExperienceRequired(Level + 1);

    public virtual int Level => 1;
    public virtual int MaxLevel => 100;

    public virtual int LegendaryLevel { get; }

    public abstract int Category { get; }

    public virtual bool Hidden { get; } = true;

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