using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;

namespace NovaEdge.NPCs.SpaceSpooder{
    public class MechEggSpooder : ModNPC{
        public override void SetStaticDefaults(){
            DisplayName.SetDefault("Mechanical Egg");
             Main.npcFrameCount[npc.type] = 1;
        }
        //public override string Texture => "Terraria/Item_6";
        public override void SetDefaults(){
            npc.aiStyle = -1;
            npc.width = 24;
            npc.height = 24;
            npc.scale = 1.5f;
            npc.damage = 0;
            npc.lifeMax = 800;
            npc.knockBackResist = 0f;
            npc.lavaImmune = true;
            npc.noGravity = true;
            npc.HitSound = SoundID.NPCHit1;
			npc.DeathSound = null;


            for(int j = 0; j < npc.buffImmune.Length; j++){
                npc.buffImmune[j] = true;
            }
        }
        public override void AI(){
            npc.TargetClosest();
            Move();
            npc.ai[0]++;
            if(npc.ai[0] > 160){
                for(int a = 0; a < 2; a++){
                int dustIndex = Dust.NewDust(npc.position, npc.width, npc.height, 1);
				Dust dust = Main.dust[dustIndex];
                }
				
            }
            if(npc.ai[0] == 180){
                HoverMineSpawn();
                npc.life = 0;

            }
           
        }
         private void Move(){
             if(npc.HasValidTarget && Main.netMode != NetmodeID.MultiplayerClient){
                Vector2 pos = npc.Center;
                Vector2 targetPos = Main.player[npc.target].Center;
                Vector2 direction = targetPos - pos;
                direction.Normalize();
                npc.velocity.X = direction.X;
                npc.velocity.Y = direction.Y;
                
            }
        
         }
        private void HoverMineSpawn(){
            if(npc.HasValidTarget && Main.netMode != NetmodeID.MultiplayerClient){
                /*Vector2 pos = npc.Center;
                Vector2 targetPos = Main.player[npc.target].Center;
                Vector2 direction = targetPos - pos;
                direction.Normalize();
                //npc.velocity *= 0;
                int type = ModContent.ProjectileType<HoverMine>();
                int damage = npc.damage;
                Vector2 speedA = new Vector2(direction.X , direction.Y);*/
                

                //Projectile.NewProjectile(pos , speedA  , type , damage , 0f , Main.myPlayer);
                NPC.NewNPC((int)npc.Center.X , (int)npc.Center.Y , ModContent.NPCType<VacuumWalker>());
                }
        }
        public override void ScaleExpertStats(int numPlayera , float bossLifeScale){
            npc.lifeMax = (int)(npc.lifeMax * 0.75f * bossLifeScale);
            npc.damage = (int)(npc.damage * 0.65f);
            
        }
        

        
    }
}