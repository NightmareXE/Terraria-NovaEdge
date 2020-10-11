using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Microsoft.Xna.Framework;
using NovaEdge.Buffs;
using NovaEdge.Items.Ammo;
using System.Collections.Generic;
using System.IO;
using Terraria.Utilities;
using Terraria.Localization;
using System.Linq;

namespace NovaEdge.Items.VanillaChanges{
    public class Balance : GlobalItem
    {
        public override void ModifyTooltips(Item item, List<TooltipLine> tooltips){
            int itemTypeT = item.type;
            TooltipLine prefixDmg = tooltips.FirstOrDefault(x => x.Name == "PrefixDamage" && x.mod == "Terraria");
            TooltipLine prefixSpd = tooltips.FirstOrDefault(x => x.Name == "PrefixSpeed" && x.mod == "Terraria");
            TooltipLine prefixCrt = tooltips.FirstOrDefault(x => x.Name == "PrefixCritChance" && x.mod == "Terraria");
            TooltipLine prefixMan = tooltips.FirstOrDefault(x => x.Name == "PrefixUseMana" && x.mod == "Terraria");
            TooltipLine prefixSze = tooltips.FirstOrDefault(x => x.Name == "PrefixSize" && x.mod == "Terraria");
            TooltipLine prefixSht = tooltips.FirstOrDefault(x => x.Name == "PrefixShootSpeed" && x.mod == "Terraria");
            TooltipLine prefixKnb = tooltips.FirstOrDefault(x => x.Name == "PrefixKnockback" && x.mod == "Terraria");
            switch (itemTypeT){
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
                    if (AerialBaneTooltip != null){
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
            if(item.type == 795 || item.type == 46 || item.type == 155 || item.type == 121 || item.type == 273 || item.type == 274 || item.type == 550 || item.type == 426 /*remove after 1.4*/ || item.type == 671 /*remove after 1.4*/ || item.type == 368 || item.type == 675 || item.type == 674 || item.type == 198 || item.type == 199 || item.type == 200 || item.type == 201 || item.type == 202 || item.type == 203 || item.type == 3764 || item.type == 3765 || item.type == 3766 || item.type == 3767 || item.type == 3768 || item.type == 3769){
                if(prefixDmg != null){
                    tooltips.Remove(prefixDmg);
                    tooltips.Add(prefixDmg);
                }
                if(prefixSpd != null){
                    tooltips.Remove(prefixSpd);
                    tooltips.Add(prefixSpd);
                }
                if(prefixCrt != null){
                    tooltips.Remove(prefixCrt);
                    tooltips.Add(prefixCrt);
                }
                if(prefixMan != null){
                    tooltips.Remove(prefixMan);
                    tooltips.Add(prefixMan);
                }
                if(prefixSze != null){
                    tooltips.Remove(prefixSze);
                    tooltips.Add(prefixSze);
                }
                if(prefixSht != null){
                    tooltips.Remove(prefixSht);
                    tooltips.Add(prefixSht);
                }
                if(prefixKnb != null){
                    tooltips.Remove(prefixKnb);
                    tooltips.Add(prefixKnb);
                }
            }
        }
        //Extractinator thingyys

        public override void ExtractinatorUse(int extractType , ref int resultType , ref int resultStack){
            //if(ext.type == ItemID.SlushBlock){
            if(extractType == ItemID.SlushBlock){
                if(Main.rand.NextBool(18)){
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

        //MORE MELEE CHANGES
        /*public override void UpdateAccessory(Item item , Player player , bool hideVisual){
            if(item.type == ItemID.FeralClaws){
                if(hideVisual){
                    item.useTurn = true;
                }
            }
        }*/
       
        
        //WEAPON/ARMOR STAT BALANCE
        
        public override void UpdateEquip(Item item , Player player){
            if(item.type == ItemID.NecroGreaves){
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
            
            if(item.melee){
               item.autoReuse = true;

            }

            //DART AMMO TYPE
            int itemType3 = item.type;
            switch (itemType3){
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
            if(item.ammo == AmmoID.Bullet || item.ammo == AmmoID.Arrow){
                item.damage /= 2;
            }
            int itemArmor = item.type;

            //ARMOR CHANGES
            /*switch(itemArmor)
            {
                case ItemID.MythrilHood:
                    item.defense = 60;
                    break;
            }*/
            
            int itemType = item.type;
            

            switch (itemType)
            {
                
                case ItemID.TerraBlade: 
                    item.damage = 114;
                    break;
                case 190:  //Blade of Grass
                    item.damage = 52;
                    break;
                case 795:  //Blood Butcherer
                    item.damage = 40;
                    break;
                case 426: //Breaker Blade
                    item.damage = 65;
                    
                    break;
                case 274: //Dark Lance
                    item.damage = 40;
                    if(!Main.dayTime){
                        item.damage = (int)(item.damage * 1.3f);
                    }
                    break;
                case 368: //Excalibur
                    item.damage = 115;
                    break;
                case 671: //Keybrand 
                    item.damage = 125;
                    break;
                case 46: //Light's Bane
                    item.damage = 25;
                    item.useTime = 10;
                    item.useAnimation = 10;
                    item.useStyle = 3;
                    break;
                case 155: //Muramasa , incomplete
                    item.damage = 32;
                    break;
                case 273: //Night's Edge
                    item.damage = 72;
                    break;
                case ItemID.PsychoKnife: //Psycho KNife
                    item.damage = 66;
                    item.useTime = 4;
                    item.useAnimation = 4;
                    item.useStyle = 3;
                    break;
                case ItemID.Gungnir: //Gungnir
                    item.damage = 60;
                    if(Main.dayTime){
                        item.damage = (int)(item.damage * 1.15f);
                    }
                    break;
               
                


                //PHASEBLADES
                case 198:  //Blue
                    item.damage = 45;
                    break;
                case 199:  //Red
                    item.damage = 45;
                    break;
                case 200:  //Green
                    item.damage = 45;
                    break;
                case 201:  //Purple
                    item.damage = 45;
                    break;
                case 202: //White
                    item.damage = 45;
                    break;
                case 203: //Yellow
                    item.damage = 45;
                    break;
                //PHASEBLADES end
                
                 //PHASESABERS , incomplete
                case 3794: //Blue
                    item.damage = 86;
                    break;
                case 3795: //Red
                    item.damage = 86;
                    break;
                case 3796: //Green
                    item.damage = 86;
                    break;
                case 3797: //Purple
                    item.damage = 86;
                    break;
                case 3798: //White
                    item.damage = 86;
                    break;
                case 3799: //Yellow
                    item.damage = 86;
                    break;

                
                //PHASESABERS end

                case ItemID.CursedFlames:
                    item.useTime = 6;
                    item.reuseDelay = 20;
                    item.useAnimation = 18;
                    item.shootSpeed = 8.5f;
                    break;


                
            }
        }
        public override void OnHitNPC(Item item , Player player , NPC target , int damage , float knockback , bool crit)
       {
           if(Main.rand.NextBool(2) && frostGauntlet){
               target.AddBuff(BuffID.OnFire , 300);
               if(Main.rand.NextBool(2)){
               target.AddBuff(BuffID.Frostburn , 300);
               }
           }
           if(target.HasBuff(BuffType<OpenWounds>())  && target.type != NPCID.TargetDummy){
                int Heal = damage/20;
                player.statLife += Heal;
                player.HealEffect(Heal , true);
            }
            if(target.HasBuff(BuffType<Deflourished>()) && target.type != NPCID.TargetDummy){
                int Heal = damage/15;
                player.statLife += Heal;
                player.HealEffect(Heal , true);
            }
            if(item.type == ItemID.Muramasa){
                target.AddBuff(BuffType<Manipulate>() , 10000000);
            }
           
                
                

           int type = item.type;
           switch(type)
           {
                case 795:  //Blood Butcherer , Heal effect
                    int Heal = damage/5;
                    if(Main.rand.NextBool(3)  && target.type != NPCID.TargetDummy){
                         player.statLife += Heal;
                        player.HealEffect(Heal , true);
                    }
                    break;
                   

                //PHASEBLADES


                case 198: //Blue
                   if(Main.rand.NextBool(3)){
                        target.AddBuff(BuffType<Electrified>() , 360);
                    }
                    break;
                case 199: //Red
                    if(Main.rand.NextBool(3)){
                        target.AddBuff(BuffType<Electrified>() , 360);
                    }
                    break;
                case 200: //Green
                    if(Main.rand.NextBool(3)){
                        target.AddBuff(BuffType<Electrified>() , 360);
                    }
                    break;
                case 201: //Purple
                    if(Main.rand.NextBool(3)){
                        target.AddBuff(BuffType<Electrified>() , 360);
                    }
                    break;
                case 202: //White
                    if(Main.rand.NextBool(3)){
                        target.AddBuff(BuffType<Electrified>() , 360);
                    }
                    break;
                case 203: //Yellow
                    if(Main.rand.NextBool(3)){
                        target.AddBuff(BuffType<Electrified>() , 360);
                    }
                    break;

                //PHASEBLADES end

                //PHASESABERS

                case 3794:
                    if(Main.rand.NextBool(2))
                    {
                    target.AddBuff(BuffType<Electrified>() , 360); 
                    }
                    break;
                case 3795: //Red
                    if(Main.rand.NextBool(2))
                    {
                    target.AddBuff(BuffType<Electrified>() , 360); 
                    }
                    break;
                case 3796: //Green
                    if(Main.rand.NextBool(2))
                    {
                    target.AddBuff(BuffType<Electrified>() , 360); 
                    }
                    break;
                case 3797: //Purple
                    if(Main.rand.NextBool(2))
                    {
                    target.AddBuff(BuffType<Electrified>() , 360); 
                    }
                    break;
                case 3798: //White
                    if(Main.rand.NextBool(2))
                    {
                    target.AddBuff(BuffType<Electrified>() , 360); 
                    }
                    break;
                case 3799: //Yellow
                    if(Main.rand.NextBool(2))
                    {
                    target.AddBuff(BuffType<Electrified>() , 360); 
                    }
                    break;

                //PHASESABERS end


                case 368: //Excalibur
                    if(Main.rand.NextBool(2)){
                        target.AddBuff(BuffID.Confused , 300);
                    }
                    break;
                case 46: //Light's Bane
                    if(Main.rand.NextBool(5)){
                        target.AddBuff(BuffID.Confused , 300);
                    }
                    break;
                case 273: //Night's Edge
                    if(Main.rand.NextBool(5))

                    {
                    target.AddBuff(BuffType<Paralyzed>() , 60);
                    }
                    break;
                case 675: //True Night's Edge
                    if(Main.rand.NextBool(5))
                    {
                    target.AddBuff(BuffType<Paralyzed>() , 180);
                    }
                    break;
                case 674: //True Excalibur
                    target.AddBuff(BuffID.Confused , 300);  
                    break;    

           }
           
           
        }
        public override void MeleeEffects(Item item , Player player , Rectangle hitbox){
            if(frostGauntlet){
            
                Dust.NewDust(new Vector2(hitbox.X, hitbox.Y), hitbox.Width, hitbox.Height, DustID.Fire);
                 Dust.NewDust(new Vector2(hitbox.X, hitbox.Y), hitbox.Width, hitbox.Height, 60);}
    
        }
        public override void ModifyHitNPC(Item item , Player player , NPC target , ref int damage , ref float knockback , ref bool crit)
        {
             if(player.HasBuff(BuffType<Sharpshooter>()) && item.useAmmo == AmmoID.Bullet && item.ranged){
                float speed = item.shootSpeed;
                item.shootSpeed += speed * 0.15f;
            }

            int type2 = item.type;
            switch(type2){
                case 426: //Breaker Blade , 1.4 functionality
                    if (target.life >= (target.lifeMax * 0.75f))
                    {
                    damage *= 2;
                    }
                    break;
                case 671: //Keybrand , 1.4 Functionality
                    if(target.life > (int)(target.lifeMax * 0.1f))
                    {
                    damage *= (1 + 5/3 *  (1-target.life/target.lifeMax));
                    }
                    break;
                case 155: //Muramasa
                    
                    for(int i = 0; i <= 13; i++){
                        player.meleeSpeed += 0.03f * i;
                    }
                    break; 
                
            }
            //BLOOD RAGE EFFECT
            if(target.HasBuff(BuffType<FatalWounds>()) && item.melee){
            damage = (int)(damage * 1.2f);
                
            }
            
        }
            public override bool Shoot(Item item , Player player , ref Vector2 position , ref float speedX , ref float speedY , ref int type , ref int damage , ref float knockBack)
            {
               
              
                   
                    
                   
                   
                //HARDMODE REPEATERS
                if(item.type == 425 || item.type == 1187 || item.type == 481 || item.type == 578 || item.type == 436 || item.type == 1194 || item.type == 1201){
                    int ArrowCount = 0;
                    for(int i = 0; i <= ArrowCount; i++){
                         Vector2 Speed = new Vector2(speedX , speedY).RotatedByRandom(MathHelper.ToRadians(1));
                         Projectile.NewProjectile(position.X , position.Y , Speed.X , Speed.Y , type , damage , knockBack , player.whoAmI);
                    }
                    
                }
                return true;
                
            }

            //DEFINing WHAT IS AN ARMOR SET
            public override string IsArmorSet(Item head , Item body , Item legs){
                //MYTHRIL
                if(head.type == ItemID.MythrilHood && body.type == ItemID.MythrilChainmail && legs.type == ItemID.MythrilGreaves){
                    return "NovaEdge:MythrilMage";
                }
                else if(head.type == ItemID.MythrilHat && body.type == ItemID.MythrilChainmail && legs.type == ItemID.MythrilGreaves){
                    return "NovaEdge:MythrilRanged";
                }
                else if(head.type == ItemID.MythrilHelmet && body.type == ItemID.MythrilChainmail && legs.type == ItemID.MythrilGreaves){
                    return "NovaEdge:MythrilMelee";
                }
                //ADAMANTITE
                else if(head.type == ItemID.AdamantiteMask && body.type == ItemID.AdamantiteBreastplate && legs.type == ItemID.AdamantiteLeggings){
                    return "NovaEdge:AdamantiteRanged";
                }
                else if(head.type == ItemID.AdamantiteHelmet && body.type == ItemID.AdamantiteBreastplate && legs.type == ItemID.AdamantiteLeggings){
                    return "NovaEdge:AdamantiteMelee";
                }
                else if(head.type == ItemID.AdamantiteHeadgear && body.type == ItemID.AdamantiteBreastplate && legs.type == ItemID.AdamantiteLeggings){
                    return "NovaEdge:AdamantiteMage";
                }
                //COBALT
                else if(head.type == ItemID.CobaltHat && body.type == ItemID.CobaltBreastplate && legs.type == ItemID.CobaltLeggings){
                    return "NovaEdge:CobaltMage";
                }
                else if(head.type == ItemID.CobaltHelmet && body.type == ItemID.CobaltBreastplate && legs.type == ItemID.CobaltLeggings){
                    return "NovaEdge:CobaltMelee";
                }
                else if(head.type == ItemID.CobaltMask && body.type == ItemID.CobaltBreastplate && legs.type == ItemID.CobaltLeggings){
                    return "NovaEdge:CobaltRanged";
                }
                else if(head.type == ItemID.WizardHat && body.type == ItemID.AmethystRobe || body.type == ItemID.TopazRobe || body.type == ItemID.SapphireRobe || body.type == ItemID.EmeraldRobe || body.type == ItemID.RubyRobe || body.type == ItemID.DiamondRobe || body.type == ItemID.GypsyRobe)
                    return "NovaEdge:WizardRobe";
                
                return base.IsArmorSet(head , body , legs);
            }
            //CHANGES TO ARMOR SET BONUSES

            public override void UpdateArmorSet(Player player , string set){
                
                string ArmorSet = set;
                switch(ArmorSet){

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
             public override void AddRecipes(){
                ModRecipe recipe1 = new ModRecipe(mod);
                recipe1.AddIngredient(ItemID.BottledWater , 20);
                recipe1.AddIngredient(ItemID.LifeCrystal);
                recipe1.AddIngredient(ItemID.Daybloom , 20);
                recipe1.AddTile(13);
                recipe1.SetResult(ItemID.HeartreachPotion , 20 );
                recipe1.AddRecipe();

                ModRecipe recipe2 = new ModRecipe(mod);
                recipe2.AddIngredient(ItemID.BottledWater , 3);
                recipe2.AddIngredient(ItemID.Vine , 1);
                recipe2.AddIngredient(ItemID.Moonglow , 3);
                recipe2.AddTile(13);
                recipe2.SetResult(ItemID.SummoningPotion , 3);
                recipe2.AddRecipe();

                ModRecipe recipe3 = new ModRecipe(mod);
                recipe3.AddIngredient(ItemID.BottledWater);
                recipe3.AddIngredient(ItemID.MusketBall , 30);
                recipe3.AddIngredient(ItemID.Moonglow , 1);
                recipe3.AddTile(13);
                recipe3.SetResult(ItemID.AmmoReservationPotion);
                recipe3.AddRecipe();

                ModRecipe recipe4 = new ModRecipe(mod);
                recipe4.AddIngredient(ItemID.BottledWater);
                recipe4.AddIngredient(ItemID.EbonstoneBlock , 20);
                recipe4.AddIngredient(ItemID.Deathweed , 1);
                recipe4.AddTile(13);
                recipe4.SetResult(ItemID.WrathPotion);
                recipe4.AddRecipe();

                ModRecipe recipe5 = new ModRecipe(mod);
                recipe5.AddIngredient(ItemID.BottledWater);
                recipe5.AddIngredient(ItemID.CrimstoneBlock , 20);
                recipe5.AddIngredient(ItemID.Deathweed , 1);
                recipe5.AddTile(13);
                recipe5.SetResult(ItemID.RagePotion);
                recipe5.AddRecipe();

                ModRecipe recipe6 = new ModRecipe(mod);
                recipe6.AddIngredient(ItemID.BottledWater);
                recipe6.AddIngredient(ItemID.StoneBlock , 10);
                recipe6.AddRecipeGroup("NovaEdge:FerrumOre", 1);
                recipe6.AddTile(13);
                recipe6.SetResult(ItemID.EndurancePotion);
                recipe6.AddRecipe();

            }

           
        
           
            
    }
   
        
    
}