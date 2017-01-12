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
	public class BattleFormation
	{
		public readonly Background BattleBackground;
		public EarthboundEnemy[] Enemies;
	}
}
