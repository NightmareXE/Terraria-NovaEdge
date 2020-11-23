using Terraria;
using Terraria.ID;
using Terraria.UI;
using Terraria.GameContent.UI.Elements;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using static Terraria.ModLoader.ModContent;
using NovaEdge.Items.AssassinClass;

namespace NovaEdge.UI
{
    internal class BloodlustBar : UIState
    {
        private UIText text;
        private UIImage barFrame;
        private UIElement area;
        private Color Gradient1;
        private Color Gradient2;

        public override void OnInitialize()
        {
            area = new UIElement();
            area.Left.Set(-area.Width.Pixels - 600, 1f);
            area.Top.Set(30, 0);
            area.Width.Set(182, 0f);
            area.Height.Set(60, 0);


            barFrame = new UIImage(GetTexture("NovaEdge/UI/BloodlustBar"));
            barFrame.Top.Set(0f, 0f);
            barFrame.Width.Set(138, 0f);
            barFrame.Height.Set(34, 0f);
            barFrame.Left.Set(22, 0f);



            text = new UIText("0/0", 0.8f);
            text.Width.Set(138, 0f);
            text.Height.Set(34, 0f);
            text.Top.Set(40, 0f);
            text.Left.Set(0, 0f);

            Gradient1 = new Color(220, 20, 60);
            Gradient2 = new Color(220, 34, 34);

            area.Append(text);
            area.Append(barFrame);
            Append(area);



        }
        public override void Draw(SpriteBatch spriteBatch)
        {
            base.Draw(spriteBatch);
        }

        protected override void DrawSelf(SpriteBatch spriteBatch)
        {
            base.DrawSelf(spriteBatch);
            var ModPlayer = Main.LocalPlayer.GetModPlayer<Items.AssassinClass.AssassinPlayer>();

            float quotient = (float)ModPlayer.bloodlustCurrent / ModPlayer.defaultBloodlustMax;
            quotient = Utils.Clamp(quotient, 0f, 1f);


            Rectangle hitbox = barFrame.GetInnerDimensions().ToRectangle();
            hitbox.X += 12;
            hitbox.Width -= 24;
            hitbox.Y += 8;
            hitbox.Height -= 16;

            int left = hitbox.Left;
            int right = hitbox.Right;
            int step = (int)((right - left) * quotient);
            for(int i = 0; i < step; i++)
            {
                float percent = (float)i / (right - left);
                spriteBatch.Draw(Main.magicPixel, new Rectangle(left + i, hitbox.Y, 1, hitbox.Height), Color.Lerp(Gradient1, Gradient2, percent));

            }

         
        }
        public override void Update(GameTime gameTime)
        {
            var ModPlayer = Main.LocalPlayer.GetModPlayer<Items.AssassinClass.AssassinPlayer>();
            text.SetText($"Bloodlust: {ModPlayer.bloodlustCurrent} / {ModPlayer.defaultBloodlustMax}");
            base.Update(gameTime);
        }
    }
}