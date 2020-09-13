using Terraria;
using Terraria.ModLoader;


namespace NovaEdge.Dusts
{

    public class CursedDust : ModDust //USELESS FOR NOW
    {
        public override void OnSpawn(Dust dust)
        {
            dust.noGravity = true;
            dust.noLight = false;
            dust.scale = 0.8f;
        }
        public override bool Update(Dust dust)
        {
            dust.position += dust.velocity;
            dust.rotation += dust.velocity.X;
            dust.scale -= 0.05f;
            if(dust.scale < 0.5f)
            {
                dust.active = false;
            }
            return false;


        }
    }
}
