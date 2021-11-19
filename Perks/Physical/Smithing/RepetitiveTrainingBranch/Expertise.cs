using TerrabornLeveling.Perks.Visualisers;

namespace TerrabornLeveling.Perks.Physical.Smithing.RepetitiveTrainingBranch;

[Parents(typeof(UniversalKnowledge))]
public class Expertise : Perk
{
    private string[] _categories = { "", "common", "universal", "specialization" };

    public Expertise() : base("expertise")
    {
    }

    public override string GetDescription(int level)
    {
        return $"Can choose a specific modifier amongst {_categories[level]} modifiers\nwhen crafting an item.";
    }

    public override string Name => "Expertise";
    public override IPerkVisualDescriptor Visuals { get; } = new PerkVisualDescriptor(new(.7f, .5f));
}