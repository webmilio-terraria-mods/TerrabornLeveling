using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using TerrabornLeveling.Perks;
using WebmilioCommons.DependencyInjection;
using WebmilioCommons.Extensions;

namespace TerrabornLeveling.Skills.Factories;

[Service]
public class SkillFactory : ISkillFactory
{
    private static readonly Type _perkArray = typeof(IList<IPerk>);

    private readonly SimpleServices _services;
    private readonly IPerkFactory _perks;

    public SkillFactory(SimpleServices services, IPerkFactory perks)
    {
        _services = services;
        _perks = perks;
    }

    public ISkill Make<T>() where T : ISkill => Make(typeof(T));

    public ISkill Make(Type skillType)
    {
        ISkill skill;
        var perks = _perks.GetPerks(skillType);

        foreach (var constructor in skillType.GetConstructors())
        {
            try
            {
                skill = (ISkill)constructor.Invoke(new object[] { perks });
                perks.Do(p => p.Skill = skill);

                return skill;
            }
            catch
            {
                // Do nothing, go next.
            }
        }

        /*var constructor = GetConstructor(skillType);

        if (constructor != null)
        {
            return (ISkill) constructor.Invoke(new object[] { perks });
        }*/

        skill = (ISkill)_services.Make(skillType);

        if (skill != null)
        {
            var property = GetProperty(skillType);

            if (property != null)
                property.SetValue(skill, perks);
        }

        return skill;
    }

    private static readonly Type[] _constructorTypes = { _perkArray };
    private ConstructorInfo GetConstructor(Type type)
    {
        return type.GetConstructor(BindingFlags.Public, null, _constructorTypes, null);
    }

    private PropertyInfo GetProperty(Type type)
    {
        return type.GetProperties().FirstOrDefault(p => p.PropertyType == _perkArray && p.SetMethod != null);
    }
}