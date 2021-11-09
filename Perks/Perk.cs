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

    public virtual void OnPlayerResetEffects() { }
    public virtual void OnPlayerPreUpdate() { }
    public virtual void OnPlayerPostUpdate() { }

    public virtual bool AllowCraftingPrefix(Item item, int prefix) => true;
    public virtual void OnPlayerCraftItem(Recipe recipe, Item item) { }
    public virtual void OnPlayerUseItem(Item item) { }
    
    public virtual void OnPlayerGetFishingLevel(Item fishingRod, Item bait, ref float fishingLevel) { }
    public virtual void OnPlayerModifyWeaponDamage(Item item, ref StatModifier damage, ref float flat) { }

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