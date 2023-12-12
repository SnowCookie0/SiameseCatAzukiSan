using SiameseCatAzukiSan.Items;
using Terraria;
using Terraria.ModLoader;

namespace SiameseCatAzukiSan.Prefixes
{
	public class NyaPrefix : ModPrefix
	{
		private readonly byte _power;

		// see documentation for vanilla weights and more information
		// note: a weight of 0f can still be rolled. see CanRoll to exclude prefixes.
		// note: if you use PrefixCategory.Custom, actually use ChoosePrefix instead, see ExampleInstancedGlobalItem
		public override float RollChance(Item item)
			=> 5f;

		// determines if it can roll at all.
		// use this to control if a prefixes can be rolled or not
		public override bool CanRoll(Item item)
			=> true;

		// change your category this way, defaults to Custom
		public override PrefixCategory Category
			=> PrefixCategory.AnyWeapon;

		public NyaPrefix() {
		}

		public NyaPrefix(byte power) {
			_power = power;
		}

		// Allow multiple prefix autoloading this way (permutations of the same prefix)
		public override bool Autoload(ref string name) {
			if (!base.Autoload(ref name)) {
				return false;
			}

			mod.AddPrefix("Nya", new NyaPrefix(1));
			mod.AddPrefix("NyaNya", new NyaPrefix(2));
			return false;
		}

		public override void Apply(Item item) 
			=> item.GetGlobalItem<ExampleInstancedGlobalItem>().nya = _power;

		public override void ModifyValue(ref float valueMult) {
			float multiplier = 1f + 0.05f * _power;
			valueMult *= multiplier;
		}
	}
}