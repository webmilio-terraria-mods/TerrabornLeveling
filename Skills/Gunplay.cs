using System.Collections.Generic;
using TerrabornLeveling.Perks;

namespace TerrabornLeveling.Skills;

public class Gunplay : Skill
{
    public Gunplay(IList<IPerk> perks) : base(perks)
    {
    }

    public override string Identifier { get; } = "gunplay";
    public override string Name { get; } = "Gunplay";

    public override string Description { get; } = "";
}