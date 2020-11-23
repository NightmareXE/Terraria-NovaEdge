using Terraria.ModLoader;
using Terraria;
using Microsoft.Xna.Framework;
using Terraria.ID;
using Terraria.Localization;
using Terraria.GameContent.UI;
using ReLogic.Graphics;
using Terraria.UI;
using NovaEdge.UI;
using System.Collections.Generic;

namespace NovaEdge
{
	public class Edge : Mod
	{
        private UserInterface _bloodlustBarUI;

        internal BloodlustBar BloodlustBar;

		 public override void AddRecipeGroups(){
                RecipeGroup group = new RecipeGroup(() => Language.GetTextValue("LegacyMisc.37") + " Iron Ore" , new int[]{
                  
                    ItemID.IronOre,
                    ItemID.LeadOre
                }
                );
                RecipeGroup.RegisterGroup("NovaEdge:FerrumOre" , group);
          }
        public override void Load()
        {
            if (!Main.dedServ)
            {
                BloodlustBar = new BloodlustBar();
                _bloodlustBarUI = new UserInterface();
                _bloodlustBarUI.SetState(BloodlustBar);
            }
            Main.itemTexture[ItemID.BloodyMachete] = GetTexture("Resprites/BloodyMachete_Item");
            Item bloodMachete = new Item();
            bloodMachete.SetDefaults(ItemID.BloodyMachete);

            Main.projectileTexture[ProjectileID.BloodyMachete] = GetTexture("Resprites/BloodyMachete_Item");
            Projectile bloodMacheteProj = new Projectile();
            bloodMacheteProj.SetDefaults(ProjectileID.BloodyMachete);


        }
        public override void UpdateUI(GameTime gameTime)
        {
            _bloodlustBarUI?.Update(gameTime);
        }
        public override void ModifyInterfaceLayers(List<GameInterfaceLayer> layers)
        {
            int bloodlustBarIndex = layers.FindIndex(layer => layer.Name.Equals("Vanilla: Resource Bars"));
            if(bloodlustBarIndex != -1)
            {
                layers.Insert(bloodlustBarIndex, new LegacyGameInterfaceLayer("NovaEdge: Bloodlust Bar", delegate
              {
                  _bloodlustBarUI.Draw(Main.spriteBatch, new GameTime());
                  return true;
              },
                InterfaceScaleType.UI)
                );
                
            }
        }

    }

    
}
