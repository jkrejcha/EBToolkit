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
		/// <summary>
		/// The background that is used which the <see cref="EarthboundParty">party</see>
		/// encounter this group in battle
		/// </summary>
		public readonly Background BattleBackground;

		/// <summary>
		/// The enemies that are in this <see cref="BattleGroup"/>
		/// </summary>
		public readonly EarthboundEnemy[] Enemies;

		/// <summary>
		/// The total experience that is gathered on defeat of this battle group
		/// </summary>
		public uint TotalExperience
		{
			get
			{
				uint exp = 0;
				foreach (EarthboundEnemy enemy in Enemies) exp += enemy.Experience;
				return exp;
			}
		}
	}
}
