using Infuller.Items.Magic;
using TerrabornLeveling.Perks.Visualisers;
using TerrabornLeveling.Projectiles;
using Terraria;

namespace TerrabornLeveling.Perks.Magic.Destruction.Fire;

[Parents(typeof(DarkPyromancy))]
public class FeeltheBurn : Perk
{
    public FeeltheBurn() : base("feeltheburn")
    {
    }

    public override void OnProjectileModifyHitNPC(Projectile projectile, NPC target, ref int damage, ref float knockback, ref bool crit,
        ref int hitDirection)
    {
        var global = projectile.GetGlobalProjectile<TLGlobalProjectileInstanced>();

        if (!Magics.TryGet(global.CreatorItem.type, out var magicRecord) || !magicRecord.IsElement(IMagic.ElementFire))
            return;

        damage += (int) (damage * .5f * (1 - target.life / (float)target.lifeMax));
    }

    public override string GetDescription(int level)
    {
        return
            "Increases the damage dealt to enemies based on their current health.\nScales from 0% to 50% more damage.";
    }

    public override string Name => "Feel the Burn";

    public override IPerkVisualDescriptor Visuals { get; } = new PerkVisualDescriptor(new(.1f, .3f));
}