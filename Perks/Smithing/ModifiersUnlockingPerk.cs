using System;
using TerrabornLeveling.Players;
using WebmilioCommons.Extensions;

namespace TerrabornLeveling.Perks.Smithing;

public abstract class ModifiersUnlockingPerk : Perk
{
    protected const float YOffset = .1f;

    protected ModifiersUnlockingPerk(string identifier) : base(identifier)
    {
    }

    public override void OnPlayerResetEffects(TLPlayer player)
    {
        Unlocks.Do(id => player.ModifiersAccess[id] = true);
    }

    public override string GetDescription(int level)
    {
        return string.Format(GetDescriptionString(), UnlockNames);
    }

    protected abstract string GetDescriptionString();

    public override int GetRequiredSkill(int level)
    {
        return RequiredSkill;
    }

    protected abstract int RequiredSkill { get; }

    protected abstract int[] Unlocks { get; }
    protected abstract object[] UnlockNames { get; }
}