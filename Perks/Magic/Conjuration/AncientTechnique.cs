using TerrabornLeveling.Perks.Visualisers;
using Terraria;
using Terraria.ModLoader;

namespace TerrabornLeveling.Perks.Magic.Conjuration;

[Parents(typeof(MysticalPower))]
public class AncientTechnique : Perk
{
    public AncientTechnique() : base("ancienttechnique")
    {
    }

    public override void OnModifyWeaponCrit(Item item, ref int crit)
    {
        if (item.DamageType != DamageClass.Summon) return;

        crit += 4;
    }

    public override string GetDescription(int level)
    {
        return "";
    }

    public override string Name => "Ancient Technique";

    public override IPerkVisualDescriptor Visuals { get; } = new PerkVisualDescriptor(new(0.10836502f, 0.6165803f));
}