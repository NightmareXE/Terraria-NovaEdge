using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using NovaEdge.Dusts;
using static Terraria.ModLoader.ModContent;

namespace NovaEdge.Projectiles
{
	public class InfectiousProjectile : ModProjectile
	{
		public override void SetStaticDefaults() {
			
			ProjectileID.Sets.YoyosLifeTimeMultiplier[projectile.type] = 9f;
			
			ProjectileID.Sets.YoyosMaximumRange[projectile.type] = 245.5f;
			
			ProjectileID.Sets.YoyosTopSpeed[projectile.type] = 13f;
		}

		public override void SetDefaults() {
			projectile.extraUpdates = 0;
			projectile.width = 16;
			projectile.height = 16;
			projectile.friendly = true;
			projectile.penetrate = -1;
			projectile.melee = true;
			projectile.scale = 1f;
			projectile.aiStyle = 99;
		}

		public override void AI()
		{
			if(Main.rand.NextBool()) {
				
				
				Dust dust = Dust.NewDustDirect(projectile.position , projectile.height , projectile.width , 169); //Doesn't work as of rn
				
				
			}
   		
		}
		public override void OnHitNPC(NPC target , int damage , float knockback , bool crit )
		{
			if(Main.rand.NextBool(3))
			{
				target.AddBuff(BuffID.Ichor , 420 , false); //nice
			}
		}


		
	}
}
