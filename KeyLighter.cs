using System;
using CUE.NET;
using CUE.NET.Devices.Keyboard;
using CUE.NET.Devices.Generic;
using CUE.NET.Devices.Generic.Enums;
using CUE.NET.Exceptions;
using System.Drawing;
using CUE.NET.Devices.Keyboard.Enums;
using CUE.NET.Gradients;
using CUE.NET.Brushes;
using System.Linq;
using Dota2GSI;

namespace DOTA_CUE
{
	class KeyLighter
	{
		public CorsairKeyboard keyboard = null;
		public bool useNumpad = false;

		/// <summary>
		/// Initilize the keylighter
		/// </summary>
		public void Start()
		{
			//initilize the keyboard or return an exception if it fails.
			try
			{
				CueSDK.Initialize();
				Console.WriteLine("CUE Started with " + CueSDK.LoadedArchitecture + "-SDK");

				keyboard = CueSDK.KeyboardSDK;
				if (keyboard != null)
				{
					// keyboard = UpdateMode.Manual;
					//keyboard.UpdateFrequency = 1f/30f;
					//K65 never has a keypad so check this first.
					if (keyboard.DeviceInfo.Model.Contains("K65"))
					{
						useNumpad = false;
					}
					//This should work to verify that the keyboard has a numpad.
					else
					{
						var numpad = keyboard.Leds.Where(k => k.Id == CorsairLedId.Keypad0).ToList();
						if (numpad != null && numpad.Count > 0)
						{
							useNumpad = true;
						}
					}
					KeyGroups.setupKeyGroups(keyboard, useNumpad);
				}
			}
			catch (CUEException ex)
			{
				Console.WriteLine("CUE Exception!");
				Console.WriteLine("ErrorCode: " + Enum.GetName(typeof(CorsairError), ex.Error));
				keyboard = null;
			}
			catch (WrapperException ex)
			{
				Console.WriteLine("CUE Wrapper Exception!");
				Console.WriteLine("Message:" + ex.Message);
				keyboard = null;
			}
		}

		public void Update(float dt)
		{

		}

		/// <summary>
		/// Handle a new game state.
		/// </summary>
		/// <param name="gs"></param>
		public void handleGameState(GameState gs)
		{

		}

		/// <summary>
		/// Finds a keypad number based on the number fed in.
		/// Only for single digits.
		/// </summary>
		CorsairLedId findKeypadKey(int inI)
		{
			switch (inI)
			{
				case 1:
					return CorsairKeyboardLedId.Keypad1;
				case 2:
					return CorsairKeyboardLedId.Keypad2;
				case 3:
					return CorsairKeyboardLedId.Keypad3;
				case 4:
					return CorsairKeyboardLedId.Keypad4;
				case 5:
					return CorsairKeyboardLedId.Keypad5;
				case 6:
					return CorsairKeyboardLedId.Keypad6;
				case 7:
					return CorsairKeyboardLedId.Keypad7;
				case 8:
					return CorsairKeyboardLedId.Keypad8;
				case 9:
					return CorsairKeyboardLedId.Keypad9;
			}
			return CorsairKeyboardLedId.Keypad0;
		}
	}
}
