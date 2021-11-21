using Terraria.ID;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using ReLogic.Content;
using Terraria;
using Terraria.GameContent;
using Terraria.UI;

namespace TerrabornLeveling.Perks.Visualisers;

public class PerkVisualDescriptor : IPerkVisualDescriptor
{
    private static readonly Color 
        _lockedColor = new(1, 1, 1, 0.8f),
        _unlockedColor = Color.White;

    protected Vector2 size;

    public PerkVisualDescriptor(Vector2 position) : this(position, TextureAssets.Mana) { }

    public PerkVisualDescriptor(Vector2 position, Asset<Texture2D> icon)
    {
        Position = position;

        Icon = icon;
        if (!icon.IsLoaded)
        {
            Main.Assets.Request<Texture2D>(icon.Name, AssetRequestMode.ImmediateLoad);
        }

        var glow = TextureAssets.Projectile[ProjectileID.SandnadoHostileMark];
        if (!glow.IsLoaded)
        {
            Main.Assets.Request<Texture2D>(glow.Name, AssetRequestMode.ImmediateLoad);
        }
    }

    public PerkVisualDescriptor(Vector2 position, Vector2 size, Asset<Texture2D> icon) : this(position, icon)
    {
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

        if (perk.Unlocked)
            spriteBatch.Draw(TextureAssets.Projectile[ProjectileID.SandnadoHostileMark].Value, location - new Vector2(0, 1), null, new Color(0.55f, 0.55f, 0.55f), Rotation, new(36,36), scale, SpriteEffects.None, 0);

        DrawIcon(spriteBatch, Icon, location, perk.Unlocked ? _unlockedColor : _lockedColor, scale);
    } 

    protected virtual void DrawIcon(SpriteBatch spriteBatch, Asset<Texture2D> icon, Vector2 location, Color color, float scale)
    {
        // Icon
        spriteBatch.Draw(Icon.Value, location - new Vector2(0, 1), null, color, Rotation, Origin, scale, SpriteEffects.None, 0);
    }

    public Vector2 Position { get; set; }

    public virtual Vector2 Size
    {
        get => size == default ? size = Icon.Size() : size;
        set => size = value;
    }

    public Asset<Texture2D> Icon { get; set; }

    public virtual float Scale { get; set; } = 1f;
    public virtual float Rotation { get; set; }
    public virtual Vector2 Origin => new(Size.X / 2f, Size.Y / 2f);
}