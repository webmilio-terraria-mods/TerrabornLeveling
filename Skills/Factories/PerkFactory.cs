using System;
using System.Collections.Generic;
using System.Linq;
using TerrabornLeveling.Perks;
using TerrabornLeveling.Skills.Mapping;
using WebmilioCommons;
using WebmilioCommons.DependencyInjection;
using WebmilioCommons.Extensions;

namespace TerrabornLeveling.Skills.Factories;

[Service]
public class PerkFactory : IPerkFactory
{
    protected List<IPerkMapper> mappers;
    protected readonly Dictionary<Type, List<Type>> map = new();
    
    public IPerk[] GetPerks(Type skillType)
    {
        if (!map.TryGetValue(skillType, out var perkTypes))
        {
            if (mappers == null)
            {
                mappers = new();
                ModStore.ForTypes<IPerkMapper>(type => mappers.Add(GetMapper(type)));
            }

            perkTypes = new();
            mappers.Do(delegate(IPerkMapper mapper)
            {
                var perks = GetPerkTypes(mapper, skillType);

                if (perks != null)
                    perkTypes.AddRange(perks);
            });
        }

        var perk = new IPerk[perkTypes.Count];
        Dictionary<Type, IPerk> perkMap = new(perk.Length);

        perkTypes.Do(delegate(Type type, int i)
        {
            perk[i] = GetPerk(type);
            perkMap.Add(type, perk[i]);
        });

        perkMap.Do(delegate(KeyValuePair<Type, IPerk> pair)
        {
            if (!pair.Key.TryGetCustomAttribute(out ParentsAttribute attr))
            {
                return;
            }

            attr.Parents.Do(delegate(Type parent)
            {
                pair.Value.Parents.Add(perkMap[parent]);
            });
        });
        
        return perkMap.Values.ToArray();
    }

    private static IPerkMapper GetMapper(Type mapperType)
    {
        return Activator.CreateInstance(mapperType) as IPerkMapper;
    }

    private IEnumerable<Type> GetPerkTypes(IPerkMapper mapper, Type skillType)
    {
        return mapper.GetPerkTypes(skillType);
    }

    private static IPerk GetPerk(Type perkType)
    {
        return Activator.CreateInstance(perkType) as IPerk;
    }
}