using Microsoft.Xna.Framework.Graphics;
using ReLogic.Content;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace TerrabornLeveling.Assets;

public static class TextureAssets
{

    public static void LoadTextures()
    {
        SkillExperienceBar = ModContent.Request<Texture2D>("TerrabornLeveling/Assets/Textures/Skill_Experience_Bar");
    }

    public static void UnloadTextures()
    {
        SkillExperienceBar?.Dispose();
        SkillExperienceBar = null;

    }

    public static Asset<Texture2D> SkillExperienceBar { get; private set; }
}