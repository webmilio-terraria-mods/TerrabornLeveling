using System.Collections.Generic;
using System.Linq;
using TerrabornLeveling.Players;
using TerrabornLeveling.Skills;
using Terraria;
using Terraria.ModLoader;

namespace TerrabornLeveling.Perks;

public abstract class Perk : IPerk
{
    protected Perk(string identifier)
    {
        Identifier = identifier;
    }

    public virtual void OnPostUpdate() { }
    public virtual void OnPreUpdate() { }
    public virtual void OnPreUpdateBuffs() { }
    public virtual void OnResetEffects() { }
    public virtual void OnUpdateEquips() { }
    public virtual void OnUpdateLifeRegen() { }

    public virtual bool AllowCraftingPrefix(Item item, int prefix) => true;
    public virtual void OnCraftItem(Recipe recipe, Item item) { }
    public virtual void OnUseItem(Item item) { }
    public virtual void OnUpdateInventoryItem(Item item) { }

    public virtual void OnGetFishingLevel(Item fishingRod, Item bait, ref float fishingLevel) { }

    public virtual void OnModifyWeaponDamage(Item item, ref StatModifier damage, ref float flat) { }
    public virtual void OnModifyWeaponCrit(Item item, ref int crit) { }
    public virtual void OnModifyManaCost(Item item, ref float reduce, ref float mult) { }

    public virtual void OnProjectileHitNPC(Projectile projectile, NPC target, int damage, float knockback, bool crit) { }
    public virtual void OnProjectileModifyHitNPC(Projectile projectile, NPC target, ref int damage, ref float knockback,
        ref bool crit, ref int hitDirection) { }

    public virtual void OnHitNPC(Item item, NPC target, ref int damage, ref float knockback, ref bool crit) { }
    public virtual void OnModifyHitNPC(Item item, NPC target, ref int damage, ref float knockback, ref bool crit) { }

    public virtual void OnModifyHitByNPC(NPC npc, ref int damage, ref bool crit) { }

    public virtual void OnRightClickTile(int x, int y, int type) { }

    public virtual void OnContextActionKeybind() { }

    public bool TryLevel()
    {
        if (!PreTryLevel())
            return false;

        if (!TerrabornLeveling.Development && Level < Skill.Level)
            return false;

        if (Level == MaxLevel)
            return false;

        if (Parents.Count > 0 && !Parents.Any(p => p.Unlocked))
            return false;

        if (!PreLevel())
            return false;

        Level++;
        OnLeveled();

        return true;
    }

    protected virtual bool PreTryLevel() => true;

    protected virtual bool PreLevel() => true;
    protected virtual void OnLeveled() { }

    public static int StepRequiredLevel(int jumps, int desiredLevel) => StepRequiredLevel(jumps, jumps, desiredLevel);

    public static int StepRequiredLevel(int startLevel, int jump, int desiredLevel)
    {
        // Not the most epic of methods.
        if (desiredLevel == 1)
            return startLevel;

        if (startLevel > 1)
            return startLevel + jump * (desiredLevel - 1);
        
        return jump * desiredLevel;
    }

    public void Reset()
    {
        Level = 0;
        OnReset(Owner.Player);
    }

    protected virtual void OnReset(Player player) { }

    public abstract string GetDescription(int level);
    public virtual int GetRequiredSkill(int level) => 0;

    public virtual string Identifier { get; set; }
    public abstract string Name { get; }

    public virtual int Level { get; set; }
    public virtual int MaxLevel => 1;

    public abstract IPerkVisualDescriptor Visuals { get; }

    public TLPlayer Owner { get; set; }
    public ISkill Skill { get; set; }
    public virtual IList<IPerk> Parents { get; } = new List<IPerk>();
}