using System.Linq;
using TerrabornLeveling.Players;
using Terraria;
using WebmilioCommons.Extensions;

namespace TerrabornLeveling.Perks;

public abstract class UnlockCondition
{
    public abstract bool Check(TLPlayer player);

    public virtual void PreLevelUp(TLPlayer player, int level) { }

    public abstract string Text { get; }

    public class ItemCondition : UnlockCondition
    {
        private readonly Item _required;

        public ItemCondition(Item required)
        {
            _required = required;
        }

        public override bool Check(TLPlayer player)
        {
            var item = player.Player.GetItemsByType(_required.type, inventory: true);
            var stack = item.Sum(i => i.stack);

            return stack >= _required.stack;
        }

        public override void PreLevelUp(TLPlayer player, int level)
        {
            for (int i = 0; i < _required.stack; i++)
                player.Player.ConsumeItem(_required.type);
        }

        public override string Text => $"Leveling this perk consumes {_required.stack} {_required.Name}{(_required.stack > 1 ? "s" : "")}.";
    }

    public class ExpertCondition : UnlockCondition
    {
        public override bool Check(TLPlayer player)
        {
            return player.Player.extraAccessory;
        }

        public override void PreLevelUp(TLPlayer player, int level) { }

        public override string Text => "You must have your 6th accessory slot to obtain level this perk.";
    }
}