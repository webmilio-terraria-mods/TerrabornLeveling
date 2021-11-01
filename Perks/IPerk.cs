using System.Collections.Generic;
using Terraria;

namespace TerrabornLeveling.Perks;

public interface IPerk
{
    public bool TryLevel(Player player);
    public void Reset(Player player);

    public string GetDescription(int level);

    public string Identifier { get; }
    public string Name { get; }

    public int RequiredSkill { get; }

    public int Level { get; }
    public int MaxLevel { get; }

    public IPerkVisualDescriptor Visuals { get; }

    public IList<IPerk> Children { get; }
}