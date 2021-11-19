using TerrabornLeveling.Perks.Visualisers;
using Terraria;
using Terraria.ModLoader;

namespace TerrabornLeveling.Perks.Physical.Mining.Biomes;

[Parents(typeof(Undergrounder))]
public class JungleThorns : BiomePerk
{
    public JungleThorns() : base("junglethorns")
    {
    }

    public override void OnModifyWeaponDamage(Item item, ref StatModifier damage, ref float flat)
    {
        if (!IsInRange || !Owner.Player.ZoneJungle)
        {
            return;
        }

        damage *= 1.15f;
    }

    public override string GetDescription(int level) => "Increases damage by 15% while in the Underground Jungle.";

    public override string Name => "Jungle Thorns";

    public override IPerkVisualDescriptor Visuals { get; } = new IconTagsPerkVisualDescriptor(new(0.92775667f, 0.95186335f), IconTagsPerkVisualDescriptor.TagsIcon.UndergroundJungle);
}