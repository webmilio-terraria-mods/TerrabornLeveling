using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using ReLogic.Content;
using Terraria;
using Terraria.GameContent;

namespace TerrabornLeveling.Perks.Visualisers;

public class TypeIconVisualDescriptor : PerkVisualDescriptor
{
    public TypeIconVisualDescriptor(Vector2 position, Asset<Texture2D>[] source, int type) : base(position, source[type])
    {
        Type = type;
    }

    public int Type { get; }
}

public class StaticTypeIconVisualDescriptor : TypeIconVisualDescriptor
{
    public StaticTypeIconVisualDescriptor(Vector2 position, Asset<Texture2D>[] source, int type, int frameCount, int frame) : base(position, source, type)
    {
        FrameCount = frameCount;
        Frame = frame;
    }

    protected override void DrawIcon(SpriteBatch spriteBatch, Asset<Texture2D> icon, Vector2 location, Color color, float scale)
    {
        spriteBatch.Draw(icon.Value, location, new Rectangle(0, (int)Size.Y * Frame, (int)Size.X, (int)Size.Y),
            color, Rotation, Origin, scale, SpriteEffects.None, 0);
    }

    public int FrameCount { get; }
    public int Frame { get; }

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

public class AnimatedTypeIconVisualDescriptor : TypeIconVisualDescriptor
{
    protected int timer;
    protected int frame;

    public AnimatedTypeIconVisualDescriptor(Vector2 position, Asset<Texture2D>[] source, int type, int frameCount, int timePerFrame) : base(position, source, type)
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