using TerrabornLeveling.Players;
using WebmilioCommons.Extensions;

namespace TerrabornLeveling.Perks.Smithing;

public abstract class ModifiersUnlockingPerk : Perk
{
    protected const string MeleeFormat = "Unlocks the {0} and {1} modifiers for melee weapons.";

    protected ModifiersUnlockingPerk(string identifier) : base(identifier)
    {
    }

    public override void OnPlayerResetEffects(TLPlayer player)
    {
        Unlocks.Do(id => player.ModifiersAccess[id] = true);
    }

    protected abstract int[] Unlocks { get; }
}