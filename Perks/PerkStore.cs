using System.Reflection;
using WebmilioCommons;

namespace TerrabornLeveling.Perks;

public class PerkStore : IPerkTypeStore
{
    private readonly TypeInfo[] _perkTypes;

    public PerkStore()
    {
        _perkTypes = ModStore.OfType<IPerk>().ToArray();
    }

    public int Count => _perkTypes.Length;

    public TypeInfo this[int index] => _perkTypes[index];
}