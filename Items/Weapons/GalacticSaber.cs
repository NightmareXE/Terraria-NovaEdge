using Terraria;
using Terraria.ID;
using System;
using Microsoft.Xna.Framework;
using NovaEdge.Projectiles;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace NovaEdge.Items.Weapons{
    public class GalacticSaber : ModItem{
        public override void SetDefaults(){
            item.damage = 156;
            item.useTime = 10;
            item.useAnimation = 10;
            item.useStyle = ItemUseStyleID.HoldingOut;
            item.value = 10;
            item.melee = true;
            item.width = 40;
            item.height = 40;
            item.knockBack = 4f;
            item.noMelee  =true;
            item.noUseGraphic = true;
            item.channel = true;
            item.autoReuse = true;
            item.shootSpeed = 25f;
            item.UseSound = SoundID.Item42;
        
            item.shoot = ProjectileType<GalacticSaberProj1>();
        }
        public override bool CanUseItem(Player player){

            if(player.altFunctionUse == 2){
                item.shoot = ProjectileType<GalacticSaberProj2>();
                item.shootSpeed = 8f;
                item.useTime = 18;
                item.UseSound = SoundID.Item18;
                item.useAnimation = 18;
                return base.CanUseItem(player);
            }
            if(player.altFunctionUse != 2){
                item.shootSpeed = 25f;
                item.useTime = 10;
                item.useAnimation = 10;
                item.UseSound = SoundID.Item65;
                item.shoot = ProjectileType<GalacticSaberProj1>();
            }
            return player.ownedProjectileCounts[item.shoot] < 1;
        }
        public override bool AltFunctionUse(Player player){
            return true;
        }
    }
    public class GalacticSaberProj1 : ModProjectile{
        public override void SetDefaults(){
            projectile.width = 80;
            projectile.height = 80;
            projectile.scale = 1.2f;
            projectile.penetrate = -1;
            projectile.melee = true;
            projectile.tileCollide = false;
            projectile.ignoreWater = true;
            projectile.friendly = true;

        }
        public override void AI(){
            Lighting.AddLight(projectile.Center , 1.1f , 0.5f , 0.5f);
            float rotateTime = 48f;
            float idk = 2f;
            float quarterPi = -(float)Math.PI/4f;

            float scale = 20f;

            Player player = Main.player[projectile.owner];

            Vector2 relativePoint = player.RotatedRelativePoint(player.MountedCenter);

            if(player.dead){
                return;
                projectile.Kill();
            }
            Lighting.AddLight(player.Center , 2 , 3 , 4);

            int sign = Math.Sign(projectile.velocity.X);

            projectile.velocity = new Vector2(sign , 0f);
            if(projectile.ai[0] == 0f){
                projectile.rotation = new Vector2(sign , 0f - player.gravDir).ToRotation() + quarterPi + (float)Math.PI;
                if(projectile.velocity.X < 0f){
                    projectile.rotation -= (float)Math.PI / 2f;
                }
            }
            projectile.ai[0] +=1f;

            projectile.rotation += (float)Math.PI * 2f * idk/rotateTime * (float)sign;
            bool isDone = projectile.ai[0] == (rotateTime / 2f);

            if(projectile.ai[0] >= rotateTime || (isDone && !player.controlUseItem ))
            {
                projectile.Kill();
                player.reuseDelay = 2;

            }
            else if(isDone){
                Vector2 mouseWorld = Main.MouseWorld;
                int dir = (player.DirectionTo(mouseWorld).X > 0f) ? 1 : -1;
                if((float)dir != projectile.velocity.X){
                    player.ChangeDir(dir);
                    projectile.velocity = new Vector2(dir , 0f);
                    projectile.rotation -= (float)Math.PI;
                    projectile.netUpdate = true;
                }
            }
            projectile.Center = player.Center;
            float rotationValue = projectile.rotation - (float)Math.PI / 4f * (float)sign;
            Vector2 positionVector = (rotationValue + (sign == -1 ? (float)Math.PI : 0f)).ToRotationVector2() * (projectile.ai[0] / rotateTime) * scale;
            
            Vector2 dustVector = projectile.Center + (rotationValue + ((sign == -1) ? ((float)Math.PI) : 0f)).ToRotationVector2() * 30f;
            Vector2 dustPos = rotationValue.ToRotationVector2();
            Vector2 dustVectorB = dustPos.RotatedBy((float)Math.PI / 2f) * ((float)projectile.spriteDirection);


            if(Main.rand.NextBool(2)){
                Dust dust = Dust.NewDustDirect(dustVector - new Vector2(5f) , 10 , 10 , 58 , player.velocity.X , player.velocity.Y , 150);
                dust.velocity = projectile.DirectionTo(dust.position) * 0.1f + dust.velocity * 0.1f;            }

            for(int a = 0; a < 4; a++){
                float scale1 = 1f;
                float scale2 = 1f;
                switch (a)
                {
                    
                    case 1:
                        scale2 = -1f;
                        break;
                    case 2:
                        scale1 = 0.5f;
                        scale2 = 1.25f;
                        break;
                    case 3:
                        scale1 = 0.5f;
                        scale2 = -1.25f;
                        break;
                   

                }
                if(!Main.rand.NextBool(6)){
                    Dust dustA = Dust.NewDustDirect(projectile.position , 0 , 0  , 58 , 0f , 0f , 100);
                    dustA.position = projectile.Center + dustPos * (60f + Main.rand.NextFloat() * 20f) * scale2;
                    dustA.velocity = dustVectorB * (4f + 4f * Main.rand.NextFloat()) * scale2 * scale1;
                    dustA.noLight = true;
                    dustA.scale = 0.8f;
                    dustA.noGravity = true;
                    dustA.customData = this;
                    if(Main.rand.NextBool(4)){
                        dustA.noGravity = false;
                    }
                }
            }
            projectile.position = relativePoint - projectile.Size / 2f;
            projectile.position += positionVector;
            projectile.spriteDirection = projectile.direction;
            projectile.timeLeft = 2;

            player.ChangeDir(projectile.direction);
            player.heldProj = projectile.whoAmI;
            player.itemTime = 2;
            player.itemAnimation = 2;
            player.itemRotation = MathHelper.WrapAngle(projectile.rotation);

        }
    }
}