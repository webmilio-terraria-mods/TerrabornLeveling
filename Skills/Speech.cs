using System.Collections.Generic;
using TerrabornLeveling.Perks;

namespace TerrabornLeveling.Skills;

public class Speech : Skill
{
    public Speech(IList<IPerk> perks) : base(perks)
    {
    }

    public override string Identifier => "speech";
    public override string Name => "Speech";

    public override string Description => string.Empty;
}