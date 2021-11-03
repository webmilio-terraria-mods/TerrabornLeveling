using static Terraria.ID.PrefixID;

namespace TerrabornLeveling.Perks.Smithing.RepetitiveTrainingBranch;

[Parents(typeof(RepetitiveTraining))]
public class UniversalKnowledge : ModifiersUnlockingPerk
{
    private static readonly int[] _unlocks =
    {
        Broken, Damaged, Demonic, Forceful, Godly, Hurtful, Keen,
        Shoddy, Strong, Superior, Unpleasant, Weak, Zealous
    };

    public UniversalKnowledge() : base("universalknowledge")
    {
    }

    public override string GetDescription(int level)
    {
        return "Unlocks the various universal crafting modifiers:\n" +
               "Broken, Damaged, Demonic, Forceful, Godly, Hurtful, Keen, Ruthless,\n" +
               "Shoddy, Strong, Superior, Unpleasant, Weak, Zealous";
    }

    public override string Name { get; } = "Universal Knowledge";

    protected override int[] Unlocks { get; } = _unlocks;

    public override IPerkVisualDescriptor Visuals { get; } = new StandardPerkVisualDescriptor(new(.5f, .6f));
}