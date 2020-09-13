using Terraria;
using Terraria.ID;
using Microsoft.Xna.Framework;
using Terraria.Localization;
using System;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;



namespace NovaEdge.NPCs.GrumpyStumpy{
    public class GrumpyStumpy : ModNPC{
        public override void SetStaticDefaults(){
            DisplayName.SetDefault("Living Guardian");
            Main.npcFrameCount[npc.type] = 1;
        }
        public override void SetDefaults(){
            npc.aiStyle = -1;
            npc.width = 210;
            npc.height = 120;
            //aiType = NPCID.Zombie;
            npc.lifeMax = 3000;
            npc.knockBackResist = 0f;
            npc.damage = 15;
            npc.defense = 5;
            npc.npcSlots = 3f;
            npc.boss = true;
            npc.HitSound = SoundID.NPCHit1;
			npc.DeathSound = null;
			npc.alpha = 0;
            npc.noGravity = false;
            //npc.value = 10334f;
            npc.lavaImmune = true;
            npc.noTileCollide = false;

            for(int j = 0; j < npc.buffImmune.Length; j++){
                npc.buffImmune[j] = true;
            }
            music = MusicID.Plantera;
			musicPriority = MusicPriority.BossMedium;  

            /* Stat details:
            thorns return 80% dmg , does 0 contact , 15 leaf crystal and 12 thorns*/
            

        }
        public override void ScaleExpertStats(int numPlayera , float bossLifeScale){
            npc.lifeMax = (int)(npc.lifeMax * 0.75f * bossLifeScale);
            npc.damage = (int)(npc.damage * 0.65f);
            
            
        }
        public override void AI(){
            npc.TargetClosest();

            Vector2 npcPos = npc.Center;
            if(npc.HasValidTarget && Main.netMode != NetmodeID.MultiplayerClient){
                Vector2 playerPos = Main.player[npc.target].Center;
            }
            else{
                Vector2 playerPos = Vector2.Zero;
            }

            npc.ai[0]++;
            if(npc.ai[0] == 60){
                LeafCrystal();
                
            }
            else if(npc.ai[0] == 300){
                ThornLine();
            }
            else if(npc.ai[0] > 300 && npc.ai[0] < 540){
                ThornShroud();
            }
            else if(npc.ai[0] > 540 && npc.ai[0] <= 660){
                Teleport();
            }

            if(npc.ai[0] > 720){
                npc.ai[0] = 0;
            }
            

        }
        public int damageTaken = 0;
        private void LeafCrystal(){
            int type = ModContent.ProjectileType<GreenRose>();
            int damage = npc.damage/2;
            Vector2 projectilePos = new Vector2(npc.Center.X , npc.Center.Y - 80f);
            Projectile.NewProjectile(projectilePos , Vector2.Zero , type , damage , 4f , Main.myPlayer);
        }
        private void Teleport(){
            int sign = Math.Sign(Main.player[npc.target].Center.X - npc.Center.X);
            if(npc.ai[0] > 540 && npc.ai[0] < 660){
                for(int i = 0; i < 2; i++){
                     Dust dust = Dust.NewDustDirect(npc.position , npc.width , npc.height , 57);
                }
            }
            if(npc.ai[0] == 660){
                npc.position.X = Main.player[npc.target].Center.X + (sign * 320f);
            }
        }
        private void ThornLine(){
            int type = ModContent.ProjectileType<ThornGenerator>();
            int damage = npc.damage * 0;
            int sign = Math.Sign(Main.player[npc.target].Center.X - npc.Center.X);
            Vector2 projectilePos = new Vector2(npc.Center.X , npc.Center.Y  + 60f);
            Vector2 vel = new Vector2(sign * 4 , 0);
            Main.player[npc.target].AddBuff(ModContent.BuffType<Buffs.Rooted>() , 45);
            Projectile.NewProjectile(projectilePos , vel  , type , damage , 4f , Main.myPlayer);
        }
        private void ThornShroud(){
            for(int i = 0; i <2; i++){
            Dust dust = Dust.NewDustDirect(npc.position , npc.width , npc.height , 6);
            }
            npc.defense = 15;
            npc.damage = 12;

        }
        public override void OnHitByItem(Player player , Item item , int damage , float knockback , bool crit){
            if(npc.ai[0] < 540 && npc.ai[0] > 300){
                
                player.statLife -= (int)(damage * 0.8f);
                if(player.statLife < 40){
                    player.statLife = 40;

                }
            }
        }
        public override void OnHitByProjectile(Projectile projectile , int damage ,float knockback , bool crit){
            
            if(npc.ai[0] < 540 && npc.ai[0] > 300){
                Main.player[npc.target].statLife -= (int)(damage * 0.8f);
                if(Main.player[npc.target].statLife < 40){
                    Main.player[npc.target].statLife = 40;
                }
            }
            
        }
    }
}