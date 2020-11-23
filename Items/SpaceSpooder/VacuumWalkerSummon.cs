using Terraria;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Terraria.ID;
using System;

namespace NovaEdge.Items.SpaceSpooder
{
    public class VacuumWalkerSummon : Minion
    {
        Vector2 targetPos = Vector2.Zero;
        Vector2 playerPos = Vector2.Zero;

        //public override string Texture => "Terraria/Item_555";
        public override void SetStaticDefaults()
        {
            Main.projFrames[projectile.type] = 4;
            Main.projPet[projectile.type] = true;
            ProjectileID.Sets.MinionSacrificable[projectile.type] = true;
            ProjectileID.Sets.Homing[projectile.type] = true;
            ProjectileID.Sets.MinionTargettingFeature[projectile.type] = true;
        }
        public override void SetDefaults()
        {
            projectile.netImportant = true;
            projectile.friendly = true;
            projectile.tileCollide = false;
            projectile.ignoreWater = true;
            projectile.width = 24;
            projectile.height = 24;
            projectile.penetrate = -1;
            projectile.minion = true;
            projectile.minionSlots = 1;
            
            projectile.scale = 1;
            projectile.timeLeft = 18000;
            /*drawOriginOffsetY = -35; 
            drawOffsetX = -65;*/
        }

        public override void CheckActive()
        {
            Player player = Main.player[projectile.owner];
            NovaEdgePlayer modPlayer = player.GetModPlayer<NovaEdgePlayer>();
            if (player.dead)
            {
                modPlayer.walkerMinion = false;
            }
            if (modPlayer.walkerMinion)
            {
                projectile.timeLeft = 2;
            }
        }
        public override void AI(){
            projectile.ai[0]++;
            target = false;
            if(++projectile.frameCounter > 5){
                projectile.frame++;
                if(projectile.frame > 3){
                    projectile.frame = 0;
                }
                projectile.frameCounter = 0;
            }
            Formation();
            if(projectile.ai[0] % 30 == 0){
                Shoot();
            }
        }
        bool target = false;
        Vector2 vel = Vector2.Zero;
        private void Formation(){
            Player player = Main.player[projectile.owner];
            projectile.ai[1] += Main.rand.NextFloat(0.025f , 0.03f);
            playerPos = player.Center;
            float targetDist = 512f;
            Vector2 circle = player.Center + new Vector2(0 , 96f).RotatedBy(projectile.ai[1]);
            projectile.Center = circle;
            //projectile.rotation = vel.ToRotation();
            if(player.HasMinionAttackTargetNPC){
                NPC npc = Main.npc[player.MinionAttackTargetNPC];
                if(Collision.CanHitLine(projectile.position, projectile.width, projectile.height, projectile.position, projectile.width, projectile.height)){
                    targetDist = Vector2.Distance(projectile.Center , targetPos);
                    target = true;
                    targetPos = projectile.Center;
                }
                
            }
            else{
                for(int i = 0; i <200; i++){
                    NPC npc = Main.npc[i];
                    if(npc.CanBeChasedBy(this , false) ){
                        float distance = Vector2.Distance(projectile.Center , projectile.Center);
                        if((distance < targetDist) || !target && Collision.CanHitLine(projectile.position, projectile.width, projectile.height, projectile.position, projectile.width, projectile.height)){
                            targetDist = distance;
                            target = true;
                            targetPos = projectile.Center;
                        }
                    }
                }
            }
            Vector2 velA = targetPos - projectile.Center;
            velA.Normalize();
            projectile.rotation = velA.ToRotation();
            
            
        }
        private void Shoot(){
            Player player = Main.player[projectile.owner];
            playerPos = player.Center;
            float targetDist = 512f;
            
            if(player.HasMinionAttackTargetNPC){
                NPC npc = Main.npc[player.MinionAttackTargetNPC];
                if(Collision.CanHitLine(projectile.position, projectile.width, projectile.height, projectile.position, projectile.width, projectile.height)){
                    targetDist = Vector2.Distance(projectile.Center , targetPos);
                    target = true;
                    targetPos = projectile.Center;
                }
                
            }
            else{
                for(int i = 0; i <200; i++){
                    NPC npc = Main.npc[i];
                    if(npc.CanBeChasedBy(this , false) ){
                        float distance = Vector2.Distance(projectile.Center , projectile.Center);
                        if((distance < targetDist || !target) && Collision.CanHitLine(projectile.position, projectile.width, projectile.height, projectile.position, projectile.width, projectile.height)){
                            targetDist = distance;
                            target = true;
                            targetPos = projectile.Center;
                        }
                    }
                }
            }
                


            if(target){
                vel = targetPos - projectile.Center;
                vel.Normalize();
                Projectile.NewProjectile(projectile.Center , vel * 9f , ProjectileID.LaserMachinegunLaser , projectile.damage , 0f , Main.myPlayer);
            }
        }
        private void Move()
        {
            Player player = Main.player[projectile.owner];
            playerPos = player.Center;
            float targetDist = 512f;

            if (player.HasMinionAttackTargetNPC)
            {
                NPC npc = Main.npc[player.MinionAttackTargetNPC];
                if (Collision.CanHitLine(projectile.position, projectile.width, projectile.height, projectile.position, projectile.width, projectile.height))
                {
                    targetDist = Vector2.Distance(projectile.Center, targetPos);
                    target = true;
                    targetPos = projectile.Center;
                }

            }
            else
            {
                for (int i = 0; i < 200; i++)
                {
                    NPC npc = Main.npc[i];
                    if (npc.CanBeChasedBy(this, false))
                    {
                        float distance = Vector2.Distance(projectile.Center, projectile.Center);
                        if ((distance < targetDist || !target) && Collision.CanHitLine(projectile.position, projectile.width, projectile.height, projectile.position, projectile.width, projectile.height))
                        {
                            targetDist = distance;
                            target = true;
                            targetPos = projectile.Center;
                        }
                    }
                }
            }



            if (target)
            {
                int direction = Math.Sign(projectile.Center.X - targetPos.X);
                projectile.ai[0]++;
                if(projectile.ai[0] % 60 == 0)
                {
                    projectile.velocity.Y = -6;
                    projectile.velocity.X = 8 * direction;
                }
            }
        }
        /*public override void AI()
        {
            Player player = Main.player[projectile.owner];
            if (player.HasMinionAttackTargetNPC)
            {
                NPC npc = Main.npc[player.MinionAttackTargetNPC];
            }
            else
            {
                Vector2 vel = new Vector2(player.Center.Y + player.direction * 32 * player.ownedProjectileCounts[projectile.type]) - projectile.Center;
                vel.Normalize();
                projectile.rotation = player.direction == 1 ? 0 : MathHelper.Pi;

            }
        }*/
        /*private void OrbitPlayer(Player player , float speed , int velMult , int radius)
        {
            projectile.ai[0] += MathHelper.ToRadians(speed);
            Vector2 circle = player.Center + new Vector2(0, radius).RotatedBy(projectile.ai[0]);
            Vector2 circularVel = circle - projectile.Center;
            circularVel.Normalize();
            float distance = Vector2.Distance(player.Center, projectile.Center);
            projectile.extraUpdates = distance > 384 ? 1 : 0;
            projectile.velocity = circularVel * velMult;
            projectile.rotation = projectile.velocity.ToRotation();
        }*/
        




    }
}