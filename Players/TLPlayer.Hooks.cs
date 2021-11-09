using Terraria;
using Terraria.ModLoader;

namespace TerrabornLeveling.Players;

public partial class TLPlayer
{
    public override void PreUpdate() => ForUnlockedPerks(perk => perk.OnPlayerPreUpdate());
    public override void PostUpdate() => ForUnlockedPerks(perk => perk.OnPlayerPostUpdate());

    public override void GetFishingLevel(Item fishingRod, Item bait, ref float fishingLevel)
    {
        float x = fishingLevel;
        ForUnlockedPerks(perk => perk.OnPlayerGetFishingLevel(fishingRod, bait, ref x));
        fishingLevel = x;
    }

    public override void ModifyWeaponDamage(Item item, ref StatModifier damage, ref float flat)
    {
        StatModifier x = damage;
        float y = flat;
        ForUnlockedPerks(perk => perk.OnPlayerModifyWeaponDamage(item, ref x, ref y));
        damage = x;
        flat = y;
    }
}