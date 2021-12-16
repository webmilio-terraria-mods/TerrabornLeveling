using Terraria;
using Terraria.ModLoader;

namespace TerrabornLeveling.Projectiles;

public class TLGlobalProjectileInstanced : GlobalProjectile
{
    public override void SetDefaults(Projectile projectile)
    {
        
    }

    public override bool PreAI(Projectile projectile)
    {
        if (projectile.owner < 0)
        {
            return base.PreAI(projectile);
        }

        CreatorItem = Main.player[projectile.owner].HeldItem;

        return true;
    }

    public override bool InstancePerEntity { get; } = true;

    public Item CreatorItem { get; private set; }
}