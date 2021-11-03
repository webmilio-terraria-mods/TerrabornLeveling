using TerrabornLeveling.Players;
using TerrabornLeveling.UI;
using Terraria.ModLoader;

namespace TerrabornLeveling;

public class TerrabornLevelingSystem : ModSystem
{
    public override void PostUpdateInput()
    {
        if (TerrabornLeveling.Instance.RebuildSkillMenu.JustPressed)
        {
            Layer.State.PopulateSkills(TLPlayer.Get());
        }

        if (TerrabornLeveling.Instance.SkillMenu.JustPressed)
        {
            Layer.Show();
        }
    }

    public SkillsLayer Layer { get; } = new();
}