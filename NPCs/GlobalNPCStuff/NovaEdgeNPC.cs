using Microsoft.Xna.Framework;
using Terraria;
using System;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using NovaEdge.Projectiles;
using NovaEdge.Buffs;

namespace NovaEdge.NPCs.GlobalNPCStuff
{
    public class NovaEdgeGlobalNPC : GlobalNPC
    {

        public override bool InstancePerEntity => true;
        public bool fatalWounds;
        public bool decay;
        public bool deflourished;
        public bool burnNPC;
        public bool cursedBurnNPC;
        public bool frostburnNPC;
        public bool Manipulated;
        public bool Moolah;
        public bool venom;
        public int MoolahTimer;
        public bool sharpshooter;

        public bool hasBeenHit;



        public override void ResetEffects(NPC npc)
        {
            fatalWounds = false;
            decay = false;
            deflourished = false;
            burnNPC = false;
            cursedBurnNPC = false;
            frostburnNPC = false;
            Manipulated = false;
            Moolah = false;
            venom = false;
            MoolahTimer = 0;
            sharpshooter = false;


            //Bloodlust stuff
            hasBeenHit = false;




        }
        public override void SetDefaults(NPC npc)
        {
            if (npc.boss)
            {
                npc.buffImmune[BuffID.Midas] = true;

            }
            switch (npc.type)
            {
                case NPCID.Golem:
                    npc.aiStyle = -1;
                    break;
            }
        }
        public override void OnHitByItem(NPC npc, Player player, Item item, int damage, float knockback, bool crit)
        {
            hasBeenHit = true;
        }



        public override void ModifyHitByItem(NPC npc, Player player, Item item, ref int damage, ref float knockback, ref bool crit)
        {
            if (Moolah)
            {
                if (MoolahTimer == 30)
                {
                    MoolahTimer = 0;
                    int coins = damage / 5;

                    if (Main.hardMode && coins < 100)
                    {
                        coins = 100;
                    }
                    else if (NPC.downedMoonlord && coins < 500)
                    {
                        coins = 500;
                    }
                    else if (coins > 25 && !Main.hardMode)
                    {
                        coins = 25;
                    }
                    string type = "CopperCoin";
                    Item.NewItem(npc.getRect(), mod.ItemType(type), coins);



                }
            }
            if (burnNPC)
            {
                damage = (int)(damage * 1.05f);
            }
            if (frostburnNPC)
            {
                damage = (int)(damage * 1.1f);
            }
            if (cursedBurnNPC)
            {
                damage = (int)(damage * 1.15f);
            }

            int index = npc.FindBuffIndex(BuffType<Decay>());
            if (decay)
            {
                if (index > -1)
                {
                    int timeDecay = npc.buffTime[index];
                    if (timeDecay <= 600)
                    {    //I HATE MYSELF FOR npc HORRIBLE IF LOOP CHAIN
                        damage = (int)(damage * 1.05);
                        if (timeDecay <= 480)
                        {
                            damage = (int)(damage * 1.1);
                            if (timeDecay <= 300)
                            {
                                damage = (int)(damage * 1.2);
                                if (timeDecay <= 120)
                                {
                                    damage = (int)(damage * 1.3);

                                }
                            }
                        }
                    }
                }
            }



            if (deflourished)
            {
                int index1 = npc.FindBuffIndex(BuffType<Deflourished>());
                if (index > -1)
                {
                    int timeDeflourished = npc.buffTime[index];
                    if (timeDeflourished <= 180)
                    {
                        damage = (int)(damage * 1.1f);
                        if (timeDeflourished <= 120)
                        {
                            damage = (int)(damage * 1.2f);
                            if (timeDeflourished <= 60)
                            {
                                damage = (int)(damage * 1.3f);
                            }
                        }
                    }

                }


            }

        }
        public override void ModifyHitByProjectile(NPC npc, Projectile projectile, ref int damage, ref float knockback, ref bool crit, ref int hitDirection)
        {
            if (projectile.ranged /* || projectile.type == 440 || projectile.type == 459*/)
            {
                for (int k = 0; k < 255; k++)
                {
                    if (Main.player[k].active)
                    {

                        float distanceCap = 640f;
                        float distanceCap1 = 704f;
                        float distanceCap2 = 768f;
                        float distanceCap3 = 832f;
                        float MaxDistance = 960f;
                        if (sharpshooter)
                        {
                            distanceCap = 800f;
                            distanceCap1 = 864f;
                            distanceCap2 = 928f;
                            distanceCap3 = 992f;
                            MaxDistance = 1056f;
                        }
                        float distance = Vector2.Distance(Main.player[k].Center, projectile.Center);
                        if (distance > distanceCap)
                        {
                            int originalDMG = damage;
                            damage -= (int)(originalDMG * 0.1);
                            if (distance > distanceCap1)
                            {
                                damage -= (int)(originalDMG * 0.1);
                                if (distance > distanceCap2)
                                {
                                    damage -= (int)(originalDMG * 0.1);
                                    if (distance > distanceCap3)
                                    {
                                        damage -= (int)(originalDMG * 0.1);
                                    }
                                }
                            }
                            if (distance > MaxDistance)
                            {
                                distance = 960f;
                            }
                        }
                    }
                }
            }

            if (projectile.type == ProjectileID.ChlorophyteBullet)
            {
                damage -= damage / 4;
            }
            if (projectile.type == ProjectileID.CrystalShard)
            {
                damage /= 5;
            }
            for (int v = 0; v < 255; v++)
            {
                if (npc.HasBuff(BuffType<OpenWounds>()) && npc.type != NPCID.TargetDummy && projectile.type == ProjectileType<Leech>())
                {
                    int Heal = damage / 20;
                    Main.player[v].statLife += Heal;
                    Main.player[v].HealEffect(Heal, true);
                }
            }


        }
        //MANIPULATON TEST
        public override bool PreAI(NPC npc)
        {
            switch (npc.type)
            {
               
            }
            if (npc.type == NPCID.Golem)
            {
                if (NovaEdgeWorld.experimentalMode)
                {
                    npc.aiStyle = -1;
                }
                else
                {
                    npc.aiStyle = 45;
                }
            }
            return true;
        }
        public override bool CheckDead(NPC npc)
        {
            switch (npc.type)
            {
                case NPCID.GolemFistLeft:
                    NPC.NewNPC((int)npc.Center.X, (int)npc.Center.Y, ModContent.NPCType<GolemFistDetachedLeft>());
                    break;
                case NPCID.GolemFistRight:
                    NPC.NewNPC((int)npc.Center.X, (int)npc.Center.Y, ModContent.NPCType<GolemFistDetachedRight>());
                    break;
            }
            return base.CheckDead(npc);
        }
        public override void AI(NPC npc)
        {
            

            switch (npc.type)
            {
                case NPCID.GolemFistLeft:
                    
                    break;
                 
            }



            if (npc.type == NPCID.Golem)
            {
                if (NovaEdgeWorld.experimentalMode)
                {
                    NPC.golemBoss = npc.whoAmI;
                    if (npc.localAI[0] == 0f && Main.netMode != NetmodeID.MultiplayerClient)
                    {
                        npc.localAI[0] = 1f;

                        // Head and Fist spawns

                        NPC.NewNPC((int)npc.Center.X - 84, (int)npc.Center.Y - 9, NPCID.GolemFistLeft, 0);
                        NPC.NewNPC((int)npc.Center.X + 78, (int)npc.Center.Y - 9, NPCID.GolemFistRight, 0);
                        NPC.NewNPC((int)npc.Center.X - 3, (int)npc.Center.Y - 57, NPCID.GolemHead, 0);
                    }
                    //Ensures that the boss does not lose opacity
                    if (npc.alpha > 0)
                    {
                        npc.alpha -= 10;
                        if (npc.alpha < 0)
                        {
                            npc.alpha = 0;
                        }
                        npc.ai[1] = 0f;
                    }
                    bool headAlive = false;
                    bool leftFistAlive = false;
                    bool rightFistAlive = false;
                    npc.dontTakeDamage = false;

                    for (int iterator = 0; iterator < 200; iterator++)
                    {

                        if (Main.npc[iterator].active && Main.npc[iterator].type == NPCID.GolemHead)
                        {
                            headAlive = true;
                        }
                        if (Main.npc[iterator].active && Main.npc[iterator].type == NPCID.GolemFistLeft)
                        {
                            leftFistAlive = true;
                        }
                        if (Main.npc[iterator].active && Main.npc[iterator].type == NPCID.Golem)
                        {
                            rightFistAlive = true;
                        }
                    }
                    npc.dontTakeDamage = headAlive;
                    //npc is all dust code for the effect after fists are lost
                    if (!leftFistAlive)
                    {
                        int LeftFistDust = Dust.NewDust(new Vector2(npc.Center.X - 80f, npc.Center.Y - 9f), 8, 8, 31, 0f, 0f, 100, default, 1f);
                        Main.dust[LeftFistDust].alpha += Main.rand.Next(100);
                        Main.dust[LeftFistDust].velocity *= 0.2f;
                        Dust LeftFistDustType2 = Main.dust[LeftFistDust];
                        LeftFistDustType2.velocity.Y = LeftFistDustType2.velocity.Y - (0.5f + (Main.rand.Next(10) * 0.1f));
                        Main.dust[LeftFistDust].fadeIn = 0.5f + (Main.rand.Next(10) * 0.1f);
                        if (Main.rand.Next(10) == 0)
                        {
                            LeftFistDust = Dust.NewDust(new Vector2(npc.Center.X - 80f, npc.Center.Y - 9f), 8, 8, 6, 0f, 0f, 0, default, 1f);
                            if (Main.rand.Next(20) != 0)
                            {
                                Main.dust[LeftFistDust].noGravity = true;
                                Main.dust[LeftFistDust].scale *= 1f + (Main.rand.Next(10) * 0.1f);
                                Dust LeftFistDustType3 = Main.dust[LeftFistDust];
                                LeftFistDustType3.velocity.Y = LeftFistDustType3.velocity.Y - 1f;
                            }
                        }
                    }
                    if (!rightFistAlive)
                    {
                        int RightFistDust = Dust.NewDust(new Vector2(npc.Center.X + 62f, npc.Center.Y - 9f), 8, 8, 31, 0f, 0f, 100, default, 1f);
                        Main.dust[RightFistDust].alpha += Main.rand.Next(100);
                        Main.dust[RightFistDust].velocity *= 0.2f;
                        Dust dust = Main.dust[RightFistDust];
                        dust.velocity.Y = dust.velocity.Y - (0.5f + (Main.rand.Next(10) * 0.1f));
                        Main.dust[RightFistDust].fadeIn = 0.5f + (Main.rand.Next(10) * 0.1f);
                        if (Main.rand.Next(10) == 0)
                        {
                            RightFistDust = Dust.NewDust(new Vector2(npc.Center.X + 62f, npc.Center.Y - 9f), 8, 8, 6, 0f, 0f, 0, default, 1f);
                            if (Main.rand.Next(20) != 0)
                            {
                                Main.dust[RightFistDust].noGravity = true;
                                Main.dust[RightFistDust].scale *= 1f + (Main.rand.Next(10) * 0.1f);
                                Dust dust2 = Main.dust[RightFistDust];
                                dust2.velocity.Y = dust2.velocity.Y - 1f;
                            }
                        }
                    }
                    bool sunBeamAttack = false;
                    npc.ai[2]++;
                    if (npc.ai[2] > 600)
                    {
                        sunBeamAttack = true;
                        npc.velocity.X *= 0;
                        npc.velocity.Y += 1f;
                        if (npc.ai[2] < 720)
                        {
                            for (int i = 0; i < 2; i++)
                            {
                                Dust.NewDustDirect(npc.Center, npc.width, npc.height, DustID.GoldFlame);

                            }
                        }
                        Vector2 laserDestination;
                        if (npc.ai[2] < 720)
                        {
                            Player player = Main.player[npc.target];
                            Vector2 ProjVelocity = player.Center - npc.Center;
                            int sign = Math.Sign(player.Center.X - npc.Center.X);
                            if(sign == -1)
                            {
                                npc.ai[3] += 0.02f;
                                laserDestination = npc.Center + new Vector2(0, 160).RotatedBy(npc.ai[3]);
                            }
                            else
                            {
                                npc.ai[3] += 0.02f;
                                laserDestination = npc.Center + new Vector2(0, 160).RotatedBy(-npc.ai[3]);
                            }
                            Vector2 vel = laserDestination - new Vector2(npc.Center.X, npc.Center.Y - 32);
                            vel.Normalize();
                            if(npc.ai[2] % 10 == 0)
                            {
                                Projectile.NewProjectile(new Vector2(npc.Center.X, npc.Center.Y - 32), vel, ProjectileType<GolemSunBeam>(), npc.damage, player.whoAmI);

                            }

                        }
                        if (npc.ai[2] == 720)
                        {
                            npc.ai[2] = 0;
                        }
                    }
                    if (npc.ai[0] == 0f && !sunBeamAttack)
                    {
                        //npc code only runs on impact , it is like a counter that scales with the loss of hp and body parts , once npc.ai[0] > 300 , the boss will jump shortly afterwards
                        if (npc.velocity.Y == 0f)
                        {
                            npc.velocity.X = npc.velocity.X * 0.8f;
                            npc.ai[1] += 1f;

                            if (npc.ai[1] > 0f)
                            {
                                if (!leftFistAlive)
                                {
                                    npc.ai[1] += 2f;
                                }
                                if (!rightFistAlive)
                                {
                                    npc.ai[1] += 2f;
                                }
                                if (!headAlive)
                                {
                                    npc.ai[1] += 4f;
                                }
                                if (npc.life < npc.lifeMax)
                                {
                                    npc.ai[1] += 2f;
                                }
                                if (npc.life < npc.lifeMax / 2)
                                {
                                    npc.ai[1] += 4f;
                                }
                                if (npc.life < npc.lifeMax / 3)
                                {
                                    npc.ai[1] += 8f;
                                }
                            }
                            if (npc.ai[1] >= 300f)
                            {
                                npc.ai[1] = -20f;
                                npc.frameCounter = 0.0;
                            }
                            else
                            {
                                if (npc.ai[1] == -1f)
                                {
                                    ///<summary>
                                    ///npc code here causes teh jump to happen
                                    ///</summary>
                                    npc.TargetClosest(true);
                                    npc.velocity.X = 4 * npc.direction;
                                    npc.velocity.Y = -12.1f;
                                    npc.ai[0] = 1f;
                                    npc.ai[1] = 0f;
                                }
                            }
                        }
                    }
                    else
                    {
                        if (npc.ai[0] == 1f)
                        {
                            if (npc.velocity.Y == 0f)
                            {
                                //Sound for impact of fall
                                Main.PlaySound(SoundID.Item, (int)npc.position.X, (int)npc.position.Y, 14);
                                npc.ai[0] = 0f;
                                for (int num714 = (int)npc.position.X - 20; num714 < (int)npc.position.X + npc.width + 40; num714 += 20)
                                {
                                    for (int iterator2 = 0; iterator2 < 4; iterator2++)
                                    {
                                        int num716 = Dust.NewDust(new Vector2(npc.position.X - 20f, npc.position.Y + npc.height), npc.width + 20, 4, 31, 0f, 0f, 100, default, 1.5f);
                                        Main.dust[num716].velocity *= 0.2f;
                                    }
                                    int num717 = Gore.NewGore(new Vector2(num714 - 20, npc.position.Y + npc.height - 8f), default, Main.rand.Next(61, 64), 1f);
                                    Main.gore[num717].velocity *= 0.4f;
                                }
                            }
                            else
                            {
                                npc.TargetClosest(true);
                                if (npc.position.X < Main.player[npc.target].position.X && npc.position.X + npc.width > Main.player[npc.target].position.X + Main.player[npc.target].width)
                                {
                                    npc.velocity.X = npc.velocity.X * 0.9f;
                                    npc.velocity.Y = npc.velocity.Y + 0.2f;
                                }
                                else
                                {
                                    if (npc.direction < 0)
                                    {
                                        npc.velocity.X = npc.velocity.X - 0.2f;
                                    }
                                    else
                                    {
                                        if (npc.direction > 0)
                                        {
                                            npc.velocity.X = npc.velocity.X + 0.2f;
                                        }
                                    }
                                    float velocityCap = 3f;
                                    if (npc.life < npc.lifeMax)
                                    {
                                        velocityCap += 1f;
                                    }
                                    if (npc.life < npc.lifeMax / 2)
                                    {
                                        velocityCap += 1f;
                                    }
                                    if (npc.life < npc.lifeMax / 4)
                                    {
                                        velocityCap += 1f;
                                    }
                                    if (npc.velocity.X < -velocityCap)
                                    {
                                        npc.velocity.X = -velocityCap;
                                    }
                                    if (npc.velocity.X > velocityCap)
                                    {
                                        npc.velocity.X = velocityCap;
                                    }
                                }
                            }
                        }
                    }
                    if (npc.target <= 0 || npc.target == 255 || Main.player[npc.target].dead)
                    {
                        npc.TargetClosest(true);
                    }
                    int num719 = 3000;

                    ///<summary>
                    ///targeting and despawn code
                    ///</summary>
                    if (Math.Abs(npc.Center.X - Main.player[npc.target].Center.X) + Math.Abs(npc.Center.Y - Main.player[npc.target].Center.Y) > num719)
                    {
                        npc.TargetClosest(true);
                        if (Math.Abs(npc.Center.X - Main.player[npc.target].Center.X) + Math.Abs(npc.Center.Y - Main.player[npc.target].Center.Y) > num719)
                        {
                            npc.active = false;
                            return;
                        }
                    }

                }
            }
            switch (npc.type)
            {
                case NPCID.GolemHeadFree:
                    npc.velocity.Y = 0;
                    npc.position.Y = Main.player[npc.target].Center.Y - 320;
                    npc.damage = 0;
                    break;
            }

        }
        public override void PostAI(NPC npc)
        {
            if (npc.type == NPCID.Golem)
            {
                if (NovaEdgeWorld.experimentalMode)
                {
                    npc.aiStyle = 45;
                }
            }
            
                
        }
        
        public override void UpdateLifeRegen(NPC npc, ref int damagePerTick)
        {
            if (fatalWounds)
            {
                if (npc.lifeRegen > 0)
                {
                    npc.lifeRegen = 0;
                }
                int latchedCount = 0;
                for (int i = 0; i < 1000; i++)
                {
                    Projectile sword = Main.projectile[i];

                    if (sword.active && sword.type == ProjectileType<FleshRipperProj>() || sword.type == ProjectileType<Leech>() && sword.ai[0] == 1f && sword.ai[1] == npc.whoAmI)
                    {
                        latchedCount++;
                        npc.lifeRegen -= latchedCount * 5;
                        damagePerTick = 5;

                    }


                }
                /*for(int q = 0; q < Terraria.NPC.maxBuffs; q++){
                    if(npc.buffType[q] == BuffID.Poisoned){
                        if(npc.life < (int)(npc.lifeMax * 0.4f)){
                            damagePerTick = 2;
                            npc.lifeRegen = -12;
                        }
                        else if(npc.)
                }
                }*/

                for (int o = 0; o < Terraria.NPC.maxBuffs; o++)
                {

                    switch (npc.buffType[o])
                    {
                        case BuffID.OnFire:
                            npc.lifeRegen -= 6;
                            break;
                        case BuffID.Poisoned:
                            if (npc.life < (int)(npc.lifeMax * 0.4f))
                            {
                                npc.lifeRegen -= 12;
                                damagePerTick = 2;
                            }

                            break;
                        case BuffID.Frostburn:
                            frostburnNPC = true;
                            break;
                        case BuffID.Venom:
                            venom = true;
                            break;
                        case BuffID.CursedInferno:
                            if (npc.wet)
                            {
                                npc.lifeRegen -= 12;
                            }
                            cursedBurnNPC = true;
                            break;
                        case 153:
                            npc.lifeRegen += 2;
                            if (!Main.dayTime)
                            {
                                npc.lifeRegen -= 17;
                            }
                            npc.defense -= 10;
                            break;
                        case BuffID.Midas:
                            Moolah = true;
                            MoolahTimer++;
                            break;




                    }
                }
            }

        }
    }
}
