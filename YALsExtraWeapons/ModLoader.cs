using Dawnsbury.Core;
using Dawnsbury.Core.Mechanics.Enumerations;
using Dawnsbury.Core.Mechanics.Treasure;
using Dawnsbury.Display.Illustrations;
using Dawnsbury.Modding;

namespace YALsExtraWeapons;

public class ModLoader {
	public static Dictionary<string, Trait> WeaponTraits = new();
	[DawnsburyDaysModMainMethod]
	public static void LoadMod() {
		static void addWeapon(string name, Func<ItemName, string, Trait, Item> factory, string[] description) {
			var trait = ModManager.RegisterTrait(name,
				new TraitProperties(name, true, string.Join(' ', description), relevantForShortBlock: false)
			);
			WeaponTraits.Add(name, trait);
			var id = name.ToLower();
			ModManager.RegisterNewItemIntoTheShop(name, (itemName) => factory(itemName, id, trait));
		}
		static void addSimpleWeapon(string name, Illustration icon, Trait[] traits, Func<Item, Item> proc, string[] description, int price = 0, int level = 0) {
			addWeapon(name, (name, id, mainTrait) => {
				return proc(
					new Item(name, icon, id, level, price, traits)
					.WithMainTrait(mainTrait)
				);
			}, description);
		}
		// aside: the weapons here are ordered alphabetically

		// a d8 thrown weapon! Ranged only tho
		addSimpleWeapon("Bec de Corbin", new ModdedIllustration("YALsExtraWeapons/chakram.png"), [
			Trait.Shove,
			Trait.Razing,
			Trait.Concussive,
			Trait.Reach,
			Trait.Polearm,
			Trait.Martial,
		], item => (item
			.WithWeaponProperties(
				new WeaponProperties("1d8", DamageKind.Piercing)
			)
		), [
			"Simple, elegant, and portable, the chakram is an open-centered metal discus with a sharpened edge,",
			"as well as a grip running along the center so the wielder can hold it safely.",
		]);

		// throwable in a case of an emergency
		addSimpleWeapon("Light Hammer", IllustrationName.Greatpick, [
			Trait.Agile,
			Trait.Thrown20Feet,
			Trait.Martial,
			Trait.Hammer,
		], item => (item
			.WithWeaponProperties(
				new WeaponProperties("1d6", DamageKind.Bludgeoning)
			)
		), [
			"This smaller version of the warhammer has a wooden or metal shaft ending in a metal head.",
			"Unlike its heavier cousin, it is light enough to throw."
		]);

		// Big Sickles
		addSimpleWeapon("Lion Scythe", IllustrationName.Sickle, [
			Trait.Agile,
			Trait.Finesse,
			Trait.Trip,
			Trait.Martial,
			Trait.Knife,
		], item => (item
			.WithWeaponProperties(
				new WeaponProperties("1d6", DamageKind.Slashing)
			)
		), [
			"A lion scythe resembles a common sickle but is specially weighted to allow for greater power when attacking."
		], 1);

		// for spring-loaded uppercuts
		addSimpleWeapon("Pantograph Gauntlet", IllustrationName.BarbariansGloves, [
			Trait.DeadlyD6,
			Trait.MonkWeapon,
			Trait.Reach,
			Trait.Shove,
			Trait.Martial,
			Trait.Brawling,
		], item => (item
			.WithWeaponProperties(
				new WeaponProperties("1d4", DamageKind.Bludgeoning)
			)
		), [
			"A pantograph gauntlet is a heavy, fist-like weight, mounted on an extendable frame and attached to your outer arm with a series of leather straps."
		], 2);

		// for vibes, but also one of the nicer L-bulk bludgeoning weapons..?
		addSimpleWeapon("Probing Cane", IllustrationName.Quarterstaff, [
			Trait.Finesse,
			Trait.Sweep,
			Trait.Martial,
			Trait.Club,
		], item => (item
			.WithWeaponProperties(new WeaponProperties("1d6", DamageKind.Bludgeoning))
		), [
			"Probing canes are made from reinforced wood with the same strengthening process and treatment as a longbow,",
			"creating a cane that is both high quality and durable enough for an adventuring owner to use as a weapon."
		]);

		// how's this not in baseline
		addSimpleWeapon("Throwing Knife", IllustrationName.Dagger, [
			Trait.Agile,
			Trait.Finesse,
			Trait.Thrown20Feet,
			Trait.Simple,
			Trait.Knife,
			Trait.Dagger, // close enough to pretend to be a dagger..?
			Trait.WizardWeapon,
		], item => (item
			.WithWeaponProperties(new WeaponProperties("1d4", DamageKind.Piercing))
		), [
			"This light knife is optimally balanced to be thrown accurately at a greater distance than a common dagger.",
			"While this comes at the cost of a significant cutting edge, the difference is worth it for throwing specialists."
		]);
	}
}
