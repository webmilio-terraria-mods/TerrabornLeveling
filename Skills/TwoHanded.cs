using System.Collections.Generic;
using TerrabornLeveling.Perks;

namespace TerrabornLeveling.Skills;

public class TwoHanded : Skill
{
    public TwoHanded(IList<IPerk> perks) : base(perks)
    {
    }

    public override string Identifier => "twohanded";
    public override string Name => "Two Handed";

    public override string Description => string.Empty;
}