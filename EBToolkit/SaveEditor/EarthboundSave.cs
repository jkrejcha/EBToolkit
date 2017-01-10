using EBToolkit.Game;
using EBToolkit.Game.Inventory;
using EBToolkit.Game.Text;
using System;
using System.IO;

namespace EBToolkit.SaveEditor
{
	public class EarthboundSave : EarthboundSaveable
	{
		// Location where Escargo Express data is kept.
		public const int EscargoExpressDataOffset = 0x76;
		public const int SaveLength = 0x27E; // I think...
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
		public TextSpeed TextSpeed;
		public SoundSetting SoundSetting;
		public WindowFlavor WindowFlavor;

		public void WriteDataToStream(BinaryWriter Writer)
		{
			EarthboundPlainTextEncoding PlainTextEncoding = new EarthboundPlainTextEncoding();
			Writer.Seek(0x2C, SeekOrigin.Current);
			Writer.Write(PlainTextEncoding.GetBytesPadded(PlayerName, 7));
			//Writer.Seek(0x44, SeekOrigin.Begin); // Offset 0x44 for the pet name. should change this later
			Writer.Write(PlainTextEncoding.GetBytesPadded(PetName, 6));
			Writer.Write(PlainTextEncoding.GetBytesPadded(FavoriteFood, 6));
			Writer.Seek(0x04, SeekOrigin.Current); //there's a difference of 4 between the favorite food and favorite thing
			Writer.Write(PlainTextEncoding.GetBytes(FavoriteThing + " "));
			Writer.Write(Money);
			Writer.Write(ATM);
			Writer.Seek(0x13, SeekOrigin.Current); // please seek 0x13 for more stuffs
			EscargoExpress.WriteDataToStream(Writer);
			Location.WriteDataToStream(Writer);
			//TODO: Right here, write the party
			ExitMouseLocation.WriteDataToStream(Writer);
			Writer.Write((byte)TextSpeed);
			Writer.Write((byte)SoundSetting);
			Writer.Write(Timer);
			Writer.Write((byte)WindowFlavor);
			//TODO: Right here, write event flags
			throw new NotImplementedException("Party and event flags not implemented");
		}
	}

	public enum TextSpeed : byte
	{
		Fast = 1,
		Medium = 2,
		Slow = 3,
	}

	public enum SoundSetting : byte
	{
		Stereo = 1,
		Mono = 2,
	}

	public enum WindowFlavor : byte
	{
		Plain = 1,
		Mint = 2,
		Strawberry = 3,
		Banana = 4,
		Peanut = 5,
	}
}
