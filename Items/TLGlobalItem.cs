using TerrabornLeveling.Players;
using Terraria;
using Terraria.ModLoader;

namespace TerrabornLeveling.Items;

public class TLGlobalItem : GlobalItem
{
    public override bool AllowPrefix(Item item, int pre)
    {
        if (pre == 0 || item != Main.mouseItem)
        {
            return true;
        }

        return TLPlayer.Get().AllowCraftingPrefix(item, pre);
    }

    public override void UpdateInventory(Item item, Player player)
    {
        TLPlayer.Get(player).UpdateInventory(item);
    }

    public override bool? UseItem(Item item, Player player)
    {
        var tlPlayer = TLPlayer.Get(player);
        tlPlayer.ForUnlockedPerks(perk => perk.OnUseItem(item));

        return null;
    }
}