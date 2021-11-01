using System.Collections.Generic;
using TerrabornLeveling.Perks;

namespace TerrabornLeveling.Skills;

public class Smithing : Skill
{
    public Smithing(IList<IPerk> perks) : base(perks)
    {
    }

    public override string Identifier { get; } = "smithing";
    public override string Name { get; } = "Smithing";

    public override string Description { get; } = "";
}