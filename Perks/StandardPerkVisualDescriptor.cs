using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using ReLogic.Content;
using ReLogic.Graphics;
using Terraria;
using Terraria.GameContent;
using Terraria.UI;

namespace TerrabornLeveling.Perks;

public class StandardPerkVisualDescriptor : IPerkVisualDescriptor
{
    private bool _mouseLeft;

    public StandardPerkVisualDescriptor(Vector2 position) : this(position, TextureAssets.Mana) { }

    public StandardPerkVisualDescriptor(Vector2 position, Asset<Texture2D> icon) : this(position, icon, icon.Size()) { }

    public StandardPerkVisualDescriptor(Vector2 position, Asset<Texture2D> icon, Vector2 size)
    {
        Position = position;
        Icon = icon;
        Size = size;
    }

    public void DrawIcon(IPerk perk, SpriteBatch spriteBatch, UIElement container)
    {
        var scale = perk.Level > 0 ? 1.5f : 1f;

        var location = container.GetDimensions().Center();
        var iconWidth = Size.X * scale;
        var iconHeight = Size.Y * scale;

        // Mouseover Check
        /*bool mouseIntersects =
            new Rectangle(Main.mouseX, Main.mouseY, 1, 1).Intersects(new Rectangle((int)(location.X - iconWidth / 2f), (int)(location.Y - iconHeight / 2f), (int)iconWidth, (int)iconHeight));*/

        if (container.IsMouseHovering)
        {
            scale *= 1.5f;
        }

        DrawIcon(spriteBatch, Icon, location, scale);

        // Sets for checking ON CLICKED, not mouse down.
        _mouseLeft = Main.mouseLeft;
    }

    protected virtual void DrawIcon(SpriteBatch spriteBatch, Asset<Texture2D> icon, Vector2 location, float scale)
    {
        // Icon
        spriteBatch.Draw(Icon.Value, location - new Vector2(0, 1), null, new Color(1, 1, 1, scale), 0, new Vector2(Icon.Width() / 2f, Icon.Height() / 2f), scale, SpriteEffects.None, 0);
    }

    public Vector2 Position { get; }
    public Vector2 Size { get; }

    public Asset<Texture2D> Icon { get; }
}