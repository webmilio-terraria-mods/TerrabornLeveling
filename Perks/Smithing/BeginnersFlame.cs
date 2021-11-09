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
    private const string Description = "Unlocks the possibility of crafting weapons, tools and equipment pieces with prefixes.\n{0}";

    public BeginnersFlame() : base("beginnersflame")
    {
    }

    protected override string GetDescriptionString()
    {
        return Description;
    }

    public override string Name { get; } = "Beginner's Flame";

    protected override int RequiredSkill { get; } = 1;

    protected override int[] Unlocks { get; } = { Agile, Annoying, Deadly, Lazy, Murderous, Nasty, Nimble, Quick, Slow, Sluggish };
    protected override string[] UnlockNames { get; } =
    {
        nameof(Agile), nameof(Annoying), nameof(Deadly), nameof(Lazy), nameof(Murderous),
        nameof(Nasty), nameof(Nimble), nameof(Quick), nameof(Slow), nameof(Sluggish)
    };

    public override IPerkVisualDescriptor Visuals { get; } = new StandardPerkVisualDescriptor(new(.5f, 1), new(18, 20), 
            Main.Assets.Request<Texture2D>($"Images/Item_{ItemID.LivingFireBlock}"));
}