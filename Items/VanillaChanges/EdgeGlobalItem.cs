using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Microsoft.Xna.Framework;
using NovaEdge.Buffs;
//using NovaEdge.Items.Ammo;
using System.Collections.Generic;
using System.IO;
using System.Linq;

using Terraria.Utilities;
using Terraria.Localization;
using Microsoft.Xna.Framework.Graphics;

namespace NovaEdge.Items.VanillaChanges
{
    public class Balance : GlobalItem
    {
        
        public override void ModifyTooltips(Item item, List<TooltipLine> tooltips)
        {
            //int itemTypeT = item.type;
            TooltipLine prefixDmg = tooltips.FirstOrDefault(x => x.Name == "PrefixDamage" && x.mod == "Terraria");
            TooltipLine prefixSpd = tooltips.FirstOrDefault(x => x.Name == "PrefixSpeed" && x.mod == "Terraria");
            TooltipLine prefixCrt = tooltips.FirstOrDefault(x => x.Name == "PrefixCritChance" && x.mod == "Terraria");
            TooltipLine prefixMan = tooltips.FirstOrDefault(x => x.Name == "PrefixUseMana" && x.mod == "Terraria");
            TooltipLine prefixSze = tooltips.FirstOrDefault(x => x.Name == "PrefixSize" && x.mod == "Terraria");
            TooltipLine prefixSht = tooltips.FirstOrDefault(x => x.Name == "PrefixShootSpeed" && x.mod == "Terraria");
            TooltipLine prefixKnb = tooltips.FirstOrDefault(x => x.Name == "PrefixKnockback" && x.mod == "Terraria");
            switch (item.type)
            {
                case ItemID.WormScarf:
                    tooltips.Add(new TooltipLine(mod, "Tooltip0", "Increases movement speed by 15% when below 25% health"));

                    break;
                // Blood Butcherer
                case 795:
                    tooltips.Add(new TooltipLine(mod, "Tooltip0", "Has a chance to heal you when striking"));
                    break;
                // Light's Bane
                case 46:
                    tooltips.Add(new TooltipLine(mod, "Tooltip0", "Has a chance to apply Confused"));
                    break;
                // Muramasa
                case 155:
                    tooltips.Add(new TooltipLine(mod, "Tooltip0", "Every strike increases swing speed\nMissing a strike resets swing speed"));
                    break;
                // Fiery Greatsword
                case 121:
                    tooltips.Add(new TooltipLine(mod, "Tooltip0", "Creates a flame trail on the ground"));
                    break;
                // Night's Edge
                case 273:
                    tooltips.Add(new TooltipLine(mod, "Tooltip0", "Has a chance to apply Decayed"));
                    break;
                // Dark Lance
                case 274:
                    tooltips.Add(new TooltipLine(mod, "Tooltip0", "Gains increased damage at night"));
                    break;
                // Gungnir
                case 550:
                    tooltips.Add(new TooltipLine(mod, "Tooltip0", "Gains increased damage at day"));
                    break;
                // Breaker Blade
                // Remove once in 1.4 TML
                case 426:
                    tooltips.Add(new TooltipLine(mod, "Tooltip0", "Deals more damage to unhurt enemies"));
                    break;
                // Keybrand
                // Remove once in 1.4 TML
                case 671:
                    tooltips.Add(new TooltipLine(mod, "Tooltip0", "Deals more damage to injured foes"));
                    break;
                // Excalibur
                case 368:
                    tooltips.Add(new TooltipLine(mod, "Tooltip0", "Has a chance to apply Divine Shower"));
                    break;
                // True Night's Edge
                case 675:
                    tooltips.Add(new TooltipLine(mod, "Tooltip0", "Right click fires a night beam\nMelee strikes have a chance to apply Decayed"));
                    break;
                // True Excalibur
                case 674:
                    tooltips.Add(new TooltipLine(mod, "Tooltip0", "Right click fires a light beam that seeks enemies after a while\nMelee strikes apply Divine Shower"));
                    break;
                // Aerial Bane
                case 3859:
                    TooltipLine AerialBaneTooltip = tooltips.FirstOrDefault(x => x.Name == "Tooltip0" && x.mod == "Terraria");
                    if (AerialBaneTooltip != null)
                    {
                        AerialBaneTooltip.text = "Arrows split on airborne enemy hits\nWooden arrows turn into special arrows that apply Betsy's Wrath";
                    }
                    break;
                //Phaseblades
                //ADD ORANGE PHASEBLADE ON 1.4 TML
                case 198: //blue
                    tooltips.Add(new TooltipLine(mod, "Tooltip0", "Has a chance to apply Electrified"));
                    break;
                case 199: //red
                    tooltips.Add(new TooltipLine(mod, "Tooltip0", "Has a chance to apply Electrified"));
                    break;
                case 200: //green
                    tooltips.Add(new TooltipLine(mod, "Tooltip0", "Has a chance to apply Electrified"));
                    break;
                case 201: //purple
                    tooltips.Add(new TooltipLine(mod, "Tooltip0", "Has a chance to apply Electrified"));
                    break;
                case 202: //white
                    tooltips.Add(new TooltipLine(mod, "Tooltip0", "Has a chance to apply Electrified"));
                    break;
                case 203: //yellow
                    tooltips.Add(new TooltipLine(mod, "Tooltip0", "Has a chance to apply Electrified"));
                    break;
                //Now, its Phasesabers
                //ADD ORANGE PHASESABER ON 1.4 TML
                case 3764: //blue
                    tooltips.Add(new TooltipLine(mod, "Tooltip0", "Has a chance to apply Electrified\nHold right click to deflect any non-piercing projectiles"));
                    break;
                case 3765: //red
                    tooltips.Add(new TooltipLine(mod, "Tooltip0", "Has a chance to apply Electrified\nHold right click to deflect any non-piercing projectiles"));
                    break;
                case 3766: //green
                    tooltips.Add(new TooltipLine(mod, "Tooltip0", "Has a chance to apply Electrified\nHold right click to deflect any non-piercing projectiles"));
                    break;
                case 3767: //purple
                    tooltips.Add(new TooltipLine(mod, "Tooltip0", "Has a chance to apply Electrified\nHold right click to deflect any non-piercing projectiles"));
                    break;
                case 3768: //white
                    tooltips.Add(new TooltipLine(mod, "Tooltip0", "Has a chance to apply Electrified\nHold right click to deflect any non-piercing projectiles"));
                    break;
                case 3769: //yellow
                    tooltips.Add(new TooltipLine(mod, "Tooltip0", "Has a chance to apply Electrified\nHold right click to deflect any non-piercing projectiles"));
                    break;
            }
            if (item.type == ItemID.BloodButcherer || item.type == ItemID.LightsBane || item.type == ItemID.Muramasa || item.type == ItemID.FieryGreatsword || item.type == ItemID.NightsEdge || item.type == ItemID.DarkLance || item.type == ItemID.Gungnir || item.type == ItemID.BreakerBlade /*remove after 1.4*/ || item.type == ItemID.Keybrand /*remove after 1.4*/ || item.type == ItemID.Excalibur || item.type == ItemID.TrueNightsEdge || item.type == ItemID.TrueExcalibur || item.type == ItemID.BluePhaseblade || item.type == ItemID.RedPhaseblade || item.type == ItemID.GreenPhaseblade || item.type == ItemID.PurplePhaseblade || item.type == ItemID.WhitePhaseblade || item.type == ItemID.YellowPhaseblade || item.type == ItemID.BluePhasesaber || item.type == ItemID.RedPhasesaber || item.type == ItemID.GreenPhasesaber || item.type == ItemID.PurplePhasesaber || item.type == ItemID.WhitePhasesaber || item.type == ItemID.YellowPhasesaber)
            {
                if (prefixDmg != null)
                {
                    tooltips.Remove(prefixDmg);
                    tooltips.Add(prefixDmg);
                }
                if (prefixSpd != null)
                {
                    tooltips.Remove(prefixSpd);
                    tooltips.Add(prefixSpd);
                }
                if (prefixCrt != null)
                {
                    tooltips.Remove(prefixCrt);
                    tooltips.Add(prefixCrt);
                }
                if (prefixMan != null)
                {
                    tooltips.Remove(prefixMan);
                    tooltips.Add(prefixMan);
                }
                if (prefixSze != null)
                {
                    tooltips.Remove(prefixSze);
                    tooltips.Add(prefixSze);
                }
                if (prefixSht != null)
                {
                    tooltips.Remove(prefixSht);
                    tooltips.Add(prefixSht);
                }
                if (prefixKnb != null)
                {
                    tooltips.Remove(prefixKnb);
                    tooltips.Add(prefixKnb);
                }
            }
        }
        //Extractinator thingyys
        
        public override void ExtractinatorUse(int extractType, ref int resultType, ref int resultStack)
        {
            //if(ext.type == ItemID.SlushBlock){
            if (extractType == ItemID.SlushBlock)
            {
                if (Main.rand.NextBool(18))
                {
                    resultType = ItemType<Items.Materials.IceSphere>();

                }
            }
        }

        public static bool frostGauntlet = false;


        /*public override void ResetEffects(Item item){
            frostGauntlet = false;
        }*/



        //Some Dumb Shit i tried for Prefixes
        /*public byte durable;
        public Durable() {
			durable = 0;
        }
        public override bool InstancePerEntity => true;

        public override GlobalItem Clone(Item item, Item itemClone){
            EdgeGlobalItem Clone = (EdgeGlobalItem)base.Clone(item, itemClone);
            Clone.awesome = awesome;
            return Clone;
        }

        public override int ChoosePrefix(Item item ,UnifiedRandom rand){
            if(item.accessory && item.maxStack == 1 && rand.NextBool(30)){
                return mod.PrefixType("Durable");
            }
        }
        public override void ModifyTooltips(Item item , Lists<TooltipLine> tooltips){
            if(item.prefix > 0){
                int durableBonus = durable - Main.cpItem.GetGlobalItem<EdgeGlobalItem>().durable;
                if(durableBonus > 0){
                    TooltipLine line = new TooltipLine("Durable") {
						isModifier = true;
					};
					tooltips.Add(line);
                }
            }
        } */


        public override void UpdateAccessory(Item item, Player player, bool hideVisual)
        {


            switch (item.type)
            {
                case ItemID.WormScarf:

                    if (player.statLife <= (player.statLifeMax + player.statLifeMax2) / 4)
                    {
                        player.moveSpeed += 0.15f;

                    }

                    break;
            }
        }


        //WEAPON/ARMOR STAT BALANCE

        public override void UpdateEquip(Item item, Player player)
        {
            if (item.type == ItemID.NecroGreaves)
            {
                player.noFallDmg = true;
            }
            /*if(item.type == ItemType<SteelEssence>()){
                if(player.HasBuff(BuffID.PotionSickness)){     //found a better way to do this
                    player.AddBuff(BuffType<Buffs.SteelDefense>() , 300);
                }
            }*/
        }

        public override void SetDefaults(Item item)
        {
            if(item.melee && item.useStyle == 3 || item.useStyle == 1)
            {
                item.damage *= 2;
            }
            if (item.melee)
            {
                item.autoReuse = true;

            }

            //DART AMMO TYPE
            int itemType3 = item.type;
            switch (itemType3)
            {
                case ItemID.IchorDart:
                    item.ammo = AmmoID.Dart;
                    break;
                case ItemID.CrystalDart:
                    item.ammo = AmmoID.Dart;
                    break;
                case ItemID.CursedDart:
                    item.ammo = AmmoID.Dart;
                    break;
                case ItemID.PoisonDart:
                    item.ammo = AmmoID.Dart;
                    break;


            }
            if (item.ammo == AmmoID.Bullet || item.ammo == AmmoID.Arrow)
            {
                item.damage /= 2;
            }
            int itemArmor = item.type;

            if(item.useStyle == 3)
            {
                item.autoReuse = false;
                item.useStyle = 13;
                item.useAnimation = 21;
                item.useTime = 7;
                item.reuseDelay = 14;
                item.width = 50;
                item.height = 18;
                item.shoot = ModContent.ProjectileType <GladiusStyleShorties>();
                item.UseSound = SoundID.Item1;
                item.damage = 15;
                item.shootSpeed = 2.4f;
                item.noMelee = true;
                item.value = Item.sellPrice(1);
                item.melee = true;
                item.knockBack = 0.5f;
                item.noUseGraphic = true;
            }
            //ARMOR CHANGES
            /*switch(itemArmor)
            {
                case ItemID.MythrilHood:
                    item.defense = 60;
                    break;
            }*/

           

            switch (item.type)
            {
                
                case ItemID.BloodyMachete:
                    item.damage = 24;
                    item.crit = 8;
                    item.shootSpeed = 10;
                    break;
                case ItemID.TerraBlade:
                    item.damage = 114;
                    break;

                case ItemID.BladeofGrass:
                    item.damage = 52;
                    break;

                case ItemID.BloodButcherer:
                    item.damage = 40;
                    break;

                case ItemID.BreakerBlade:
                    item.damage = 65;
                    break;

                case ItemID.DarkLance:
                    item.damage = 40;
                    if (!Main.dayTime)
                    {
                        item.damage = (int)(item.damage * 1.3f);
                    }
                    break;

                case ItemID.Excalibur:
                    item.damage = 115;
                    break;

                case ItemID.Keybrand:
                    item.damage = 125;
                    break;

                case ItemID.LightsBane:
                    item.damage = 25;
                    item.useTime = 10;
                    item.useAnimation = 10;
                    item.useStyle = ItemUseStyleID.Stabbing;
                    break;

                case ItemID.Muramasa:
                    item.damage = 32;
                    break;

                case ItemID.FieryGreatsword:
                    item.damage = 80;
                    break;

                case ItemID.NightsEdge:
                    item.damage = 72;
                    break;

                case ItemID.PsychoKnife:
                    item.damage = 75;
                    item.useTime = 7;
                    item.useAnimation = 7;
                    item.useStyle = ItemUseStyleID.Stabbing;
                    break;

                case ItemID.Gungnir:
                    item.damage = 60;
                    if (Main.dayTime)
                    {
                        item.damage = (int)(item.damage * 1.15f);
                    }
                    break;
                
                case ItemID.TaxCollectorsStickOfDoom: //Classy Cane
                    item.damage = 32;
                    break;

                case ItemID.SlapHand:
                    item.damage = 70;
                    break;

                case ItemID.Cutlass:
                    item.damage = 85;
                    break;

                case ItemID.ChlorophyteSaber:
                    item.damage = 96;
                    break;
                case ItemID.ChlorophyteClaymore:
                    item.damage = 150;
                    break;
                case ItemID.ChlorophytePartisan:
                    item.damage = 105;
                    break;

                case ItemID.Bladetongue:
                    item.damage = 90;
                    break;

                case ItemID.FetidBaghnakhs:
                    item.damage = 62;
                    break;

                case ItemID.Seedler:
                    item.damage = 100;
                    break;

                case ItemID.TheHorsemansBlade:
                    item.damage = 135;
                    break;

                case ItemID.InfluxWaver:
                    item.damage = 135;
                    break;

                case ItemID.DD2SquireDemonSword: //Brand of the Inferno
                    item.damage = 150;
                    break;

                case ItemID.MonkStaffT2: //Ghastly Glaive
                    item.damage = 100;
                    break;

                case ItemID.MonkStaffT1: //Sleepy Octopod
                    item.damage = 105;
                    break;

                case ItemID.ChristmasTreeSword:
                    item.damage = 165;
                    break;

                case ItemID.DD2SquireBetsySword: //Flying Dragon
                    item.damage = 220;
                    break;

                case ItemID.MushroomSpear:
                    item.damage = 120;
                    break;

                case ItemID.ObsidianSwordfish:
                    item.damage = 120;
                    break;

                case ItemID.CursedFlames:
                    item.useTime = 6;
                    item.reuseDelay = 20;
                    item.useAnimation = 18;
                    item.shootSpeed = 8.5f;
                    break;

            }

            if (item.type >= ItemID.BluePhaseblade && item.type <= ItemID.YellowPhaseblade)
            {
                item.damage = 45;
            }

            if (item.type >= ItemID.BluePhasesaber && item.type <= ItemID.YellowPhasesaber)
            {
                item.damage = 86;
            }

        }
        public override bool AltFunctionUse(Item item, Player player)
        {
            if (item.type >= ItemID.BluePhasesaber && item.type <= ItemID.YellowPhasesaber)
            {
                return true;
            }
            else
            {
                return base.AltFunctionUse(item, player);

            }
        }

        //Vector2 spawnPosPlayer;
        private void SpawnProjNearPlayer(int type, Player player, NPC target, float knockBack, int damage, Vector2 velocity, float distance, bool moveTowards, float velMultiplier)
        {
            Vector2 spawnPosPlayer = new Vector2(Main.rand.NextBool(2) ? player.Center.X - distance : player.Center.X + distance, player.Center.Y - distance);
            if (moveTowards)
            {
                velocity = target.Center - spawnPosPlayer;
                velocity.Normalize();
            }

            Projectile.NewProjectile(spawnPosPlayer, velocity * velMultiplier, type, damage, knockBack, player.whoAmI);
        }

        //Increase distance a lot for off screen spawns
        //These are 8 directional positions , probs could do it better

        private void SpawnProjNearNPC(int type, Player player, NPC target, float knockBack, int damage, Vector2 velocity, float distance, bool moveTowards, float velMultiplier)
        {
            Vector2 spawnPos = new Vector2(Main.rand.NextBool(2) ? target.Center.X - distance : target.Center.X + distance, Main.rand.NextBool(2) ? target.Center.Y - distance : target.Center.Y + distance);
            if (moveTowards)
            {
                velocity = target.Center - spawnPos;
                velocity.Normalize();
            }
            Projectile.NewProjectile(spawnPos, velocity * velMultiplier, type, damage, knockBack, player.whoAmI);
        }
        private void SpawnNearCursor(int type, Player player, NPC target, float knockBack, int damage, Vector2 velocity, float distance, bool moveTowards, float velMultiplier)
        {
            Vector2 spawnNearCursorPos = new Vector2(Main.rand.NextBool(2) ? Main.MouseWorld.X - distance : Main.MouseWorld.X + distance, Main.rand.NextBool(2) ? Main.MouseWorld.Y - distance : Main.MouseWorld.Y + distance);
            if (moveTowards)
            {
                velocity = target.Center - spawnNearCursorPos;
                velocity.Normalize();
            }
            Projectile.NewProjectile(spawnNearCursorPos, velocity * velMultiplier, type, damage, knockBack, player.whoAmI);
        }



        public override void OnHitNPC(Item item, Player player, NPC target, int damage, float knockback, bool crit)
        {






            var ModPlayer = player.GetModPlayer<Items.AssassinClass.AssassinPlayer>();







            if (ModPlayer.FullBloodLust)
            {
                switch (item.type)
                {
                    case ItemID.LightsBane:
                        if (Main.rand.NextBool(2))
                        {
                            target.AddBuff(BuffID.ShadowFlame, 90);

                        }
                        if (Main.rand.NextBool(6))
                        {
                            SpawnProjNearNPC(ProjectileID.CorruptSpray, player, target, 3f, 20, Vector2.Zero, 32, false, 0);

                        }
                        break;

                    case ItemID.BladeofGrass:
                        if (Main.rand.NextBool(5))
                        {
                            target.AddBuff(BuffID.Venom, 300);

                        }

                        if (Main.rand.NextBool(4))
                        {
                            SpawnProjNearNPC(ProjectileID.SporeTrap, player, target, 4f, item.damage, Vector2.Zero, 32, true, 1);
                        }

                        break;
                    case ItemID.FieryGreatsword:
                        if (Main.rand.NextBool(2))
                        {

                            SpawnProjNearPlayer(ProjectileID.BallofFire, player, target, 3f, item.damage, Vector2.Zero, 64, true, 1f);

                        }
                        else if (Main.rand.NextBool(8))
                        {
                            for (int i = 0; i < Main.rand.Next(2, 5); i++)
                            {
                                SpawnProjNearPlayer(ProjectileID.BallofFire, player, target, 3f, item.damage, Vector2.Zero.RotatedByRandom(MathHelper.ToRadians(90)), 64, true, 3);
                            }
                        }
                        break;
                    case ItemID.NightsEdge:
                        if (Main.rand.NextBool(6))
                        {
                            target.AddBuff(BuffID.ShadowFlame, 240);
                        }
                        if (Main.rand.NextBool(3))
                        {


                            SpawnProjNearNPC(ProjectileID.NightBeam, player, target, 6f, item.damage, Vector2.Zero, 320f, true, 9f);

                        }
                        break;
                    case ItemID.BloodButcherer:
                        if (Main.rand.NextBool(2))
                        {
                            SpawnNearCursor(ProjectileType<Projectiles.BloodClot>(), player, target, 4f, item.damage, Vector2.Zero, 32, true, 1f);
                        }
                        break;
                    case ItemID.Seedler:
                        if (Main.rand.NextBool(2))
                        {
                            SpawnNearCursor(ProjectileID.SeedlerNut, player, target, 3f, 60, Vector2.Zero, 0, true, 5f);
                        }
                        else if (Main.rand.NextBool(6))
                        {
                            for (int i = 0; i < 4; i++)
                            {
                                SpawnNearCursor(ProjectileID.SeedlerNut, player, target, 3f, item.damage, Vector2.Zero.RotatedBy(MathHelper.ToRadians(45)), 0, true, 7f);
                            }
                        }
                        break;
                    case ItemID.TheHorsemansBlade:
                        if (Main.rand.NextBool(6))
                        {
                            float Spread = 0;
                            for (int i = 0; i < 9; i++)
                            {
                                Spread += 36;
                                Vector2 circle = target.Center + new Vector2(0, 64).RotatedBy(MathHelper.ToRadians(Spread));
                                Projectile.NewProjectile(circle, Vector2.Zero, ProjectileID.FlamingJack, 120, 4f, player.whoAmI);

                            }
                        }
                        break;
                    case ItemID.TrueNightsEdge:
                        if (Main.rand.NextBool(2))
                        {
                            for (int i = 0; i < 5; i++)
                            {
                                SpawnProjNearNPC(ProjectileID.NightBeam, player, target, 6f, item.damage, Vector2.Zero, 320f, true, 7f);

                            }
                        }
                        break;
                    case ItemID.InfluxWaver:
                        if (Main.rand.NextBool(3))
                        {
                            SpawnProjNearPlayer(ProjectileID.InfluxWaver, player, target, 6f, item.damage, Vector2.Zero, 64, true, 11f);
                        }
                        else if (Main.rand.NextBool(10))
                        {
                            float spread = 0;
                            for (int i = 0; i < 9; i++)
                            {
                                spread += 36;
                                Vector2 circle = target.Center + new Vector2(0, 96).RotatedBy(MathHelper.ToRadians(spread));
                                Vector2 vel = target.Center - circle;
                                vel.Normalize();
                                Projectile.NewProjectile(circle, vel * 11f, ProjectileID.InfluxWaver, item.damage, 4f, player.whoAmI);

                            }
                        }
                        break;
                    case ItemID.EnchantedSword:
                        if (Main.rand.NextBool(2))
                        {
                            SpawnProjNearPlayer(ProjectileID.EnchantedBeam, player, target, 4f, item.damage, Vector2.Zero, 128, true, 9f);
                        }
                        break;
                    case ItemID.Bladetongue:
                        if (Main.rand.NextBool(2))
                        {
                            SpawnNearCursor(ProjectileID.GoldenShowerFriendly, player, target, 5f, item.damage, Vector2.Zero, 64, true, 9f);

                        }
                        break;
                    case ItemID.Meowmere:
                        if (Main.rand.NextBool(5))
                        {
                            float spread = 0;
                            for (int i = 0; i < 9; i++)
                            {
                                spread += 36;
                                Vector2 circle = target.Center + new Vector2(0, 96).RotatedBy(MathHelper.ToRadians(spread));
                                Vector2 vel = target.Center - circle;
                                vel.Normalize();
                                Projectile.NewProjectile(circle, vel * 11f, ProjectileID.Meowmere, item.damage, 4f, player.whoAmI);

                            }
                        }
                        break;
                    case ItemID.TrueExcalibur:
                        SpawnProjNearNPC(ProjectileID.LightBeam, player, target, 5f, item.damage, Vector2.Zero, 512, true, 14f);
                        break;
                    case ItemID.TerraBlade:
                        if (Main.rand.NextBool(2))
                        {
                            SpawnProjNearNPC(ProjectileID.LightBeam, player, target, 4f, item.damage, Vector2.Zero, 320, true, 11f);
                        }
                        if (Main.rand.NextBool(3))
                        {
                            SpawnProjNearNPC(ProjectileID.NightBeam, player, target, 4f, item.damage, Vector2.Zero, 320, true, 11f);

                        }
                        if (Main.rand.NextBool(4))
                        {
                            SpawnProjNearNPC(ModContent.ProjectileType<Projectiles.FleshRipperProj>(), player, target, 6f, item.damage, Vector2.Zero, 320, true, 11f);

                        }
                        break;








                }
            }
            if (Main.rand.NextBool(2) && frostGauntlet)
            {
                target.AddBuff(BuffID.OnFire, 300);
                if (Main.rand.NextBool(2))
                {
                    target.AddBuff(BuffID.Frostburn, 300);
                }
            }
            if (target.HasBuff(BuffType<OpenWounds>()) && target.type != NPCID.TargetDummy)
            {
                int Heal = damage / 20;
                player.statLife += Heal;
                player.HealEffect(Heal, true);
            }
            if (target.HasBuff(BuffType<Deflourished>()) && target.type != NPCID.TargetDummy)
            {
                int Heal = damage / 15;
                player.statLife += Heal;
                player.HealEffect(Heal, true);
            }





            int type = item.type;
            switch (type)
            {
                case 795:  //Blood Butcherer , Heal effect
                    int Heal = damage / 5;
                    if (Main.rand.NextBool(3) && target.type != NPCID.TargetDummy)
                    {
                        player.statLife += Heal;
                        player.HealEffect(Heal, true);
                    }
                    break;


                //PHASEBLADES


                case 198: //Blue
                case 199: //Red
                case 200: //Green
                case 201: //Purple
                case 202: //White
                case 203: //Yellow
                    if (Main.rand.NextBool(3))
                    {
                        target.AddBuff(BuffType<Electrified>(), 360);
                    }
                    break;

                //PHASEBLADES end

                //PHASESABERS

                case 3794:
                    
                case 3795: //Red
                    
                case 3796: //Green
                    
                case 3797: //Purple
                    
                case 3798: //White
                    
                case 3799: //Yellow
                    if (Main.rand.NextBool(2))
                    {
                        target.AddBuff(BuffType<Electrified>(), 360);
                    }
                    break;

                //PHASESABERS end


                case 368: //Excalibur
                    if (Main.rand.NextBool(2))
                    {
                        target.AddBuff(BuffID.Confused, 300);
                    }
                    break;
                case 46: //Light's Bane
                    if (Main.rand.NextBool(5))
                    {
                        target.AddBuff(BuffID.Confused, 300);
                    }
                    break;
                case 273: //Night's Edge
                    if (Main.rand.NextBool(5))

                    {
                        target.AddBuff(BuffType<Paralyzed>(), 60);
                    }
                    break;
                case 675: //True Night's Edge
                    if (Main.rand.NextBool(5))
                    {
                        target.AddBuff(BuffType<Paralyzed>(), 180);
                    }
                    break;
                case 674: //True Excalibur
                    target.AddBuff(BuffID.Confused, 300);
                    break;

            }


        }
        public override void MeleeEffects(Item item, Player player, Rectangle hitbox)
        {
            if (frostGauntlet)
            {

                Dust.NewDust(new Vector2(hitbox.X, hitbox.Y), hitbox.Width, hitbox.Height, DustID.Fire);
                Dust.NewDust(new Vector2(hitbox.X, hitbox.Y), hitbox.Width, hitbox.Height, 60);
            }


            //BLoodlust 
            var ModPlayer = player.GetModPlayer<Items.AssassinClass.AssassinPlayer>();
            if (item.type == ItemID.Excalibur)
            {

                if (ModPlayer.FullBloodLust)
                {
                    Dust.NewDust(new Vector2(hitbox.X, hitbox.Y), hitbox.Width, hitbox.Height, DustID.PinkFlame);

                }
            }


        }
        public override void ModifyHitNPC(Item item, Player player, NPC target, ref int damage, ref float knockback, ref bool crit)
        {
            if (player.HasBuff(BuffType<Sharpshooter>()) && item.useAmmo == AmmoID.Bullet && item.ranged)
            {
                float speed = item.shootSpeed;
                item.shootSpeed += speed * 0.15f;
            }

            int type2 = item.type;
            switch (type2)
            {
                case 426: //Breaker Blade , 1.4 functionality
                    if (target.life >= (target.lifeMax * 0.75f))
                    {
                        damage *= 2;
                    }
                    break;
                case 671: //Keybrand , 1.4 Functionality
                    if (target.life > (int)(target.lifeMax * 0.1f))
                    {
                        damage *= (1 + 5 / 3 * (1 - target.life / target.lifeMax));
                    }
                    break;
                case 155: //Muramasa

                    for (int i = 0; i <= 13; i++)
                    {
                        player.meleeSpeed += 0.03f * i;
                    }
                    break;

            }
            //BLOOD RAGE EFFECT
            if (target.HasBuff(BuffType<FatalWounds>()) && item.melee)
            {
                damage = (int)(damage * 1.2f);

            }

        }
        public override bool CanUseItem(Item item, Player player)
        {


            var ModPlayer = player.GetModPlayer<Items.AssassinClass.AssassinPlayer>();
            if (ModPlayer.FullBloodLust)
            {
                switch (item.type)
                {
                    case ItemID.Excalibur:
                        item.shoot = ProjectileID.LightBeam;
                        item.shootSpeed = 9f;
                        break;
                    case ItemID.Muramasa:
                        item.shoot = ProjectileID.WaterBolt;
                        item.shootSpeed = 5f;
                        break;




                }
            }
            else
            {
                switch (item.type)
                {
                    case ItemID.Excalibur:
                        item.shoot = -1;
                        item.shootSpeed = 0;
                        break;
                    case ItemID.Muramasa:
                        item.shoot = -1;
                        item.shootSpeed = 0;
                        break;
                    case ItemID.BluePhasesaber:
                        if (player.altFunctionUse == 2)
                        {
                            item.shoot = ModContent.ProjectileType<PhasesaberProj>();
                            item.noMelee = true;
                            item.noUseGraphic = true;

                        }
                        else if (player.altFunctionUse != 2)
                        {
                            item.shoot = -1;

                            item.noMelee = false;
                            item.noUseGraphic = false;
                        }

                        break;
                }
            }



            return base.CanUseItem(item, player);
        }
        public override bool Shoot(Item item, Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {

            
            if (item.ranged && item.useAmmo == AmmoID.Bullet)
            {
                item.shoot = type;
            }

            var ModPlayer = player.GetModPlayer<Items.AssassinClass.AssassinPlayer>();
            if (ModPlayer.FullBloodLust)
            {
                switch (item.type)
                {
                    case ItemID.StarWrath:
                        Vector2 shootPos = new Vector2(player.Center.X, player.Center.Y - 16);
                        for (int i = 0; i < Main.rand.Next(1, 4); i++)
                        {
                            shootPos.X += 8;
                            Projectile.NewProjectile(shootPos, new Vector2(speedX, speedY).RotatedByRandom(MathHelper.ToRadians(5)) * 13f, ProjectileID.StarWrath, 120, 7f, player.whoAmI);
                        }
                        break;
                }
            }



            //HARDMODE REPEATERS
            if (item.type == ItemID.FairyBell || item.type == ItemID.PalladiumRepeater || item.type == ItemID.AdamantiteRepeater || item.type == ItemID.HallowedRepeater || item.type == ItemID.MythrilRepeater || item.type == ItemID.OrichalcumRepeater || item.type == ItemID.TitaniumRepeater)
            {
                int ArrowCount = 0;
                for (int i = 0; i <= ArrowCount; i++)
                {
                    Vector2 Speed = new Vector2(speedX, speedY).RotatedByRandom(MathHelper.ToRadians(3));
                    Projectile.NewProjectile(position.X, position.Y, Speed.X, Speed.Y, type, damage, knockBack, player.whoAmI);
                }

            }
            return true;

        }

        //DEFINing WHAT IS AN ARMOR SET
        public override string IsArmorSet(Item head, Item body, Item legs)
        {
            //MYTHRIL
            if (head.type == ItemID.MythrilHood && body.type == ItemID.MythrilChainmail && legs.type == ItemID.MythrilGreaves)
            {
                return "NovaEdge:MythrilMage";
            }
            else if (head.type == ItemID.MythrilHat && body.type == ItemID.MythrilChainmail && legs.type == ItemID.MythrilGreaves)
            {
                return "NovaEdge:MythrilRanged";
            }
            else if (head.type == ItemID.MythrilHelmet && body.type == ItemID.MythrilChainmail && legs.type == ItemID.MythrilGreaves)
            {
                return "NovaEdge:MythrilMelee";
            }
            //ADAMANTITE
            else if (head.type == ItemID.AdamantiteMask && body.type == ItemID.AdamantiteBreastplate && legs.type == ItemID.AdamantiteLeggings)
            {
                return "NovaEdge:AdamantiteRanged";
            }
            else if (head.type == ItemID.AdamantiteHelmet && body.type == ItemID.AdamantiteBreastplate && legs.type == ItemID.AdamantiteLeggings)
            {
                return "NovaEdge:AdamantiteMelee";
            }
            else if (head.type == ItemID.AdamantiteHeadgear && body.type == ItemID.AdamantiteBreastplate && legs.type == ItemID.AdamantiteLeggings)
            {
                return "NovaEdge:AdamantiteMage";
            }
            //COBALT
            else if (head.type == ItemID.CobaltHat && body.type == ItemID.CobaltBreastplate && legs.type == ItemID.CobaltLeggings)
            {
                return "NovaEdge:CobaltMage";
            }
            else if (head.type == ItemID.CobaltHelmet && body.type == ItemID.CobaltBreastplate && legs.type == ItemID.CobaltLeggings)
            {
                return "NovaEdge:CobaltMelee";
            }
            else if (head.type == ItemID.CobaltMask && body.type == ItemID.CobaltBreastplate && legs.type == ItemID.CobaltLeggings)
            {
                return "NovaEdge:CobaltRanged";
            }
            else if (head.type == ItemID.WizardHat && body.type == ItemID.AmethystRobe || body.type == ItemID.TopazRobe || body.type == ItemID.SapphireRobe || body.type == ItemID.EmeraldRobe || body.type == ItemID.RubyRobe || body.type == ItemID.DiamondRobe || body.type == ItemID.GypsyRobe)
                return "NovaEdge:WizardRobe";

            return base.IsArmorSet(head, body, legs);
        }
        //CHANGES TO ARMOR SET BONUSES

        public override void UpdateArmorSet(Player player, string set)
        {

            string ArmorSet = set;
            switch (ArmorSet)
            {

                //MYTHRIL , GOTTA ADD THE BUFF LATER
                case "NovaEdge:MythrilMage":
                    player.magicCrit += 9;
                    player.setBonus = "9% increased magic critical strike \nGetting hit increases damage temporarily by 5% , stacks upto 3 times";
                    player.GetModPlayer<NovaEdgePlayer>().mythrilEnrage = true;
                    break;
                case "NovaEdge:MythrilRanged":
                    player.rangedDamage += 0.06f;
                    player.setBonus = "6% increased ranged damage \nGetting hit increases damage temporarily by 5% , stacks upto 3 times";
                    player.GetModPlayer<NovaEdgePlayer>().mythrilEnrage = true;
                    break;
                case "NovaEdge:MythrilMelee":
                    player.meleeSpeed += 0.11f;
                    player.meleeCrit += 6;
                    player.setBonus = "6% increased melee critical strike chance \n11% increased melee speed \nGetting hit increases damage temporarily by 5% , stacks upto 3 times";
                    player.GetModPlayer<NovaEdgePlayer>().mythrilEnrage = true;
                    break;

                //<MYTHRIL END
                case "NovaEdge:WizardRobe":
                    player.magicCrit -= 4;
                    player.setBonus = "8% increased magic critical strike chance";
                    break;








            }

        }
        public override void AddRecipes()
        {
            ModRecipe recipe1 = new ModRecipe(mod);
            recipe1.AddIngredient(ItemID.BottledWater, 20);
            recipe1.AddIngredient(ItemID.LifeCrystal);
            recipe1.AddIngredient(ItemID.Daybloom, 20);
            recipe1.AddTile(TileID.Bottles);
            recipe1.SetResult(ItemID.HeartreachPotion, 20);
            recipe1.AddRecipe();

            ModRecipe recipe2 = new ModRecipe(mod);
            recipe2.AddIngredient(ItemID.BottledWater, 3);
            recipe2.AddIngredient(ItemID.Vine, 1);
            recipe2.AddIngredient(ItemID.Moonglow, 3);
            recipe2.AddTile(TileID.Bottles);
            recipe2.SetResult(ItemID.SummoningPotion, 3);
            recipe2.AddRecipe();

            ModRecipe recipe3 = new ModRecipe(mod);
            recipe3.AddIngredient(ItemID.BottledWater);
            recipe3.AddIngredient(ItemID.MusketBall, 30);
            recipe3.AddIngredient(ItemID.Moonglow, 1);
            recipe3.AddTile(TileID.Bottles);
            recipe3.SetResult(ItemID.AmmoReservationPotion);
            recipe3.AddRecipe();

            ModRecipe recipe4 = new ModRecipe(mod);
            recipe4.AddIngredient(ItemID.BottledWater);
            recipe4.AddIngredient(ItemID.EbonstoneBlock, 20);
            recipe4.AddIngredient(ItemID.Deathweed, 1);
            recipe4.AddTile(TileID.Bottles);
            recipe4.SetResult(ItemID.WrathPotion);
            recipe4.AddRecipe();

            ModRecipe recipe5 = new ModRecipe(mod);
            recipe5.AddIngredient(ItemID.BottledWater);
            recipe5.AddIngredient(ItemID.CrimstoneBlock, 20);
            recipe5.AddIngredient(ItemID.Deathweed, 1);
            recipe5.AddTile(TileID.Bottles);
            recipe5.SetResult(ItemID.RagePotion);
            recipe5.AddRecipe();

            ModRecipe recipe6 = new ModRecipe(mod);
            recipe6.AddIngredient(ItemID.BottledWater);
            recipe6.AddIngredient(ItemID.StoneBlock, 10);
            recipe6.AddRecipeGroup("NovaEdge:FerrumOre", 1);
            recipe6.AddTile(TileID.Bottles);
            recipe6.SetResult(ItemID.EndurancePotion);
            recipe6.AddRecipe();

        }





    }



}