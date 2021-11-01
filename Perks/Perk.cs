using System.Collections.Generic;
using Terraria;

namespace TerrabornLeveling.Perks;

public abstract class Perk : IPerk
{
    public bool TryLevel(Player player)
    {
        if (Level == MaxLevel)
            return false;

        Level++;
        OnLeveled(player);

        return true;
    }

    protected virtual void OnLeveled(Player player) { }

    public void Reset(Player player)
    {
        Level = 0;
        OnReset(player);
    }

    protected virtual void OnReset(Player player) { }

    public abstract string GetDescription(int level);

    public virtual string Identifier { get; set; }
    public abstract string Name { get; }

    public virtual int RequiredSkill { get; }

    public virtual int Level { get; set; }
    public virtual int MaxLevel { get; } = 1;
    
    public abstract IPerkVisualDescriptor Visuals { get; }

    public virtual IList<IPerk> Children { get; } = new List<IPerk>();
}