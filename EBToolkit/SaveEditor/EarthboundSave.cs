using EBToolkit.Game;
using EBToolkit.Game.Character;
using EBToolkit.Game.Inventory;
using EBToolkit.Game.Text;
using System;
using System.IO;

namespace EBToolkit.SaveEditor
{
	/// <summary>
	/// A save file for the game EarthBound which contains data such as the
	/// favorite thing, food, names, event flags, characters, and other data
	/// needed for the game to work
	/// </summary>
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
		/// The maximum amount of characters in the player's Japanese name in
		/// Mother 2.
		/// </summary>
		/// <remarks>
		/// This constant is still relevant in EarthBound because the first
		/// twelve characters of a player's name (spaces replaced with K), are
		/// saved in EarthBound as well.
		/// </remarks>
		public const int JapanesePlayerNameSize = 12;
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
		/// <summary>
		/// The size of the save file in bytes.
		/// </summary>
		public const int SaveLength = 0x500; // I think...
		/// <summary>
		/// The offset in the save where flags are being stored
		/// </summary>
		[Obsolete("A BinaryWriter is being used instead")]
		public const int FlagOffset = 0x433;
		
		//TODO: Decide whether this should be part of the "save" class or the
		//save file one.
		/// <summary>
		/// The magic string that denotes this is an EarthBound save file.
		/// </summary>
		public const String MagicString = "HAL Laboratory, inc.";

		/// <summary>
		/// The prefix used for PSI <see cref="FavoriteThing"/>. This is what
		/// is used to determine the existance of a save file.
		/// </summary>
		public const String PSIPrefix = "PSI ";
		
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
		/// Whether PSI powers have been learned.
		/// </summary>
		/// <remarks>
		/// Not sure if it affects anything. It might affect whether the "PSI"
		/// option is available in the menu.
		/// </remarks>
		public bool PSILearned;
		/// <summary>
		/// Storage for Escargo Express
		/// </summary>
		public EscargoExpressInventory EscargoExpress;
		/// <summary>
		/// The location that the party is in.
		/// </summary>
		public Point Location;
		/// <summary>
		/// The location that the exit mouse will teleport the party to when
		/// used in a location that supports it.
		/// </summary>
		public Point ExitMouseLocation;
		//TODO: Verify.
		/// <summary>
		/// In-game timer of some sort
		/// </summary>
		public uint Timer;
		/// <summary>
		/// The speed at which in-game text scrolls.
		/// </summary>
		public TextSpeed TextSpeed;
		/// <summary>
		/// Whether <see cref="SoundSetting.Stereo"/> or 
		/// <see cref="SoundSetting.Mono"/> sound should be used.
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

		/// <inheritdoc/>
		public void WriteDataToStream(BinaryWriter Writer)
		{
			//TODO: Refactor and verify places in save file
			WriteText(Writer);
			Writer.Write(Money);
			Writer.Write(ATM);
			Writer.Write(PSILearned);
			Writer.Seek(0x06, SeekOrigin.Current); // Unknown. Appears to be 0x00 in my saves
			Writer.Write((byte)(0x00)); // State party is in. TODO: Fix magic number
			Writer.Seek(0x0A, SeekOrigin.Current); // Unknown. Not always 0x00
			EscargoExpress.WriteDataToStream(Writer);
			Writer.Seek(0x08, SeekOrigin.Current); // Unknown. Not really even close to 0x00
			Location.WriteDataToStream(Writer); //TODO: Verify how positioning is stored.
			Writer.Write((byte)(0x00)); // Direction. TODO: FIX THIS!
			Writer.Seek(0x03, SeekOrigin.Current); // More unknown data.
			Writer.Write((byte)(0x00)); // Party movement style. Need more info
			Writer.Seek(0x07, SeekOrigin.Current); // More of this.
			//TODO: Write the party member order here
			Writer.Seek(0x0D, SeekOrigin.Current); // ...
			//TODO: Write party member count here
			Writer.Seek(0x0C, SeekOrigin.Current); // (all zero?)
			ExitMouseLocation.WriteDataToStream(Writer);
			Writer.Write((byte)TextSpeed);
			Writer.Write((byte)SoundSetting);
			Writer.Seek(0x112, SeekOrigin.Current);
			Writer.Write(Timer);
			Writer.Write((byte)WindowFlavor);
			Party.WriteDataToStream(Writer);
			WriteEventFlags(Writer);
			throw new NotImplementedException("Party number and party order not implemented");
		}

		/// <summary>
		/// Writes the text portion of the save file to a <see cref="BinaryWriter"/>
		/// </summary>
		/// <param name="Writer">The <see cref="BinaryWriter"/> to write to</param>
		private void WriteText(BinaryWriter Writer)
		{
			Writer.Write(System.Text.Encoding.ASCII.GetBytes(MagicString));
			EarthboundPlainTextEncoding PlainTextEncoding = new EarthboundPlainTextEncoding();
			Writer.Seek(0x0D, SeekOrigin.Current); // Unknown data.
			//TODO: Rewrite "English" name with space replaced with K
			Writer.Seek(0x0C, SeekOrigin.Current);
			Writer.Write(PlainTextEncoding.GetBytesPadded(PlayerName, PlayerNameSize));
			//Writer.Seek(0x44, SeekOrigin.Begin); // Offset 0x44 for the pet name. should change this later
			Writer.Write(PlainTextEncoding.GetBytesPadded(PetName, NameSize));
			Writer.Write(PlainTextEncoding.GetBytesPadded(FavoriteFood, NameSize));
			Writer.Write(PlainTextEncoding.GetBytes(PSIPrefix));
			Writer.Write(PlainTextEncoding.GetBytesPadded(FavoriteThing, NameSize));
			Writer.Write(PlainTextEncoding.GetBytesPadded(" ", 2)); // go with me here
		}

		/// <summary>
		/// Writes the event flags to a <see cref="BinaryWriter"/>
		/// </summary>
		/// <param name="Writer">The <see cref="BinaryWriter"/> to write to</param>
		private void WriteEventFlags(BinaryWriter Writer)
		{
			for (int eventFlagIndex = 0; eventFlagIndex < EventFlagSize; eventFlagIndex++)
			{
				byte eventFlagByte = 0;
				for (int bit = 0; bit < 8; bit++)
				{
					eventFlagByte += (byte)((EventFlags[eventFlagIndex++] ? 1 : 0) << bit);
				}
				Writer.Write(eventFlagByte);
			}
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
		/// Stereo (two-channel) sound is used. 
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
		/// A standard window type with a black background and white borders
		/// in text windows and purple in the status windows.
		/// </summary>
		Plain = 1,
		/// <summary>
		/// A mint flavored window type with a slight red background, and blue
		/// as the border of text windows and background of status windows.
		/// </summary>
		Mint = 2,
		/// <summary>
		/// A strawberry flavored window type with a slight red background, and 
		/// red as the border of text windows and background of status windows.
		/// </summary>
		Strawberry = 3,
		/// <summary>
		/// A banana flavored window type with a slight red background, and yellow
		/// as the border of text windows and background of status windows.
		/// </summary>
		Banana = 4,
		/// <summary>
		/// A peanut flavored window type with a slight red background, and orange
		/// as the border of text windows and background of status windows.
		/// </summary>
		Peanut = 5,
	}
}
