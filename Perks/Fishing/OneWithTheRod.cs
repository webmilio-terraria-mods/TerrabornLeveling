using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;

namespace TerrabornLeveling.Perks.Fishing;

[Parents(typeof(OneWithTheBobber))]
public class OneWithTheRod : Perk
{
    public OneWithTheRod() : base("onewiththerod")
    {
    }

    public override string GetDescription(int level)
    {
        return
            "You have 10% chance of getting the highest position fishing-\n" +
            "related item in your inventory.";
    }

    public override int GetRequiredSkill(int level) => 45;

    public override string Name => "One With The Rod";

    public override IPerkVisualDescriptor Visuals { get; } = new StandardPerkVisualDescriptor(new(0.7528517f,0.4784946f), new(48, 48), Main.Assets.Request<Texture2D>($"Images/Item_{ItemID.FiberglassFishingPole}"))
    {
        Scale = .75f
    };
}