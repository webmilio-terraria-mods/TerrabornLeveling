using Microsoft.Xna.Framework.Graphics;
using TerrabornLeveling.Perks.Visualisers;
using Terraria;
using Terraria.ID;

namespace TerrabornLeveling.Perks.Agility.Fishing;

[Parents(typeof(OneWithTheRod))]
public class OneWithTheFish : Perk
{
    public OneWithTheFish() : base("onewiththefish")
    {
    }

    public override string GetDescription(int level)
    {
        return "";
    }

    public override string Name => "One With The Fish";

    public override IPerkVisualDescriptor Visuals { get; } = new PerkVisualDescriptor(new(0.6121673f, 0.23655914f), new(34, 34), Main.Assets.Request<Texture2D>($"Images/Item_{ItemID.NeonTetra}"));
}