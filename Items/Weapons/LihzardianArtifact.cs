using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using NovaEdge.Buffs;
using static Terraria.ModLoader.ModContent;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace NovaEdge.Items.Weapons
{
    public class LihzardianArtifact : ModItem
    {
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("Gives 50% damage reduction as long as it is damaging something.");
        }
        public override void SetDefaults()
        {
            item.damage = 140;
            item.width = 70;
            item.height = 77;
            item.rare = ItemRarityID.Lime;
            item.knockBack = 7f;
            item.melee = true;
            item.UseSound = SoundID.Item1;
            item.useTime = 32;
            item.useAnimation = 32;
            item.autoReuse = true;
            item.useStyle = ItemUseStyleID.SwingThrow;
            item.value = 1200000;
        }
        public override void OnHitNPC(Player player, NPC target, int damage, float knockback, bool crit)
        {
            player.AddBuff(BuffType<LihzardianSecret>(), 60);
            for (int i = 0; i < 6; i++)
            {
                Dust dust;
                // You need to set position depending on what you are doing. You may need to subtract width/2 and height/2 as well to center the spawn rectangle.

                dust = Main.dust[Terraria.Dust.NewDust(target.Center, 30, 30, 226, Main.rand.NextFloat(-4f, 4f), Main.rand.NextFloat(-4f, 4f), 0, new Color(255, 255, 255), 1f)];
                dust.shader = Terraria.Graphics.Shaders.GameShaders.Armor.GetSecondaryShader(6, Main.LocalPlayer);

            }
            Vector2 leftEyePos = new Vector2(target.Center.X - 48 , target.Center.Y - 128);
            Vector2 rightEyePos = new Vector2(target.Center.X + 48, target.Center.Y - 128);
            Vector2 leftEyeToTarget = target.Center - leftEyePos;
            Vector2 rightEyeToTarget = target.Center - rightEyePos;
            leftEyeToTarget.Normalize();
            rightEyeToTarget.Normalize();

            for(int i = 0; i < 25; i++)
            {
                EyeDust(leftEyePos);
                EyeDust(rightEyePos);
            }
            EyeFire(new Vector2(leftEyePos.X + 20, leftEyePos.Y + 20), new Vector2(rightEyePos.X + 20, rightEyePos.Y + 20), leftEyeToTarget, rightEyeToTarget, player, (int)(damage * 0.8f), 12);



        }
        private void EyeFire(Vector2 left, Vector2 right , Vector2 leftVel , Vector2 rightVel , Player player , int damage , int velMult)
        {
            

            int leftProj = Projectile.NewProjectile(left, leftVel * velMult,ProjectileID.EyeBeam, damage, 4f, player.whoAmI);
            int rightProj = Projectile.NewProjectile(right, rightVel * velMult, ProjectileID.EyeBeam, damage, 4f, player.whoAmI);
            Projectile leftP = Main.projectile[leftProj];
            Projectile rightP = Main.projectile[rightProj];
            leftP.friendly = true;
            rightP.friendly = true;
            leftP.hostile = false;
            rightP.hostile = false;

            leftP.penetrate = 3;
            rightP.penetrate = 3 ;

            leftP.tileCollide = true;
            rightP.tileCollide= true;


        }
        public override void MeleeEffects(Player player, Rectangle hitbox)
        {
            if (Main.rand.NextBool(2))
            {

                Dust.NewDust(new Vector2(hitbox.X, hitbox.Y), hitbox.Width, hitbox.Height, 169);
            }
        }
        private void EyeDust(Vector2 pos)
        {
            Dust dust;
            // You need to set position depending on what you are doing. You may need to subtract width/2 and height/2 as well to center the spawn rectangle.
            
            dust = Main.dust[Terraria.Dust.NewDust(pos, 30, 30, 235, 0f, 0f, 0, new Color(255, 255, 255), 1f)];
            dust.noGravity = true;
            
            

            dust.shader = Terraria.Graphics.Shaders.GameShaders.Armor.GetSecondaryShader(85, Main.LocalPlayer);
           
            
        



        }
       

    }
}