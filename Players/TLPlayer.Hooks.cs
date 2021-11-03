using Terraria;

namespace TerrabornLeveling.Players;

public partial class TLPlayer
{
    public override void PreUpdate() => ForUnlockedPerks(perk => perk.OnPlayerPreUpdate(this));
    public override void PostUpdate() => ForUnlockedPerks(perk => perk.OnPlayerPostUpdate(this));

    public override void GetFishingLevel(Item fishingRod, Item bait, ref float fishingLevel)
    {
        float x = fishingLevel;
        ForUnlockedPerks(perk => perk.OnPlayerGetFishingLevel(this, fishingRod, bait, ref x));
        fishingLevel = x;
    }
}