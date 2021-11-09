using System.Collections.Generic;
using TerrabornLeveling.Players;
using TerrabornLeveling.Skills;
using Terraria;
using Terraria.ModLoader;

namespace TerrabornLeveling.Perks;

public interface IPerk
{
    public void OnPlayerResetEffects(TLPlayer player) { }

    public void OnPlayerPreUpdate(TLPlayer player) { }
    public void OnPlayerPostUpdate(TLPlayer player) { }

    public bool AllowCraftingPrefix(TLPlayer player, Item item, int prefix) => true;
    public void OnPlayerCraftItem(TLPlayer player, Recipe recipe, Item item) { }
    public void OnPlayerUseItem(TLPlayer player, Item item) { }

    public void OnPlayerGetFishingLevel(TLPlayer player, Item fishingRod, Item bait, ref float fishingLevel) { }
    public void OnPlayerModifyWeaponDamage(TLPlayer player, Item item, ref StatModifier damage, ref float flat) { }

    public bool TryLevel(Player player);
    public void Reset(Player player);

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

    public ISkill Skill { get; set; }
    public IList<IPerk> Parents { get; }
}