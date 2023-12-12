using Terraria;
using Terraria.ModLoader;

namespace SiameseCatAzukiSan.Buffs
{
	public class EbiMount : ModBuff
	{
		public override void SetDefaults() {
			DisplayName.SetDefault("Ebi");
			Description.SetDefault("No fishy smell, but it smells a bit like catnip.");
			Main.buffNoTimeDisplay[Type] = true;
			Main.buffNoSave[Type] = true;
		}

		public override void Update(Player player, ref int buffIndex) {
			player.mount.SetMount(ModContent.MountType<Mounts.Ebi>(), player);
			player.buffTime[buffIndex] = 10;
		}
	}
}
