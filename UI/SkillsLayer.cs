using Terraria.UI;

namespace TerrabornLeveling.UI;

public class SkillsLayer : GameInterfaceLayer
{
    public SkillsLayer() : base("TerrabornLeveling.SkillsMenu", InterfaceScaleType.UI)
    {
    }

    public void Show()
    {
        IngameFancyUI.OpenUIState(State);
    }

    public SkillsMenu State { get; } = new();
}