using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using NovaEdge.Buffs;
using static Terraria.ModLoader.ModContent;
using Microsoft.Xna.Framework;

namespace NovaEdge.Items.Weapons{
  public class LihzardianArtifact : ModItem{
    public override void SetStaticDefaults(){
      Tooltip.SetDefault("Gives 50% damage reduction as long as it is damaging something.");
    }
    public override void SetDefaults(){
      item.damage = 140;
      item.width = 70;
      item.height = 77;
      item.rare = 7;
      item.knockBack = 7f;
      item.melee = true;
      item.UseSound = SoundID.Item1;
      item.useTime = 32;
      item.useAnimation = 32;
      item.autoReuse = true;
      item.useStyle = 1;
      item.value = 1200000;
    }
    public override void OnHitNPC(Player player , NPC target , int damage , float knockback , bool crit)
    {
      player.AddBuff(BuffType<LihzardianSecret>() , 60);
        
      
    }
     public override void MeleeEffects(Player player, Rectangle hitbox) {
			if (Main.rand.NextBool(2)) {
				
				Dust.NewDust(new Vector2(hitbox.X, hitbox.Y), hitbox.Width, hitbox.Height, 169);
			}
		}
  
  }
}