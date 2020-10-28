using Terraria;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria.ModLoader;

namespace NovaEdge.Items.AssassinClass{
    public class AssassinPlayer : ModPlayer{
        public static AssassinPlayer ModPlayer(Player player){
            return player.GetModPlayer<AssassinPlayer>();
        }
        public float assassinDamageAdd;
        public float assassinDamageMult = 1f;
        public float assassinKnockback;
        public int assassinCrit;

        //Bloodlust Vars

        public int bloodlustCurrent;
        public int defaultBloodlustMax = 1000;
        public float bloodlustRegenRate;
        public float bloodlustLossTimer;
        public static readonly Color RegenBloodlust = new Color(187, 20, 20);
        public bool FullBloodLust;
        public bool Hit;
        public int bloodlustGain;

       
 
        public override void ResetEffects(){
            ResetVariables();
        }
        public override void UpdateDead(){
            ResetVariables();
            bloodlustCurrent = 0;
        }
        private void ResetVariables(){
            assassinDamageAdd = 0f;
            assassinDamageMult = 1f;
            assassinKnockback = 0f;
            assassinCrit = 0;
            
        }
        public override void OnHitNPC(Item item, NPC target, int damage, float knockback, bool crit)
        {
            timer = 0;
            bloodlustGain = damage / 10;
            if(bloodlustGain > 20)
            {
                bloodlustGain = 20;
            }
            bloodlustCurrent += bloodlustGain;
        }
        int timer = 0;
        int timerCoolDown = 0;
        public bool cooldown;
        public override void PostUpdate()
        {


            //Hit check
            timer++;
            if(timer > 120)
            {
                bloodlustCurrent--;
            }
            if (FullBloodLust && !cooldown)
            {
                player.AddBuff(ModContent.BuffType<Buffs.Berserk>() , 180);
                cooldown = true;
            }
            if (cooldown)
            {
                timerCoolDown++;
            }
            
            if(timerCoolDown > 600)
            {
                cooldown = false;
                timerCoolDown = 0;
            }



            //Hit check END
            if(bloodlustCurrent > 150)
            {
                player.endurance += 0.12f;
            }

            if(bloodlustCurrent > 350)
            {
                player.allDamage += 0.08f;
            }

            if(bloodlustCurrent > 550)
            {
                player.meleeSpeed += 0.15f;
           
            }

            if(bloodlustCurrent > 750)
            {
                player.meleeCrit += 6;
            }

            if(bloodlustCurrent >= defaultBloodlustMax)
            {
                FullBloodLust = true;
            }

        }
        public override void PostUpdateMiscEffects()
        {
            UpdateBloodLust();
        }
        private void UpdateBloodLust()
        {
            
            
            //Hit = false;
            //bloodlustLossTimer++;
            if(bloodlustCurrent < defaultBloodlustMax)
            {
                FullBloodLust = false;
            }
            else
            {
                FullBloodLust = true;
            }
            /*if(bloodlustLossTimer > 120 && !Hit)
            {
                bloodlustCurrent--;
            }
            else if (Hit)
            {
                bloodlustLossTimer
            }

            //if (Hit)
            //{
            //    bloodlustLossTimer = 0;
            //}*/

            
            bloodlustCurrent = Utils.Clamp(bloodlustCurrent, 0, defaultBloodlustMax);
        }
        
        

    }
}