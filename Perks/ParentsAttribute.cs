using System;

namespace TerrabornLeveling.Perks;

[AttributeUsage(AttributeTargets.Class)]
public class ParentsAttribute : Attribute
{
    public ParentsAttribute(params Type[] parents)
    {
        if (parents.Length == 0)
            throw new ArgumentException("You must specify at least one parent.");

        Parents = parents;
    }

    public Type[] Parents { get; }
}