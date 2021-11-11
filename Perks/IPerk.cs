﻿using System.Collections.Generic;
using TerrabornLeveling.Players;
using TerrabornLeveling.Skills;
using Terraria;
using Terraria.ModLoader;

namespace TerrabornLeveling.Perks;

public interface IPerk
{
    public virtual bool AllowCraftingPrefix(Item item, int prefix) => true;
    public virtual void OnCraftItem(Recipe recipe, Item item) { }
    public virtual void OnUpdateInventoryItem(Item item) { }
    public virtual void OnUseItem(Item item) { }

    public virtual void OnGetFishingLevel(Item fishingRod, Item bait, ref float fishingLevel) { }
    
    public virtual void OnModifyManaCost(Item item, ref float reduce, ref float mult) { }
    public virtual void OnModifyWeaponDamage(Item item, ref StatModifier damage, ref float flat) { }

    public virtual void OnPreUpdate() { }
    public virtual void OnPostUpdate() { }

    public virtual void OnResetEffects() { }

    public bool TryLevel();
    public void Reset();

    public string GetDescription(int level);

    public string Identifier { get; }
    public string Name { get; }

    public int RequiredSkillForNext => GetRequiredSkill(Level + 1);
    public int GetRequiredSkill(int level);

    public int Level { get; }
    public int MaxLevel { get; }

    public bool Unlocked => Level > 0;
    public bool Maxed => Level == MaxLevel;

    public IPerkVisualDescriptor Visuals { get; }

    public TLPlayer Owner { get; set; }
    public ISkill Skill { get; set; }
    public IList<IPerk> Parents { get; }
}