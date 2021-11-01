using System;
using TerrabornLeveling.Perks;

namespace TerrabornLeveling.Skills.Factories;

public interface IPerkFactory
{
    public IPerk[] GetPerks(Type skillType);
}