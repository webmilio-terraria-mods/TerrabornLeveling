using TerrabornLeveling.Perks.Visualisers;
using static Terraria.ID.PrefixID;

namespace TerrabornLeveling.Perks.Physical.Smithing.RepetitiveTrainingBranch;

[Parents(typeof(RepetitiveTraining))]
public class UniversalKnowledge : ModifiersUnlockingPerk
{
    private const string Description = "Unlocks the various universal crafting modifiers:\n{0}";

    public UniversalKnowledge() : base("universalknowledge")
    {
    }

    protected override string GetDescriptionString()
    {
        return Description;
    }

    protected override int RequiredSkill => 50;

    public override string Name => "Universal Knowledge";

    protected override int[] Unlocks { get; } = { Broken, Damaged, Demonic, Forceful, Godly, Hurtful, Keen, Shoddy, Strong, Superior, Unpleasant, Weak, Zealous };
    protected override string[] UnlockNames { get; } =
    {
        nameof(Broken), nameof(Damaged), nameof(Demonic), nameof(Forceful), nameof(Godly), nameof(Hurtful), nameof(Keen), 
        nameof(Shoddy), nameof(Strong), nameof(Superior), nameof(Unpleasant), nameof(Weak), nameof(Zealous)
    };

    public override IPerkVisualDescriptor Visuals { get; } = new PerkVisualDescriptor(new(.75f, .66f));
}