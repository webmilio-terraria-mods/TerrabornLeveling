using System.Collections.Generic;
using TerrabornLeveling.Perks;

namespace TerrabornLeveling.Skills;

public class Enchanting : Skill
{
    public Enchanting(IList<IPerk> perks) : base(perks)
    {
    }

    public override string Identifier => "enchanting";
    public override string Name => "Enchanting";

    public override string Description => string.Empty;
}