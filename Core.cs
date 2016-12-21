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
		/// Clamps an int to a given upper value.
		/// </summary>
		/// <param name="i"></param>
		/// <param name="clamp"></param>
		/// <returns></returns>
		public static int clampInt(int i, int clamp)
		{
			if (i > clamp)
				return clamp;
			else
				return i;
		}

		public static void handleGameState(GameState gs)
		{
			if (keyController.keyboard != null)
			{
				keyController.handleGameState();
			}
		}
	}
}
