using System.Collections.Generic;
using TerrabornLeveling.Perks;

namespace TerrabornLeveling.Skills;

public class Fishing : Skill
{
    public Fishing(IList<IPerk> perks) : base(perks)
    {
    }

    public override string Identifier => "fishing";
    public override string Name => "Fishing";

    public override string Description => "The art of patiently waiting for a bite. Those who show patience receive great reward.";
}