using System.Collections.Generic;
using TerrabornLeveling.Perks;

namespace TerrabornLeveling.Skills;

public class Fishing : Skill
{
    public Fishing(IList<IPerk> perks) : base(perks)
    {
    }

    public override string Identifier { get; } = "fishing";
    public override string Name { get; } = "Fishing";

    public override string Description { get; } = "The art of patiently waiting for a bite. Those who show patience receive great reward.";
}