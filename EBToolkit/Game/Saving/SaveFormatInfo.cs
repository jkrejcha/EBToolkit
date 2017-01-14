using EBToolkit.SaveEditor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EBToolkit.Game.Saving
{
	//TODO: Really, I should worry about this when I actually get to thinking about loading files
	/// <summary>
	/// An interface for loading and saving save files
	/// </summary>
	public interface SaveFormatInfo
	{
		/// <summary>
		/// When overriden in a derived class, this loads a save file either from
		/// disk, memory, or possibly another location.
		/// </summary>
		/// <param name="Path">Path to load from</param>
		/// <returns>A save game</returns>
		EarthboundSaveFile Load(String Path);
		/// <summary>
		/// When overrriden in a derived class, this saves a save file either to
		/// disk, or possibly to memory or another location.
		/// </summary>
		/// <param name="SaveFile">Save file to save</param>
		/// <param name="Path">Path to save to</param>
		void Save(EarthboundSaveFile SaveFile, String Path);
	}
}
