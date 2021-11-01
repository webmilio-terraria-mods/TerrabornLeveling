using System.Collections.Generic;
using TerrabornLeveling.Skills;
using TerrabornLeveling.Skills.Factories;
using Terraria;
using Terraria.ModLoader;
using Terraria.ModLoader.IO;
using WebmilioCommons;
using WebmilioCommons.Players;
using WebmilioCommons.Saving;

namespace TerrabornLeveling.Players;

public class TLPlayer : BetterModPlayer
{
    public static TLPlayer Get() => Get(Main.LocalPlayer);
    public static TLPlayer Get(Player player) => player.GetModPlayer<TLPlayer>();

    private List<ISkill> _skills;

    public override void OnEnterWorld(Player player)
    {
        Mod.Logger.Info($"Loaded {Skills.Count} skill(s) for player {player.name}.");
        ModContent.GetInstance<TerrabornLevelingSystem>().Layer.State.PopulateSkills(this);
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
}