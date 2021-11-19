namespace TerrabornLeveling.Perks.Physical.Smithing.Magic;

public abstract class MagicPerk : ModifiersUnlockingPerk
{
    protected const float
        XPosition = .5f,
        YPosition = .9f;

    private const string MagicFormat = "Unlocks the following modifiers for magic weapons:\n{0}";

    protected MagicPerk(string identifier) : base(identifier)
    {
    }

    protected override string GetDescriptionString()
    {
        return MagicFormat;
    }
}