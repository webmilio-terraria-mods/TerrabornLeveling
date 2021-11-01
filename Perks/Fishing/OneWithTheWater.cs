using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using ReLogic.Content;
using TerrabornLeveling.Skills;
using Terraria;
using Terraria.GameContent;

namespace TerrabornLeveling.Perks.Fishing;

[Parents(typeof(Patience))]
[Skill(typeof(Skills.Fishing))]
public class OneWithTheWater : Perk
{
    public override string GetDescription(int level)
    {
        return "You need 33% as much water to have maximum fishing power.";
    }

    public override string Identifier { get; set; } = "onewiththewater";
    public override string Name { get; } = "One With The Water";

    public override IPerkVisualDescriptor Visuals { get; } = new Visualiser();

    public class Visualiser : StandardPerkVisualDescriptor
    {
        public Visualiser() : base(new(0.5f, 0.1f), Main.Assets.Request<Texture2D>("Images/UI/Bestiary/Icon_Tags_Shadow"), new(30, 30))
        {
        }

        protected override void DrawIcon(SpriteBatch spriteBatch, Asset<Texture2D> icon, Vector2 location, float scale)
        {
            spriteBatch.Draw(Icon.Value, location, new Rectangle(360, 30, 30, 30), new Color(1, 1, 1, scale), 0, new Vector2(30 / 2f, 30 / 2f), scale, SpriteEffects.None, 0);
        }
    }
}