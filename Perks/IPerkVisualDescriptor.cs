using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using ReLogic.Content;
using Terraria.UI;

namespace TerrabornLeveling.Perks;

public interface IPerkVisualDescriptor
{
    public void DrawIcon(IPerk perk, SpriteBatch spriteBatch, UIElement container);

    public Vector2 Position { get; set; } // TODO Remove this.
    public Vector2 Size { get; }

    public Asset<Texture2D> Icon { get; }
}