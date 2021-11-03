using System;
using System.Collections.Generic;
using TerrabornLeveling.Perks;
using TerrabornLeveling.Skills;
using TerrabornLeveling.Skills.Factories;
using Terraria;
using Terraria.Audio;
using Terraria.ModLoader;
using Terraria.ModLoader.IO;
using WebmilioCommons.Extensions;
using WebmilioCommons.Players;

namespace TerrabornLeveling.Players;

public partial class TLPlayer : BetterModPlayer
{
    public static TLPlayer Get() => Get(Main.LocalPlayer);
    public static TLPlayer Get(Player player) => player.GetModPlayer<TLPlayer>();

    private List<ISkill> _skills;

    public TLPlayer()
    {
        ModifiersAccess = new bool[PrefixLoader.PrefixCount];
    }

    public override void ResetEffects()
    {
        ModifiersAccess.Do((_, i) => ModifiersAccess[i] = false);
        ModifiersAccess[0] = true;

        ForUnlockedPerks(perk => perk.OnPlayerResetEffects(this));
    }

    public void ForUnlockedPerks(Action<IPerk> action) => Skills.Do(s => s.ForUnlockedPerks(action));
    public bool TrueForAllUnlockedPerks(Predicate<IPerk> predicate) => Skills.TrueForAll(s => s.TrueForAllUnlockedPerks(predicate));

    public override void OnEnterWorld(Player player)
    {
        Mod.Logger.Info($"Loaded {Skills.Count} skill(s) for player {player.name}.");
        ModContent.GetInstance<TerrabornLevelingSystem>().Layer.State.PopulateSkills(this);
    }

    public bool AllowCraftingPrefix(Item item, int prefix)
    {
        // Check if the player has access to these modifiers.
        return ModifiersAccess[prefix] && TrueForAllUnlockedPerks(perk => perk.AllowCraftingPrefix(this, item, prefix));
    }
    
    public override void CraftItem(Recipe recipe, Item item)
    {
        ForUnlockedPerks(perk => perk.OnPlayerCraftItem(this, recipe, item));

        /*while (!ModifiersAccess[item.prefix])
            item.Prefix(-1);*/
    }

    private static List<ISkill> CreateSkills()
    {
        var provider = TerrabornLeveling.Services.GetService<ISkillTypesProvider>();
        var factory = TerrabornLeveling.Services.GetService<ISkillFactory>();

        List<ISkill> skills = new(); // We use a list instead of an array since it's possible a skill type can't be initialized properly.

        foreach (var type in provider.GetSkillTypes())
            skills.Add(factory.Make(type));

        return skills;
    }

    protected override void ModLoad(TagCompound tag)
    {
        base.ModLoad(tag);
    }

    protected override void ModSave(TagCompound tag)
    {
        base.ModSave(tag);
    }

    public List<ISkill> Skills
    {
        get => _skills ??= CreateSkills();
        set => _skills = value;
    }

    public bool[] ModifiersAccess { get; }
    public float BadModifierMod { get; }
}