using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
namespace NovaEdge.Items.SpaceSpooder
{
    public class BoosterFlame : ModProjectile
    {
        public override void SetDefaults()
        {
            projectile.CloneDefaults(ProjectileID.CrystalShard);
            projectile.width = projectile.height = 16;
            projectile.ignoreWater = true;
            projectile.friendly = true;
            projectile.tileCollide = false;
            projectile.melee = true;
        }
      
        
        
    }
}
