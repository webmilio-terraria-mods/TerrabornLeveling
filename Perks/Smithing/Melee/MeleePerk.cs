using System;

namespace TerrabornLeveling.Perks.Smithing.Melee;

public abstract class MeleePerk : ModifiersUnlockingPerk
{
    protected const float 
        XPosition = 0,
        YPosition = .9f;

    private const string MeleeFormat = "Unlocks the {0} and {1} modifiers for melee weapons.";

    protected MeleePerk(string identifier) : base(identifier)
    {
    }

    protected override string GetDescriptionString()
    {
        return MeleeFormat;
    }
}