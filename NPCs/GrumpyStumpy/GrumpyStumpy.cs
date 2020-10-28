using Terraria;
using Terraria.ID;
using Microsoft.Xna.Framework;
using Terraria.Localization;
using System;
using Terraria.ModLoader;
//using static Terraria.ModLoader.ModContent;



namespace NovaEdge.NPCs.GrumpyStumpy
{
    [AutoloadBossHead]
    public class GrumpyStumpy : ModNPC
    {
        private bool thorns = false;
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Living Guardian");
            Main.npcFrameCount[npc.type] = 1;  //12 idle , 13 atk
            //failed attempt at animation , sheets are dank
        }
        public override void SetDefaults()
        {
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

            for (int j = 0; j < npc.buffImmune.Length; j++)
            {
                npc.buffImmune[j] = true;
            }
            music = MusicID.Plantera;
            musicPriority = MusicPriority.BossMedium;

            /* Stat details:
            thorns return 80% dmg , does 0 contact , 15 leaf crystal and 12 thorns*/


        }
        public override void ScaleExpertStats(int numPlayera, float bossLifeScale)
        {
            npc.lifeMax = (int)(npc.lifeMax * 0.75f * bossLifeScale);
            npc.damage = (int)(npc.damage * 0.65f);


        }
        public bool attack;
        public override void AI()
        {
            npc.TargetClosest();
            attack = false;
            Player player = Main.player[npc.target];
            thorns = false;

            float dist = Vector2.Distance(player.Center, npc.Center);
            if (dist > 960f)
            {
                if (player.HasBuff(ModContent.BuffType<Buffs.Rooted>()))
                {
                    player.ClearBuff(ModContent.BuffType<Buffs.Rooted>());
                }
                player.AddBuff(ModContent.BuffType<Buffs.NaturesFury>(), 60);
            }


            Vector2 npcPos = npc.Center;
            if (npc.HasValidTarget && Main.netMode != NetmodeID.MultiplayerClient)
            {
                Vector2 playerPos = player.Center;
            }
            else
            {
                Vector2 playerPos = Vector2.Zero;
            }

            npc.ai[0]++;
            if (npc.ai[0] == 60)
            {
                LeafCrystal(new Vector2(npc.Center.X , npc.Center.Y - 128) , 15);

            }


            if (npc.ai[0] > 270 && npc.ai[0] < 335)
            {
                if (npc.ai[0] == 300)
                {
                    Shoot(player, new Vector2(player.Center.X, player.Center.Y + 48), 5, 15, 3f, ModContent.ProjectileType<ThornGenerator>(), true);
                }
                attack = true;
            }
            else if (npc.ai[0] > 300 && npc.ai[0] < 540)
            {
                ThornShroud(player);
            }


            if (npc.ai[0] > 720)
            {
                npc.ai[0] = 0;
            }


        }
        public int damageTaken = 0;
        private void LeafCrystal(Vector2 spawnPos , int damage)
        {
            int type = ModContent.ProjectileType<GreenRose>();
            
            
            Projectile.NewProjectile(spawnPos, Vector2.Zero, type, damage, 4f, Main.myPlayer);
        }
        
        private void Shoot(Player player , Vector2 spawnPos , float velMult , int damage , float knockBack , int type , bool thornLine = false , bool projectileSpam = false , float projSpamDist = 32 , int projSpamDelay = 0)
        {
            if (thornLine)
            {
                int sign = Math.Sign(player.Center.X - npc.Center.X);
                player.AddBuff(ModContent.BuffType<Buffs.Rooted>(), 45);
                Projectile.NewProjectile(spawnPos, new Vector2(1, 0) * sign * velMult, type, damage, knockBack, player.whoAmI);
            }
            else if (projectileSpam)
            {
                npc.ai[1]++;
                Vector2 projPos = new Vector2(Main.rand.NextBool(2) ? player.Center.X + projSpamDist : player.Center.X - projSpamDist, player.Center.Y);
                Vector2 vel = player.Center - projPos;
                vel.Normalize();
                for(int i = 0; i < 2; i++)
                {
                    Dust.NewDustPerfect(projPos, DustID.GrassBlades);
                }
                if (npc.ai[1] % projSpamDelay == 0)
                {
                    
                    Projectile.NewProjectile(projPos, vel * velMult, type, damage, knockBack, player.whoAmI);
                }

                if(npc.ai[1] > projSpamDelay)
                {
                    npc.ai[1] = 0;
                    npc.netUpdate = true;
                }
            }
                
            else
            {
                Vector2 velocity = player.Center - npc.Center;
                velocity.Normalize();
                Projectile.NewProjectile(spawnPos, velocity * velMult, type, damage, knockBack, player.whoAmI);
            }
        }
        private void ThornShroud(Player player)
        {
            thorns = true;
            for (int i = 0; i < 2; i++)
            {
                Dust dust = Dust.NewDustDirect(npc.position, npc.width, npc.height, 6);
            }
            npc.defense = 15;
            npc.damage = 12;

        }
        
        public override void OnHitByItem(Player player, Item item, int damage, float knockback, bool crit)
        {
            if (npc.ai[0] < 540 && npc.ai[0] > 300)
            {

                player.statLife -= (int)(damage * 0.8f);
                if (player.statLife < 40)
                {
                    player.statLife = 40;

                }
            }
        }
        public override void OnHitByProjectile(Projectile projectile, int damage, float knockback, bool crit)
        {
            

            Player player = Main.player[npc.target];
            //Thorn attack later
            if (thorns)
            {
                player.HurtOld(damage / 2, projectile.direction, false, false, "was pricked to death...");
            }

            //player.Hurt(ByNPC(), damage, projectile.direction * -1);

        }

        public override void HitEffect(int hitDirection, double damage)
        {
            if (npc.life <= 0)
            {
                Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/GrumpyStumpyGore1"), 2f);
                Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/GrumpyStumpyGore2"), 2f);
                Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/GrumpyStumpyGore2"), 2f);
                Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/GrumpyStumpyGore3"), 2f);
                Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/GrumpyStumpyGore4"), 2f);
                Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/GrumpyStumpyGore5"), 2f);
                Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/GrumpyStumpyGore5"), 2f);



            }
        }
        /*public override void FindFrame(int frameHeight){
            npc.frameCounter++;
            if(npc.frameCounter < 5){
                npc.frame.Y = 0 * frameHeight;
            }
            else if(npc.frameCounter < 5){
                npc.frame.Y = 1 * frameHeight;
            }
            else if(npc.frameCounter < 10){
                npc.frame.Y = 2 * frameHeight;
            }
            else if(npc.frameCounter < 15){
                npc.frame.Y = 3 * frameHeight;
            }
            else if(npc.frameCounter < 20){
                npc.frame.Y = 4 * frameHeight;
            }
            else if(npc.frameCounter < 25){
                npc.frame.Y = 5 * frameHeight;
            }
            else if(npc.frameCounter < 30){
                npc.frame.Y = 6 * frameHeight;
            }
            else if(npc.frameCounter < 35){
                npc.frame.Y = 7 * frameHeight;
            }
            else if(npc.frameCounter < 40){
                npc.frame.Y = 8 * frameHeight;
            }
            else if(npc.frameCounter < 45){
                npc.frame.Y = 9 * frameHeight;
            }
            else if(npc.frameCounter < 50){
                npc.frame.Y = 10 * frameHeight;
            }
            else if(npc.frameCounter < 55){
                npc.frame.Y = 11 * frameHeight;
            }
            else{
                npc.frameCounter = 0;
            }
            


        }*/
    }
}