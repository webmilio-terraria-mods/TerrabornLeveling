namespace TerrabornLeveling.Perks.Smithing.Ranged;

public abstract class RangedPerk : ModifiersUnlockingPerk
{
    protected const float 
        XPosition = .30f,
        YPosition = .85f;

    private const string RangedFormat = "Unlocks the {0} and {1} modifiers for ranged weapons.";

    protected RangedPerk(string identifier) : base(identifier)
    {
    }

    protected override string GetDescriptionString()
    {
        return RangedFormat;
    }
}