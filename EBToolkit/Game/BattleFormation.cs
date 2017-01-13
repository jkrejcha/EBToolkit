using EBToolkit.Game.Character;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EBToolkit.Game
{
	/// <summary>
	/// Represents a group of enemies that can occur in the game. Each formation
	/// has their own background and has a set of enemies that can occur.
	/// </summary>
	public class BattleGroup
	{
		public readonly Background BattleBackground;
		public EarthboundEnemy[] Enemies;

		/// <summary>
		/// Gets the total experience that is gathered on defeat of this battle
		/// group
		/// </summary>
		public uint TotalExperience
		{
			get
			{
				uint Exp = 0;
				foreach (EarthboundEnemy Enemy in Enemies) Exp += Enemy.Experience;
				return Exp;
			}
		}
	}
}
