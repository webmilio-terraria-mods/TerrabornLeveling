using System.Collections.Generic;
using TerrabornLeveling.Perks;

namespace TerrabornLeveling.Skills;

public class Archery : Skill
{
    public Archery(IList<IPerk> perks) : base(perks)
    {
    }

    public override string Identifier { get; } = "archery";

    public override string Name { get; } = "Archery";

    public override string Description { get; } = "";
}