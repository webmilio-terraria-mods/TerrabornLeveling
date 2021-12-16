using Microsoft.Xna.Framework.Graphics;
using TerrabornLeveling.Perks.Visualisers;
using Terraria;
using Terraria.GameContent;
using Terraria.ID;

namespace TerrabornLeveling.Perks.Physical.Mining;

[Parents(typeof(CaveDweller))]
public class Heartbreaker : Perk
{
    public Heartbreaker() : base("heartbreaker")
    {
    }

    public override void OnPreUpdate()
    {
        Owner.Player.AddBuff(BuffID.Lifeforce, 1);
        Owner.Player.AddBuff(BuffID.HeartLamp, 1);
    }

    public override string GetDescription(int level)
    {
        const string level1 = "After you break a Life Crystal, gain a Lifeforce and Regen buff for 2 minutes.";
        const string level2 = "You gain the Lifeforce and Regen buff permanently.";

        return level == 1 ? level1 : level2;
    }

    public override int GetRequiredSkill(int level) => StepRequiredLevel(35, 35, level);

    public override string Name => "Heartbreaker";
    public override int MaxLevel => 2;

    public override IPerkVisualDescriptor Visuals { get; } = new TypeIconVisualDescriptor(new(0.038022812f, 0.8136646f), 
        TextureAssets.Item, ItemID.LifeCrystal);
}