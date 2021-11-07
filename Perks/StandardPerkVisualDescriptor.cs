using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using ReLogic.Content;
using Terraria;
using Terraria.GameContent;
using Terraria.UI;

namespace TerrabornLeveling.Perks;

public class StandardPerkVisualDescriptor : IPerkVisualDescriptor
{
    private static readonly Color 
        _lockedColor = new(1, 1, 1, 0.8f),
        _unlockedColor = Color.White;

    private Vector2 _size;

    public StandardPerkVisualDescriptor(Vector2 position) : this(position, TextureAssets.Mana) { }

    public StandardPerkVisualDescriptor(Vector2 position, Asset<Texture2D> icon) : this(position, icon.Size(), icon) { }

    public StandardPerkVisualDescriptor(Vector2 position, Vector2 size, Asset<Texture2D> icon)
    {
        Position = position;
        Icon = icon;
        Size = size;
    }

    public void DrawIcon(IPerk perk, SpriteBatch spriteBatch, UIElement container)
    {
        var scale = (float) perk.Level / perk.MaxLevel * .25f + Scale;
        var location = container.GetDimensions().Center();

        // Mouseover Check
        /*bool mouseIntersects =
            new Rectangle(Main.mouseX, Main.mouseY, 1, 1).Intersects(new Rectangle((int)(location.X - iconWidth / 2f), (int)(location.Y - iconHeight / 2f), (int)iconWidth, (int)iconHeight));*/

        if (container.IsMouseHovering)
        {
            scale = Scale + .5f;
        }

        DrawIcon(spriteBatch, Icon, location, perk.Unlocked ? _unlockedColor : _lockedColor, scale);
    } 

    protected virtual void DrawIcon(SpriteBatch spriteBatch, Asset<Texture2D> icon, Vector2 location, Color color, float scale)
    {
        // Icon
        spriteBatch.Draw(Icon.Value, location - new Vector2(0, 1), null, color, 0, new Vector2(Size.X / 2f, Size.Y / 2f), scale, SpriteEffects.None, 0);
    }

    public Vector2 Position { get; }

    public Vector2 Size
    {
        get => _size == default ? _size = Icon.Size() : _size;
        set => _size = value;
    }

    public Asset<Texture2D> Icon { get; set; }

    public float Scale { get; set; } = 1f;
}