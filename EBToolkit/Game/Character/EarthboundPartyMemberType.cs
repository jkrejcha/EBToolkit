using EBToolkit.SaveEditor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EBToolkit.Game.Character
{
	/// <summary>
	/// An enum value representing the party members that can exist in
	/// EarthBound.
	/// </summary>
	public enum EarthboundPartyMemberType : byte
	{
		/// <summary>
		/// Represents... no one *spooky sound effect*
		/// </summary>
		None = 0,
		/// <summary>
		/// Represents <a href="https://wikibound.info/wiki/Ness">Ness</a>,
		/// the main leader of the chosen four. He can use psychic powers that
		/// have the ability to inflict status effects, heal teammates, and an
		/// attack that can affect all enemies (PSI <see cref="EarthboundSave.FavoriteThing"/>).
		/// </summary>
		Ness = 1,
		/// <summary>
		/// Represents <a href="https://wikibound.info/wiki/Paula">Paula</a>,
		/// the second of the chosen four. She can use psychic powers that have
		/// the ability to freeze enemies, burn them, and inflict large amount of
		/// damage. Required for the final battle, she has a few unique abilities
		/// such as the <a hef="https://wikibound.info/wiki/Pray">Pray</a> command.
		/// </summary>
		Paula = 2,
		/// <summary>
		/// Represents <a href="https://wikibound.info/wiki/Jeff">Jeff</a>, the
		/// third member of the chosen four. While he cannot use PSI, he can use
		/// an assortment of weapons no one else can, with his signature weapon
		/// being <see cref="Inventory.Item.BottleRocket">bottle rockets</see>.
		/// </summary>
		Jeff = 3,
		/// <summary>
		/// Represents <a href="https://wikibound.info/wiki/Poo">Poo</a>, the
		/// fourth member of the chosen four. A martial arts master, he can use
		/// PSI to freeze and burn enemies, and inflict large amounts of damage
		/// to all enemies with PSI Starstorm. He also has the ability to use
		/// the <a href="https://wikibound.info/wiki/Mirror">Mirror</a> ability,
		/// which allows him to copy an enemy in battle.
		/// </summary>
		Poo = 4,
		/// <summary>
		/// Represents <a href="https://wikibound.info/wiki/Porky_Minch#In_EarthBound">Pokey</a>
		/// as a NPC at the start of the game. This is not the enemy seen at
		/// the end of the game. All turns he takes are wasted.
		/// </summary>
		Pokey = 5,
		/// <summary>
		/// Represnets <a href="https://wikibound.info/wiki/Picky">Picky</a> as
		/// a NPC at the start of the game. He does a little help in battle, and
		/// he also chants a magic spell (which does nothing).
		/// </summary>
		Picky = 6,
		/// <summary>
		/// Represnets <a href="https://wikibound.info/wiki/King">King</a> as a
		/// NPC at the start of the game. He does a little help in battle, as he
		/// has two high-level attacks and one low-level attack, although he may
		/// waste turns barking.
		/// </summary>
		King = 7,
		/// <summary>
		/// Represnets <a href="https://wikibound.info/wiki/Tony">Tony</a> as a
		/// NPC during the time that <see cref="Jeff"/> is going to escape the
		/// boarding school. While never normally able to be used in battle, he
		/// has three (low-level) attacks, although occasionally skips turns.
		/// </summary>
		Tony = 8,
		/// <summary>
		/// Represents the <a href="https://wikibound.info/wiki/Bubble_Monkey">Bubble Monkey</a>
		/// as a NPC during the time that <see cref="Jeff"/> is in Winters.
		/// Attacks are similar to the ones of <see cref="Tony"/>.
		/// </summary>
		BubbleMonkey = 9,
		/// <summary>
		/// Represnets <a href="https://wikibound.info/wiki/Dungeon_Man">Dungeon Man</a>
		/// as a NPC during the brief period in Scaraba after the temple. While
		/// his attacks are considered low-level, his <see cref="EarthboundCharacter.Offense"/>
		/// is high. Dungeon Man also has an attack that immobilizes the target.
		/// </summary>
		DungeonMan = 10,
		/// <summary>
		/// Represents a <a href="https://wikibound.info/wiki/Flying_Man">Flying Man</a>,
		/// available during the <a href="https://wikibound.info/wiki/Magicant">Magicant</a>
		/// portion of the game.
		/// </summary>
		FlyingMan1 = 11,
		/// <inheritdoc cref="FlyingMan1"/>
		FlyingMan2 = 12,
		/// <inheritdoc cref="FlyingMan1"/>
		FlyingMan3 = 13,
		/// <inheritdoc cref="FlyingMan1"/>
		FlyingMan4 = 14,
		/// <inheritdoc cref="FlyingMan1"/>
		FlyingMan5 = 15,
		/// <summary>
		/// Represents a <a href="https://wikibound.info/wiki/List_of_battle_items_in_EarthBound#Teddy_bears">Teddy Snuggle Wuggle</a>,
		/// which is an item that absorbs damage.
		/// </summary>
		/// <seealso cref="Inventory.Item.TeddyBear"/>
		TeddyBear = 16,
		/// <summary>
		/// Represents a version of <see cref="TeddyBear"/> which has more
		/// <see cref="EarthboundCharacter.HP"/> and
		/// <see cref="EarthboundCharacter.Defense"/>.
		/// </summary>
		/// <seealso cref="Inventory.Item.SuperPlushBear"/>
		SuperPlushBear = 17,
	}

	/// <summary>
	/// A <see langword="static"/> class that provides extensions to the
	/// <see cref="EarthboundPartyMemberType"/> enum.
	/// </summary>
	public static class EarthboundPartyMemberTypeExtensions
	{
		/// <summary>
		/// A constant that defines the highest value of the "playable characters"
		/// in EarthBound.
		/// </summary>
		public const byte PlayableCharacterNumberMaximum = 4;
		/// <summary>
		/// Whether this <see cref="EarthboundPartyMemberType"/> is considered a
		/// playable character.
		/// </summary>
		/// <param name="self">The <see cref="EarthboundPartyMemberType"/> to test</param>
		/// <returns>
		/// A <see cref="bool"/> value that defines whether this
		/// <see cref="EarthboundPartyMemberType"/> is playable
		/// </returns>
		public static bool IsPlayable(this EarthboundPartyMemberType self)
		{
			if (self == EarthboundPartyMemberType.None) return false;
			return ((byte)self) < PlayableCharacterNumberMaximum;
		}
	}
}
