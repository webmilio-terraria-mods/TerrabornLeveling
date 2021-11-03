using System;
using System.Collections.Generic;
using System.Reflection;
using TerrabornLeveling.Perks;
using WebmilioCommons.DependencyInjection;
using WebmilioCommons.Extensions;
using WebmilioCommons.Loaders;

namespace TerrabornLeveling.Skills.Mapping;

[Service]
public class PerkSkillAttributeMapper : Loader<IPerk>, IPerkMapper
{
    protected List<Type> parentMap = new();
    protected readonly Dictionary<Type, Type> perkToSkill = new();
    protected readonly Dictionary<Type, List<Type>> skillToPerks = new();

    public PerkSkillAttributeMapper()
    {
        Load();
    }

    public Type[] GetPerkTypes(Type skillType)
    {
        return skillToPerks.TryGetValue(skillType, out var perks) ? perks.ToArray() : null;
    }

    public Type GetSkillType(Type perkType)
    {
        return perkToSkill.TryGetValue(perkType, out var skill) ? skill : null;
    }

    public override void Load(Terraria.ModLoader.Mod mod, TypeInfo perkType)
    {
        if (!perkType.TryGetCustomAttribute(out SkillAttribute attr))
        {
            parentMap.Add(perkType);
            return;
        }

        Map(attr.SkillType, perkType);
    }

    private void Map(Type skill, Type perk)
    {
        if (!skillToPerks.TryGetValue(skill, out var types))
        {
            skillToPerks.Add(skill, types = new());
        }

        perkToSkill.Add(perk, skill);
        types.Add(perk);
    }

    public override void PostLoad()
    {
        int count = 0;
        int max = parentMap.Count;

        while (parentMap.Count > 0 && count < max)
        {
            GetSkillFromParent(parentMap[0]);
        }
    }

    private Type GetSkillFromParent(Type perk)
    {
        if (!perk.TryGetCustomAttribute(out ParentsAttribute attr))
            return null;

        if (!perkToSkill.TryGetValue(attr.Parents[0], out var skill))
            skill = GetSkillFromParent(attr.Parents[0]);

        if (skill != null)
            Map(skill, perk);

        parentMap.Remove(perk);
        return skill;
    }
}