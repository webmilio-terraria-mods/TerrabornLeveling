using System.Collections.Generic;
using TerrabornLeveling.Players;
using TerrabornLeveling.Skills;
using Terraria;
using Terraria.ModLoader;

namespace TerrabornLeveling.Perks;

public interface IPerk
{
    public void OnPlayerResetEffects() { }

    public void OnPlayerPreUpdate() { }
    public void OnPlayerPostUpdate() { }

    public bool AllowCraftingPrefix(Item item, int prefix) => true;
    public void OnPlayerCraftItem(Recipe recipe, Item item) { }
    public void OnPlayerUseItem(Item item) { }

    public void OnPlayerGetFishingLevel(Item fishingRod, Item bait, ref float fishingLevel) { }
    public void OnPlayerModifyWeaponDamage(Item item, ref StatModifier damage, ref float flat) { }

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