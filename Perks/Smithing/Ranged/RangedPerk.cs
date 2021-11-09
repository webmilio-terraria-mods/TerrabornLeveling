namespace TerrabornLeveling.Perks.Smithing.Ranged;

public abstract class RangedPerk : ModifiersUnlockingPerk
{
    protected const float 
        XPosition = .25f,
        YPosition = .825f;

    private const string RangedFormat = "Unlocks the following modifiers for ranged weapons:\n{0}";

    protected RangedPerk(string identifier) : base(identifier)
    {
    }

    protected override string GetDescriptionString()
    {
        return RangedFormat;
    }
}