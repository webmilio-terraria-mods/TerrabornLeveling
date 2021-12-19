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
        int extendWidth = (int)MathHelper.Clamp(width, 0, 324);

        // Exp Bar BG
        spriteBatch.Draw(TextureAssets.SkillExperienceBar.Value, position + new Vector2(36, 12), new(2, 50, 324, 10), Color.White);

        // Exp Value Bar
        spriteBatch.Draw(TextureAssets.SkillExperienceBar.Value, position + new Vector2(38, 12), new(332 - extendWidth, 38, extendWidth, 10), Color.White);

        // Bar Outline
        spriteBatch.Draw(TextureAssets.SkillExperienceBar.Value, position, new Rectangle(2, 2, 400, 34), Color.White);
    }
}