using Terraria;
using Terraria.ModLoader;

namespace TerrabornLeveling.Players;

public partial class TLPlayer
{
    public override void GetFishingLevel(Item fishingRod, Item bait, ref float fishingLevel)
    {
        float rLevel = fishingLevel;
        ForUnlockedPerks(perk => perk.OnGetFishingLevel(fishingRod, bait, ref rLevel));
        fishingLevel = rLevel;
    }

    public override void ModifyManaCost(Item item, ref float reduce, ref float mult)
    {
        float rReduce = reduce;
        float rMult = mult;

        ForUnlockedPerks(perk => perk.OnModifyManaCost(item, ref rReduce, ref rMult));

        mult = rMult;
        reduce = rReduce;
    }

    public override void ModifyWeaponDamage(Item item, ref StatModifier damage, ref float flat)
    {
        StatModifier stats = damage;
        float rFlat = flat;

        ForUnlockedPerks(perk => perk.OnModifyWeaponDamage(item, ref stats, ref rFlat));

        damage = stats;
        flat = rFlat;
    }

    public override void PreUpdate() => ForUnlockedPerks(perk => perk.OnPreUpdate());
    public override void PostUpdate() => ForUnlockedPerks(perk => perk.OnPostUpdate());

    public void UpdateInventory(Item item)
    {
        ForUnlockedPerks(perk => perk.OnUpdateInventoryItem(item));
    }
}