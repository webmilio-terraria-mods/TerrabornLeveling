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
    protected readonly Dictionary<Type, List<Type>> map = new();

    public PerkSkillAttributeMapper()
    {
        Load();
    }

    public Type[] GetPerkTypes(Type skillType)
    {
        return map.TryGetValue(skillType, out var perks) ? perks.ToArray() : null;
    }

    public override void Load(Terraria.ModLoader.Mod mod, TypeInfo type)
    {
        if (!type.TryGetCustomAttribute(out SkillAttribute attr))
            return;

        if (!map.TryGetValue(attr.SkillType, out var types))
        {
            map.Add(attr.SkillType, types = new());
        }

        types.Add(type);
    }
}