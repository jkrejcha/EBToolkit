using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EBToolkit.SaveEditor
{
	/// <summary>
	/// A class that represents a save file in the game EarthBound. This is a
	/// container for <see cref="GameSaveCount"/> objects of <see cref="EarthboundSave"/>
	/// and contains methods for loading and saving save files.
	/// </summary>
	/// <b style="color:red">Many methods in this class are subject to change
	/// and are not guaranteed to be fully functional (even moreso than the
	/// rest of the project).</b>
	public class EarthboundSaveFile
	{
		/// <summary>
		/// The amount of save games that can be in EarthBound
		/// </summary>
		public const int GameSaveCount = 3;
		/// <summary>
		/// Offset for ZSNES save states
		/// </summary>
		public const int ZSNESFileStart = 0xA3E8;
		/// <summary>
		/// The save files themselves.
		/// </summary>
		public readonly EarthboundSave[] Saves;
		/// <summary>
		/// The type of save file this is.
		/// </summary>
		/// <remarks>
		/// ZSNES savestates aren't currently supported, however may be in the
		/// future.
		/// </remarks>
		public readonly SaveFileType SaveFileType;

		/// <summary>
		/// Creates a new, empty save file.
		/// </summary>
		public EarthboundSaveFile()
		{
			SaveFileType = SaveFileType.SNESBatterySave;
			Saves = new EarthboundSave[GameSaveCount];
			for (int i = 0; i < Saves.Length; i++)
			{
				Saves[i] = new EarthboundSave();
			}
		}
		/// <summary>
		/// Loads a save file from a path.
		/// </summary>
		/// <param name="Path">File path to load from</param>
		/// <exception cref="System.IO.IOException">If an IO error occurs</exception>
		public EarthboundSaveFile(String Path)
		{
			throw new NotImplementedException("Loading save files not implemented yet.");
		}

		/// <summary>
		/// Saves the game to disk
		/// </summary>
		/// <param name="Path"></param>
		public void Save(String Path)
		{
			throw new NotImplementedException("Saving save files not implemented yet.");
		}
	}

	/// <summary>
	/// The type of save file a <see cref="EarthboundSaveFile"/> is
	/// <b style="color:red">THIS IS SUBJECT TO CHANGE</b>
	/// </summary>
	public enum SaveFileType
	{
		/// <summary>
		/// A standard SNES battery save
		/// </summary>
		SNESBatterySave = 0,
		/// <summary>
		/// A savestate for the ZSNES emulator
		/// </summary>
		ZSNESSavestate = 1,
		/// <summary>
		/// A custom format for EarthBound saves
		/// </summary>
		EBSave = 2,
	}
}
