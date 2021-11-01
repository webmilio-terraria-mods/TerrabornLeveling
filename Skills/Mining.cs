using System.Collections.Generic;
using TerrabornLeveling.Perks;

namespace TerrabornLeveling.Skills;

public class Mining : Skill
{
    public Mining(IList<IPerk> perks) : base(perks)
    {
    }

    public override string Identifier { get; } = "mining";
    public override string Name { get; } = "Mining";

    public override string Description { get; }
}