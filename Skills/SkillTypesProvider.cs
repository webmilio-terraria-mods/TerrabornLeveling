using System.Collections.Generic;
using System.Reflection;
using WebmilioCommons.DependencyInjection;
using WebmilioCommons.Loaders;

namespace TerrabornLeveling.Skills;

[Service]
public class SkillTypesProvider : Loader<ISkill>, ISkillTypesProvider
{
    private readonly List<TypeInfo> _skillTypes = new();

    public SkillTypesProvider()
    {
        Load();
    }

    public override void Load(Terraria.ModLoader.Mod mod, TypeInfo type)
    {
        _skillTypes.Add(type);
    }

    public IList<TypeInfo> GetSkillTypes() => _skillTypes;
}