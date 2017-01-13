using EBToolkit.Game;
using EBToolkit.Game.Character;
using EBToolkit.Game.Inventory;
using EBToolkit.Game.Text;
using System;
using System.IO;

namespace EBToolkit.SaveEditor
{
	public class EarthboundSave : EarthboundSaveable
	{
		/// <summary>
		/// The amount of event flags in EarthBound.
		/// </summary>
		public const int EventFlagSize = 1640;
		/// <summary>
		/// The maximum amount of characters used in the names for the
		/// <see cref="PetName"/>, <see cref="FavoriteFood"/>, and <see cref="FavoriteThing"/>
		/// </summary>
		/// <seealso cref="PetName"/>
		/// <seealso cref="FavoriteFood"/>
		/// <seealso cref="FavoriteThing"/>
		public const int NameSize = 6;
		/// <summary>
		/// The amount of controllable party members
		/// </summary>
		public const int PartySize = 4;
		/// <summary>
		/// The maximum amount of characters in the player's name (<see cref="PlayerName"/>)
		/// </summary>
		/// <seealso cref="PlayerName"/>
		public const int PlayerNameSize = 24;
		/// <summary>
		/// Where Escargo Express data is being kept in the save file
		/// </summary>
		[Obsolete("A BinaryWriter is being used here instead")]
		public const int EscargoExpressDataOffset = 0x76;
		public const int SaveLength = 0x27E; // I think...
		// Flags
		[Obsolete("A BinaryWriter is being used instead")]
		public const int FlagOffset = 0x433;
		
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
		/// <summary>
		/// The speed at which in-game text scrolls.
		/// </summary>
		public TextSpeed TextSpeed;
		/// <summary>
		/// Whether Stereo or Mono sound should be used.
		/// </summary>
		public SoundSetting SoundSetting;
		/// <summary>
		/// The appearance of text windows when all party members are alive
		/// </summary>
		public WindowFlavor WindowFlavor;
		/// <summary>
		/// Party members
		/// </summary>
		public readonly EarthboundParty Party = new EarthboundParty();
		/// <summary>
		/// Event flags, used for triggering various events and actions within the game
		/// </summary>
		public readonly bool[] EventFlags = new bool[EventFlagSize];

		public void WriteDataToStream(BinaryWriter Writer)
		{
			EarthboundPlainTextEncoding PlainTextEncoding = new EarthboundPlainTextEncoding();
			Writer.Seek(0x2C, SeekOrigin.Current);
			//TODO: Document whether there is any data here that can modified.
			Writer.Write(PlainTextEncoding.GetBytesPadded(PlayerName, PlayerNameSize));
			//Writer.Seek(0x44, SeekOrigin.Begin); // Offset 0x44 for the pet name. should change this later
			Writer.Write(PlainTextEncoding.GetBytesPadded(PetName, NameSize));
			Writer.Write(PlainTextEncoding.GetBytesPadded(FavoriteFood, NameSize));
			Writer.Seek(0x04, SeekOrigin.Current); 
			//There's a difference of 4 bytes between the favorite food and favorite thing
			//TODO: Document whether there is any data here that can be modified.
			Writer.Write(PlainTextEncoding.GetBytesPadded(FavoriteThing + " ", NameSize + 1));
			Writer.Write(Money);
			Writer.Write(ATM);
			Writer.Seek(0x13, SeekOrigin.Current); // please seek 0x13 for more stuffs
			EscargoExpress.WriteDataToStream(Writer);
			Location.WriteDataToStream(Writer);
			//TODO: Write the party member count and order here
			ExitMouseLocation.WriteDataToStream(Writer);
			Writer.Write((byte)TextSpeed);
			Writer.Write((byte)SoundSetting);
			Writer.Write(Timer);
			Writer.Write((byte)WindowFlavor);
			Party.WriteDataToStream(Writer);
			for (int eventFlagIndex = 0; eventFlagIndex < EventFlagSize; eventFlagIndex++)
			{
				byte eventFlagByte = 0;
				for (int bit = 0; bit < 8; bit++)
				{
					eventFlagByte += (byte)((EventFlags[eventFlagIndex++] ? 1 : 0) << bit);
				}
				Writer.Write(eventFlagByte);
			}
			throw new NotImplementedException("Party number and party order not implemented");
		}
	}

	/// <summary>
	/// An enum value representing the speed at which text flows in the in-game
	/// dialogue and text.
	/// </summary>
	public enum TextSpeed : byte
	{
		/// <summary>
		/// Fast text speed (2 frames per character).
		/// </summary>
		Fast = 1,
		/// <summary>
		/// Medium text speed.
		/// </summary>
		Medium = 2,
		/// <summary>
		/// Slow text speed. In battle, this requires the player to press the A
		/// button in some circumstances.
		/// </summary>
		Slow = 3,
	}

	/// <summary>
	/// An enum value representing how sound is played
	/// </summary>
	public enum SoundSetting : byte
	{
		/// <summary>
		/// Stereo (two-channels) sound is used. 
		/// </summary>
		Stereo = 1,
		/// <summary>
		/// Mono (one-channel) sound is used
		/// </summary>
		Mono = 2,
	}

	/// <summary>
	/// An enum value represneting the style of text windows
	/// </summary>
	public enum WindowFlavor : byte
	{
		/// <summary>
		/// Standard window with a black background in text windows and blue in
		/// the HP and PP windows.
		/// </summary>
		Plain = 1,
		Mint = 2,
		Strawberry = 3,
		Banana = 4,
		Peanut = 5,
	}
}
