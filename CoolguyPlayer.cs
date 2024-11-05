using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.DataStructures;
using Terraria.GameInput;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
//using Fargowiltas.NPCs;
using System;
using System.Linq;
using Terraria.ModLoader.IO;
//using Fargowiltas.Projectiles;
using Fargowiltas.Items;
using Terraria.GameContent.Events;
using System.IO;
//using Fargowiltas.Common.Configs;

////using Fargowiltas.Toggler;

namespace Fargowiltas {
    public class CoolguyPlayer : ModPlayer {
        public override void PostUpdateBuffs() {
            if (true /*GetInstance<FargoServerConfig>().UnlimitedPotionBuffsOn120*/) {
                foreach (Item item in Player.bank.item) {
                    CoolguyGlobalItem.TryUnlimBuff(item, Player);
                }

                foreach (Item item in Player.bank2.item) {
                    CoolguyGlobalItem.TryUnlimBuff(item, Player);
                }
            }
        }
    }
}
