using EBToolkit.Game;
using EBToolkit.Game.Inventory;
using System;

namespace EBToolkit.SaveEditor
{
	public class EarthboundSave
	{
		/// <summary>
		/// Offset for ZSNES save states
		/// </summary>
		public const int ZSNESFileStart = 0xA3E8;
		// Location where Escargo Express data is kept.
		public const int EscargoExpressDataOffset = 0x76;
		// Flags
		public const int FlagOffset = 0x433;
		public const int FlagLength = 0xCD;
		
		//TODO: Maybe Mother 2 support sometime?
		/// <summary>
		/// The player's name. This is set in EarthBound when Tony calls Jeff
		/// and asks for the player name and then when the Tenda tribe leader
		/// asks for the players name again.
		/// </summary>
		/// <remarks>This is limited in-game to 24 characters.</remarks>
		public string PlayerName;
		/// <summary>
		/// The pet's name. Used only at the start of the game and in the credits. 
		/// This is set on file creation.
		/// </summary>
		/// <remarks>
		/// Limited to six characters.
		/// </remarks>
		public string PetName;
		/// <summary>
		/// Ness' favorite <sub>homemade</sub> food. His mother will give the
		/// party it when they return home, restoring them to full health. If Ness
		/// is homesick, he may waste turns craving it. In EarthBound, this is
		/// set on file creation.
		/// </summary>
		/// <remarks>
		/// Limited to six characters.
		/// Also there is a guy in Moonside who hates everything about it... :O
		/// </remarks>
		public string FavoriteFood;
		/// <summary>
		/// Ness' favorite thing, which is used for the name of the PSI attack
		/// that Ness, Ness' Nightmare, and Giygas can use.
		/// </summary>
		/// <remarks>
		/// When saving to a file, the file must also include the "PSI " string and
		/// a trailing space.
		/// </remarks>
		public string FavoriteThing;
		/// <summary>
		/// Money on hand.
		/// </summary>
		public uint Money;
		/// <summary>
		/// Money in the ATM. May crash the game if over $9,999,999 (0x98967F).
		/// </summary>
		public uint ATM;
		/// <summary>
		/// Storage for Escargo Express
		/// </summary>
		public EscargoExpressInventory EscargoExpress;
		/// <summary>
		/// The location that the party is in.
		/// </summary>
		public Point Location;
		/// <summary>
		/// The location that the exit mouse will go towards when used.
		/// </summary>
		public Point ExitMouseLocation;
		//TODO: Verify.
		/// <summary>
		/// Timer for Ness' dad to call (I believe).
		/// </summary>
		public uint Timer;
	}
}
