namespace TerrabornLeveling.Perks.Smithing.Magic;

public abstract class MagicPerk : ModifiersUnlockingPerk
{
    protected const float
        XPosition = .6f,
        YPosition = .9f;

    private const string MagicFormat = "Unlocks the {0} and {1} modifiers for magic weapons.";

    protected MagicPerk(string identifier) : base(identifier)
    {
    }

    protected override string GetDescriptionString()
    {
        return MagicFormat;
    }
}