using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using TerrabornLeveling.Assets;
using Terraria.UI;

namespace TerrabornLeveling.UI;

public class SkillExperienceBarElement : UIElement
{
    private float _progress;
    public SkillExperienceBarElement()
    {
        Width = new(400, 0);
        Height = new(34, 0);
    }

    public void SetProgress(float progress)
    {
        _progress = MathHelper.Clamp(progress, 0, 1);
    }

    public override void Draw(SpriteBatch spriteBatch)
    {
        Vector2 position = new((int)GetDimensions().X, (int)GetDimensions().Y);

        int width = (int)(_progress * 324);
        int extendWidth = (int)MathHelper.Clamp(width - 12, 0, 312);
        int rightPieceX = 24 + width;

        // Exp Bar BG
        spriteBatch.Draw(TextureAssets.SkillExperienceBar.Value, position + new Vector2(36, 12), new(2, 50, 324, 10), Color.White);

        // Exp Value Bar
        // Extend Piece
        spriteBatch.Draw(TextureAssets.SkillExperienceBar.Value, position + new Vector2(36, 12), new(2, 38, extendWidth, 10), Color.White);
        // Right Piece
        spriteBatch.Draw(TextureAssets.SkillExperienceBar.Value, position + new Vector2(rightPieceX, 12), new(322, 38, 12, 8), Color.White);

        // Bar Outline
        spriteBatch.Draw(TextureAssets.SkillExperienceBar.Value, position, new Rectangle(2, 2, 400, 34), Color.White);
    }
}