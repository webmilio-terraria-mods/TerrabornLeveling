using Microsoft.Xna.Framework;

namespace TerrabornLeveling.Perks;

public abstract class StandardPerk : Perk
{
    protected StandardPerk(string identifier, Vector2 position)
    {
        Identifier = identifier;

        Visuals = new StandardPerkVisualDescriptor(position);
    }

    public override IPerkVisualDescriptor Visuals { get; }
}