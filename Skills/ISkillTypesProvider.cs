using System.Collections.Generic;
using System.Reflection;

namespace TerrabornLeveling.Skills;

public interface ISkillTypesProvider
{
    public IList<TypeInfo> GetSkillTypes();
}