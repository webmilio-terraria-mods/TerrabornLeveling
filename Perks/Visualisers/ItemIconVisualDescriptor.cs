using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using ReLogic.Content;
using Terraria;
using Terraria.GameContent;
using Terraria.ID;

namespace TerrabornLeveling.Perks.Visualisers;

public class ItemIconVisualDescriptor : PerkVisualDescriptor
{
    public ItemIconVisualDescriptor(Vector2 position, int type) : base(position, TextureAssets.Item[type])
    {
        Type = type;
    }

    public int Type { get; }
}

public class AnimatedItemIconVisualDescriptor : ItemIconVisualDescriptor
{
    protected int timer;
    protected int frame;

    public AnimatedItemIconVisualDescriptor(Vector2 position, int type, int frameCount, int timePerFrame) : base(position, type)
    {
        FrameCount = frameCount;
        TimePerFrame = timePerFrame;
    }

    protected override void DrawIcon(SpriteBatch spriteBatch, Asset<Texture2D> icon, Vector2 location, Color color, float scale)
    {
        spriteBatch.Draw(icon.Value, location, new Rectangle(0, (int)Size.Y * frame, (int)Size.X, (int) Size.Y),
            color, Rotation, Origin, scale, SpriteEffects.None, 0);

        timer = (timer + 1) % TimePerFrame;

        if (timer == 0)
        {
            frame++;
        }

        if (frame >= FrameCount)
        {
            frame = 0;
        }
    }

    public int FrameCount { get; }
    public int TimePerFrame { get; }

    public override Vector2 Size
    {
        get
        {
            if (size == default)
            {
                var iconSize = Icon.Size();
                size = new(iconSize.X, iconSize.Y / FrameCount);
            }

            return size;
        }
    }
}