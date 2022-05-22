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

    public override void ModifyWeaponCrit(Item item, ref float crit)
    {
        float rCrit = crit;
        ForUnlockedPerks(perk => perk.OnModifyWeaponCrit(item, ref rCrit));
        crit = rCrit;
    }

    public override void ModifyWeaponDamage(Item item, ref StatModifier damage)
    {
        StatModifier stats = damage;
        float rFlat = 0;

        ForUnlockedPerks(perk => perk.OnModifyWeaponDamage(item, ref stats, ref rFlat));

        damage = stats;
        // flat = rFlat;
    }

    public void OnProjectileModifyHitNPC(Projectile projectile, NPC target, ref int damage, ref float knockback,
        ref bool crit, ref int hitDirection)
    {
        int rDamage = damage;
        float rKnockback = knockback;
        bool rCrit = crit;
        int rHitDirection = hitDirection;

        ForUnlockedPerks(perk => perk.OnProjectileModifyHitNPC(projectile, target, ref rDamage, ref rKnockback, ref rCrit, ref rHitDirection));

        damage = rDamage;
        knockback = rKnockback;
        crit = rCrit;
        hitDirection = rHitDirection;
    }

    public void OnProjectileHitNPC(Projectile projectile, NPC target, int damage, float knockback, bool crit)
    {
        ForUnlockedPerks(perk => perk.OnProjectileHitNPC(projectile, target, damage, knockback, crit));
    }

    public override void PostUpdate() => ForUnlockedPerks(perk => perk.OnPostUpdate());
    public override void PreUpdate() => ForUnlockedPerks(perk => perk.OnPreUpdate());
    public override void PreUpdateBuffs() => ForUnlockedPerks(perk => perk.OnPreUpdateBuffs());

    public override void UpdateLifeRegen() => ForUnlockedPerks(perk => perk.OnUpdateLifeRegen());

    public void UpdateInventory(Item item)
    {
        ForUnlockedPerks(perk => perk.OnUpdateInventoryItem(item));
    }
}