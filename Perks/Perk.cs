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

    public virtual void OnResetEffects() { }
    public virtual void OnPreUpdate() { }
    public virtual void OnPostUpdate() { }

    public virtual bool AllowCraftingPrefix(Item item, int prefix) => true;
    public virtual void OnCraftItem(Recipe recipe, Item item) { }
    public virtual void OnUseItem(Item item) { }
    public virtual void OnUpdateInventoryItem(Item item) { }

    public virtual void OnGetFishingLevel(Item fishingRod, Item bait, ref float fishingLevel) { }

    public virtual void OnModifyWeaponDamage(Item item, ref StatModifier damage, ref float flat) { }
    public virtual void OnModifyManaCost(Item item, ref float reduce, ref float mult) { }

    public bool TryLevel()
    {
        if (Level == MaxLevel)
            return false;

        if (Parents.Count > 0 && !Parents.Any(p => p.Unlocked))
            return false;

        Level++;
        OnLeveled(Owner.Player);

        return true;
    }

    protected virtual void OnLeveled(Player player) { }

    public static int StepRequiredLevel(int startLevel, int jump, int desiredLevel)
    {
        return desiredLevel == 1 ? startLevel : jump * desiredLevel;
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
    public virtual int MaxLevel { get; } = 1;
    
    public abstract IPerkVisualDescriptor Visuals { get; }

    public TLPlayer Owner { get; set; }
    public ISkill Skill { get; set; }
    public virtual IList<IPerk> Parents { get; } = new List<IPerk>();
}