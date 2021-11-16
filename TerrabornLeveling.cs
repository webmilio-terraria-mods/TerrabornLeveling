using System.Reflection;
using Microsoft.Xna.Framework.Input;
using TerrabornLeveling.Assets;
using Terraria.ModLoader;
using WebmilioCommons;
using WebmilioCommons.DependencyInjection;
using WebmilioCommons.Extensions;
using WebmilioCommons.Inputs;

namespace TerrabornLeveling;

public class TerrabornLeveling : Mod
{
    public TerrabornLeveling()
    {
        Instance = this;
        Services = new();
    }

    public override void Load()
    {
        if (Development)
        {
            DevelopmentAction = KeybindLoader.RegisterKeybind(this, "Development Action", Keys.K);
        }

        ModStore.Mods.Do(delegate(Mod mod)
        {
            mod.Code.DefinedTypes.Do(delegate(TypeInfo type)
            {
                if (type.TryGetCustomAttribute(out ServiceAttribute attr))
                    Services.AddSingleton(type);
            });
        });
    }

    public override void PostSetupContent()
    {
        TextureAssets.LoadTextures();
    }

    public override void Unload()
    {
        Services = null;
        Instance = null;
        TextureAssets.UnloadTextures();
    }

    [Keybind("Open Skills Menu", Keys.P)] public ModKeybind SkillMenu { get; private set; }
    [Keybind("Context Action", Keys.O)] public ModKeybind ContextAction { get; private set; }

    [Keybind("Rebuild Skill Menu", Keys.L)] public ModKeybind RebuildSkillMenu { get; private set; }

    public ModKeybind DevelopmentAction { get; private set; }

    public static TerrabornLeveling Instance { get; private set; }
    public static SimpleServices Services { get; private set; }

    public static bool Development => true;
}