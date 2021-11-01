using System;
using System.Reflection;

namespace TerrabornLeveling.Skills.Mapping;

public interface IPerkMapper
{
    public Type[] GetPerkTypes(Type skillType);
}