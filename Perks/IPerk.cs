using System.Collections.Generic;
using TerrabornLeveling.Players;
using Terraria;

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

    public bool TryLevel(Player player);
    public void Reset(Player player);

    public string GetDescription(int level);

    public string Identifier { get; }
    public string Name { get; }

    public int RequiredSkill { get; }

    public int Level { get; }
    public int MaxLevel { get; }

    public bool Unlocked => Level > 0;

    public IPerkVisualDescriptor Visuals { get; }

    public IList<IPerk> Parents { get; }
}