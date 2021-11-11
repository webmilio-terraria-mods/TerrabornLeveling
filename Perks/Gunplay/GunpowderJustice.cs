using Infuller.Items.Ranged.Gun;
using Microsoft.Xna.Framework.Graphics;
using TerrabornLeveling.Skills;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace TerrabornLeveling.Perks.Gunplay;

[Skill(typeof(Skills.Gunplay))]
public class GunpowderJustice : Perk
{
    public GunpowderJustice() : base("gunpowderjustice")
    {
    }

    public override void OnModifyWeaponDamage(Item item, ref StatModifier damage, ref float flat)
    {
        if (!Guns.Is(item.type)) return;

        damage *= DamageMultiplier;
    }

    public static float GetDamageMultiplier(int level)
    {
        return 0.2f * level;
    }

    public override int GetRequiredSkill(int level) => StepRequiredLevel(1, 20, level);

    public override string GetDescription(int level)
    {
        return $"Guns do {(int)(GetDamageMultiplier(level) * 100)}% more damage.";
    }

    public override string Name => "Gunpowder Justice";
    public override int MaxLevel => 5;

    public float DamageMultiplier => 1 + GetDamageMultiplier(Level);

    public override IPerkVisualDescriptor Visuals { get; } = new StandardPerkVisualDescriptor(new(.5f, 1), new(26, 18),
        Main.Assets.Request<Texture2D>($"Images/Item_{ItemID.ExplosivePowder}"));
}