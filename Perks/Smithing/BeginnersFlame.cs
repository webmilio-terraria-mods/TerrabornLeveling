using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using TerrabornLeveling.Players;
using TerrabornLeveling.Skills;
using Terraria;
using Terraria.ID;
using WebmilioCommons.Extensions;
using static Terraria.ID.PrefixID;

namespace TerrabornLeveling.Perks.Smithing;

[Skill(typeof(Skills.Smithing))]
public class BeginnersFlame : ModifiersUnlockingPerk
{
    private static readonly int[] _unlocks =
    {
        Agile, Annoying, Deadly, Lazy, Murderous,
        Nasty, Nimble, Quick, Slow, Sluggish
    };

    public BeginnersFlame() : base("beginnersflame")
    {
    }

    public override string GetDescription(int level)
    {
        return "Unlocks the possibility of crafting weapons, tools and equipment pieces with prefixes.\n" +
               "Agile, Annoying, Deadly, Lazy, Murderous, Nasty,\n" +
               "Nimble, Quick, Slow, Sluggish.";
    }

    public override string Name { get; } = "Beginner's Flame";

    protected override int[] Unlocks { get; } = _unlocks;

    public override IPerkVisualDescriptor Visuals { get; } =
        new StandardPerkVisualDescriptor(new Vector2(.5f, 1), Main.Assets.Request<Texture2D>($"Images/Item_{ItemID.LivingFireBlock}"))
        {
            Size = new Vector2(18, 20)
        };
}