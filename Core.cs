using Dota2GSI;
using System;
using System.Collections.Generic;

namespace DOTA_CUE
{
	static class Core
	{
		public static DOTAAPI gameListener = new DOTAAPI();
		public static KeyLighter keyController = new KeyLighter();
		public static bool isRunning = false;
		public static string ip = "";
		public static bool startAPI = false; //makes sure the CSGO connection is only started once

		public static bool inGame = false; //whether or not the player is actually in a game on a team.
		public static bool isDire = false; //whether or not the player is on dire.

		/// <summary>
		/// The main loop update function.
		/// </summary>
		/// <param name="dt"></param>
		public static void mainUpdate(float dt)
		{
			if (startAPI)
			{
				gameListener.connectToDota(ip);
				startAPI = false;
			}
			if (keyController.keyboard != null)
			{
				keyController.Update(dt);
				keyController.keyboard.Update(true); //updates the keyboard leds.
			}
		}

		/// <summary>
		/// Handles the game state
		/// </summary>
		/// <param name="gs"></param>
		public static void handleGameState(GameState gs)
		{
			if (keyController.keyboard != null)
			{
				switch (gs.Player.Team)
				{
					case Dota2GSI.Nodes.PlayerTeam.Dire:
						isDire = true;
						break;
					case Dota2GSI.Nodes.PlayerTeam.Radiant:
						isDire = false;
						break;
					default:
						inGame = false;
						break;
				}
				keyController.handleGameState(gs);
			}
		}

		/// <summary>
		/// Clamps a value to a lower and upper value.
		/// </summary>
		/// <param name="i"></param>
		/// <param name="lower"></param>
		/// <param name="higher"></param>
		/// <returns></returns>
		public static T clampValue<T>(T i, T lower, T upper) where T : IComparable
		{
			int upperTest = i.CompareTo(upper);
			int lowerTest = i.CompareTo(lower);
			if (i.CompareTo(upper) > 0)
				return upper;
			else if (i.CompareTo(lower) < 0)
				return lower;
			else
				return i;
		}
	}
}
