using System.Collections.Generic;
using System.Linq;
using TerrabornLeveling.Players;
using Terraria;
using Terraria.ModLoader;

namespace TerrabornLeveling.Perks;

public abstract class Perk : IPerk
{
    protected Perk(string identifier)
    {
        Identifier = identifier;
    }

    public virtual void OnPlayerResetEffects(TLPlayer player) { }
    public virtual void OnPlayerPreUpdate(TLPlayer player) { }
    public virtual void OnPlayerPostUpdate(TLPlayer player) { }

    public virtual bool AllowCraftingPrefix(TLPlayer player, Item item, int prefix) => true;
    public virtual void OnPlayerCraftItem(TLPlayer player, Recipe recipe, Item item) { }
    public virtual void OnPlayerUseItem(TLPlayer player, Item item) { }
    
    public virtual void OnPlayerGetFishingLevel(TLPlayer player, Item fishingRod, Item bait, ref float fishingLevel) { }
    public virtual void OnPlayerModifyWeaponDamage(TLPlayer player, Item item, ref StatModifier damage, ref float flat) { }

    public bool TryLevel(Player player)
    {
        if (Level == MaxLevel)
            return false;

        if (Parents.Count > 0 && !Parents.Any(p => p.Unlocked))
            return false;

        Level++;
        OnLeveled(player);

        return true;
    }

    protected virtual void OnLeveled(Player player) { }

    public void Reset(Player player)
    {
        Level = 0;
        OnReset(player);
    }

    protected virtual void OnReset(Player player) { }

    public abstract string GetDescription(int level);
    public virtual int GetRequiredSkill(int level) => 0;

    public virtual string Identifier { get; set; }
    public abstract string Name { get; }

    public virtual int Level { get; set; }
    public virtual int MaxLevel { get; } = 1;
    
    public abstract IPerkVisualDescriptor Visuals { get; }

    public virtual IList<IPerk> Parents { get; } = new List<IPerk>();
}