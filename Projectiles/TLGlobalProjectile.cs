using TerrabornLeveling.Players;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace TerrabornLeveling.Projectiles;

public class TLGlobalProjectile : GlobalProjectile
{
    public override void ModifyHitNPC(Projectile projectile, NPC target, ref int damage, ref float knockback, 
        ref bool crit, ref int hitDirection)
    {
        if (Main.netMode == NetmodeID.Server)
        {
            return;
        }

        TLPlayer.Get().OnProjectileModifyHitNPC(projectile, target, ref damage, ref knockback, ref crit, ref hitDirection);
    }

    public override void OnHitNPC(Projectile projectile, NPC target, int damage, float knockback, bool crit)
    {
        if (Main.netMode == NetmodeID.Server)
        {
            return;
        }

        TLPlayer.Get().OnProjectileHitNPC(projectile, target, damage, knockback, crit);
    }
}