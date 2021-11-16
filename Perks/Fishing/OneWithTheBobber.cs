using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;

namespace TerrabornLeveling.Perks.Fishing;

[Parents(typeof(MasterBaiter))]
public class OneWithTheBobber : Perk
{
    public OneWithTheBobber() : base("onewiththebobber")
    {
    }

    public override void OnPreUpdate()
    {
        Owner.Player.sonarPotion = true;
    }

    public override string GetDescription(int level)
    {
        return "You always know what's on your line.";
    }

    public override int GetRequiredSkill(int level) => 25;

    public override string Name { get; } = "One With The Bobber";

    //"Images/UI/Bestiary/Icon_Tags_Shadow"
    public override IPerkVisualDescriptor Visuals { get; } = new StandardPerkVisualDescriptor(new(0.67490494f, 0.71146953f), new(30, 30), Main.Assets.Request<Texture2D>($"Images/Projectile_{ProjectileID.BobberFiberglass}"));
}