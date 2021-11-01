using System.Reflection;

namespace TerrabornLeveling.Perks;

public interface IPerkTypeStore
{
    public int Count { get; }

    public TypeInfo this[int index] { get; }
}