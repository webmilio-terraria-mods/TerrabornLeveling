using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using ReLogic.Content;
using Terraria;

namespace TerrabornLeveling.Perks.Fishing;

[Parents(typeof(Patience))]
public class OneWithTheWater : Perk
{
    public OneWithTheWater() : base("onewiththewater")
    {
    }

    public override string GetDescription(int level)
    {
        return "You need 33% as much water to have maximum fishing power.";
    }

    public override string Name { get; } = "One With The Water";

    public override IPerkVisualDescriptor Visuals { get; } = new VisualDescriptor();

    public class VisualDescriptor : StandardPerkVisualDescriptor
    {
        private const int Width = 30, Height = 30;

        public VisualDescriptor() : base(new(0.5f, 0.1f), Main.Assets.Request<Texture2D>("Images/UI/Bestiary/Icon_Tags_Shadow"), new(Width, Height))
        {
        }

        protected override void DrawIcon(SpriteBatch spriteBatch, Asset<Texture2D> icon, Vector2 location, Color color, float scale)
        {
            spriteBatch.Draw(Icon.Value, 
                location, new Rectangle(360, Height, Width, Height), 
                color, 0, 
                new Vector2(Width / 2f, Height / 2f), scale, 
                SpriteEffects.None, 0);
        }
    }
}