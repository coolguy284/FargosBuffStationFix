using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
//using Fargowiltas.NPCs;
//using Fargowiltas.Items.Ammos.Rockets;
using System.Text.RegularExpressions;
using System.Linq;
using Terraria.GameContent.ItemDropRules;
//using Fargowiltas.Common.Configs;
//using Fargowiltas.Items.Ammos.Coins;

namespace Fargowiltas.Items
{
    public class CoolguyGlobalItem : GlobalItem
    {
        public override bool InstancePerEntity => true;

        public override GlobalItem Clone(Item item, Item itemClone)
        {
            return base.Clone(item, itemClone);
        }

        //public override bool CloneNewInstances => true;

        //MIGHTNEEDED-TooltipLine FountainTooltip(string biome) => new TooltipLine(Mod, "Tooltip0", $"[i:909] [c/AAAAAA:Forces surrounding biome state to {biome} upon activation]");
        
        static int[] Informational = { ItemID.DPSMeter, ItemID.CopperWatch, ItemID.TinWatch, ItemID.TungstenWatch, ItemID.SilverWatch, ItemID.GoldWatch, ItemID.PlatinumWatch, ItemID.DepthMeter, ItemID.Compass, ItemID.Radar, ItemID.LifeformAnalyzer, ItemID.TallyCounter, ItemID.MetalDetector, ItemID.Stopwatch, ItemID.Ruler, ItemID.FishermansGuide, ItemID.Sextant, ItemID.WeatherRadio, ItemID.GPS, ItemID.REK, ItemID.GoblinTech, ItemID.FishFinder, ItemID.PDA, ItemID.CellPhone };
        static int[] Construction = { ItemID.Toolbelt, ItemID.Toolbox, ItemID.ExtendoGrip, ItemID.PaintSprayer, ItemID.BrickLayer, ItemID.PortableCementMixer, ItemID.ActuationAccessory, ItemID.ArchitectGizmoPack };
        /*MIGHTNEEDED-public static void TryPiggyBankAcc(Item item, Player player)
        {
            if (item.IsAir || item.maxStack > 1 || !GetInstance<FargoServerConfig>().PiggyBankAcc)
                return;

            if (Informational.Contains(item.type))
            {
                player.RefreshInfoAccsFromItemType(item);
            }
            else if (Construction.Contains(item.type))
            {
                player.ApplyEquipFunctional(item, true);
            }
        }*/

        public override void ModifyTooltips(Item item, List<TooltipLine> tooltips)
        {
            //var fargoServerConfig = GetInstance<FargoServerConfig>();

            if (true /* && GetInstance<FargoClientConfig>().ExpandedTooltips*/)
            {
                TooltipLine line;

                if (/*fargoServerConfig.UnlimitedPotionBuffsOn120 && */item.maxStack > 1)
                {
                    if (item.type == ItemID.SharpeningStation
                            || item.type == ItemID.AmmoBox
                            || item.type == ItemID.CrystalBall
                            || item.type == ItemID.BewitchingTable
                            || item.type == ItemID.SliceOfCake)
                    {
                        line = new TooltipLine(Mod, "TooltipUnlim", "[i:87] [c/AAAAAA:Unlimited buff at 3 stack in inventory, Piggy Bank, or Safe]");
                        tooltips.Add(line);
                    }
                }

                if (true /* && fargoServerConfig.PiggyBankAcc*/)
                {
                    if (Informational.Contains(item.type) || Construction.Contains(item.type))
                    {
                        line = new TooltipLine(Mod, "TooltipUnlim", "[i:87] [c/AAAAAA:Works from Piggy Bank and Safe]");
                        tooltips.Add(line);
                    }
                }
            }
        }

        public override void UpdateInventory(Item item, Player player)
        {
            TryUnlimBuff(item, player);
        }
        
        public static void TryUnlimBuff(Item item, Player player)
        {
            if (item.IsAir/* || !GetInstance<FargoServerConfig>().UnlimitedPotionBuffsOn120*/)
                return;

            if (item.stack >= 3)
            {
                if (item.type == ItemID.SharpeningStation)
                    player.AddBuff(BuffID.Sharpened, 2);
                else if (item.type == ItemID.AmmoBox)
                    player.AddBuff(BuffID.AmmoBox, 2);
                else if (item.type == ItemID.CrystalBall)
                    player.AddBuff(BuffID.Clairvoyance, 2);
                else if (item.type == ItemID.BewitchingTable)
                    player.AddBuff(BuffID.Bewitched, 2);
                else if (item.type == ItemID.SliceOfCake)
                    player.AddBuff(BuffID.SugarRush, 2);
            }
        }
    }
}