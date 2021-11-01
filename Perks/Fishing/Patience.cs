using System.Text;
using TerrabornLeveling.Skills;

namespace TerrabornLeveling.Perks.Fishing;

[Parents(typeof(MasterBaiter))]
[Skill(typeof(Skills.Fishing))]
public class Patience : StandardPerk
{
    public Patience() : base("patience", new(0.35f, 0.7f))
    { 
    }

    public override string GetDescription(int level)
    {
        StringBuilder sb = new("For every three seconds without reeling in, increase your fishing power by 1");

        if (level > 1)
            sb.Append(" + 1% (compounding)");
        
        return sb.Append(".\nEffect is lost upon reeling in.")
            .ToString();
    }

    public override string Name { get; } = "Virtuous Patience";

    public override int MaxLevel { get; } = 2;
}