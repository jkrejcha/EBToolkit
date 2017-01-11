using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EBToolkit.SaveEditor
{
	/// <summary>
	/// A class that represents a save file in the game EarthBound. This is a
	/// container for <see cref="SaveCount"/> objects of <see cref="EarthboundSave"/>
	///  and contains methods for loading and saving save files.
	/// </summary>
	public class EarthboundSaveFile
	{
		public const int SaveCount = 3;
		/// <summary>
		/// Offset for ZSNES save states
		/// </summary>
		public const int ZSNESFileStart = 0xA3E8;

		public readonly EarthboundSave[] Saves = new EarthboundSave[SaveCount];
		public readonly bool ZSNESSavestate;

		/// <summary>
		/// Creates a new, empty save file.
		/// </summary>
		public EarthboundSaveFile()
		{
			this.ZSNESSavestate = false;
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

		public void Save(String Path)
		{
			throw new NotImplementedException("Saving save files not implemented yet.");
		}
	}
}
