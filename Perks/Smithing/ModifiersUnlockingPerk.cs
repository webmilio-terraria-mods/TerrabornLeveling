using System;
using System.Text;
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
        StringBuilder sb = new();

        int lines = 1;
        UnlockNames.Do((n, i) =>
        {
            if (sb.Length + n.Length > 48 * lines)
            {
                sb.AppendLine();
                lines++;
            }

            sb.Append(n);

            if (i + 1 < UnlockNames.Length)
                sb.Append(", ");
        });

        return string.Format(GetDescriptionString(), sb);
    }

    protected abstract string GetDescriptionString();

    public override int GetRequiredSkill(int level)
    {
        return RequiredSkill;
    }

    protected abstract int RequiredSkill { get; }

    protected abstract int[] Unlocks { get; }
    protected abstract string[] UnlockNames { get; }
}