using System.Collections.Generic;
using CUE.NET.Devices.Keyboard;
using CUE.NET.Devices.Keyboard.Enums;
using System;
using System.Drawing;
using CUE.NET.Groups;
using CUE.NET.Devices.Generic.Enums;

namespace DOTA_CUE
{
    static class KeyGroups
    {
        public static RectangleLedGroup numpad; //a selection of the numpad keys.
        public static List<ListLedGroup> numpadDigital; //a list of combinations of numpad keys meant to look like a digital number display.
        public static ListLedGroup WASD;
        public static ListLedGroup healthFunction;
        public static ListLedGroup manaFunction;

        /// <summary>
        /// Intial setup of keygroups using the keyboard provided.
        /// </summary>
        /// <param name="keyboard"></param>
        /// <param name="useNumpad"></param>
        public static void setupKeyGroups(CorsairKeyboard keyboard, bool useNumpad)
        {
            try
            {
                WASD = new ListLedGroup(keyboard, keyboard['W'],
                    keyboard['A'],
                    keyboard['S'],
                    keyboard['D']);
                
                healthFunction = new ListLedGroup(keyboard, CorsairKeyboardLedId.F1,
                    CorsairKeyboardLedId.F2,
                    CorsairKeyboardLedId.F3,
                    CorsairKeyboardLedId.F4,
                    CorsairKeyboardLedId.F5,
                    CorsairKeyboardLedId.F6);
				manaFunction = new ListLedGroup(keyboard, CorsairKeyboardLedId.F7,
                    CorsairKeyboardLedId.F8,
                    CorsairKeyboardLedId.F9,
                    CorsairKeyboardLedId.F10,
                    CorsairKeyboardLedId.F11,
                    CorsairKeyboardLedId.F12);

                //don't initilize the numpad groups if the keyboard doesn't have a numpad(K65).
                if (useNumpad)
                {
					numpad = new RectangleLedGroup(keyboard, CorsairKeyboardLedId.NumLock, CorsairKeyboardLedId.KeypadEnter, 1.0f, true);
					
                    numpadDigital = new List<ListLedGroup>();
                    for (int i = 0; i < 10; ++i)
                    {
                        numpadDigital.Add(null);
                    }

                    numpadDigital[1] = new ListLedGroup(keyboard,
                        CorsairKeyboardLedId.NumLock,
                        CorsairKeyboardLedId.KeypadSlash,
                        CorsairKeyboardLedId.Keypad8,
                        CorsairKeyboardLedId.Keypad5,
                        CorsairKeyboardLedId.Keypad2,
                        CorsairKeyboardLedId.Keypad0,
                        CorsairKeyboardLedId.KeypadPeriodAndDelete);

                    var numpad2Keys = new CorsairLedId[] { CorsairKeyboardLedId.NumLock,
                    CorsairKeyboardLedId.KeypadSlash,
                    CorsairKeyboardLedId.KeypadAsterisk,
                    CorsairKeyboardLedId.Keypad9,
                    CorsairKeyboardLedId.Keypad6,
                    CorsairKeyboardLedId.Keypad5,
                    CorsairKeyboardLedId.Keypad4,
                    CorsairKeyboardLedId.Keypad1,
                    CorsairKeyboardLedId.Keypad0,
                    CorsairKeyboardLedId.KeypadPeriodAndDelete};
                    numpadDigital[2] = new ListLedGroup(keyboard, numpad2Keys);

                    numpadDigital[3] = new ListLedGroup(keyboard, numpad2Keys);
                    numpadDigital[3].AddLed(CorsairKeyboardLedId.Keypad3);
                    numpadDigital[3].RemoveLed(CorsairKeyboardLedId.Keypad1);

                    var numpad4Keys = new CorsairLedId[] { CorsairKeyboardLedId.NumLock,
                    CorsairKeyboardLedId.Keypad7,
                    CorsairKeyboardLedId.Keypad4,
                    CorsairKeyboardLedId.Keypad5,
                    CorsairKeyboardLedId.Keypad6,
                    CorsairKeyboardLedId.Keypad9,
                    CorsairKeyboardLedId.KeypadAsterisk,
                    CorsairKeyboardLedId.Keypad3,
                    CorsairKeyboardLedId.KeypadPeriodAndDelete};
                    numpadDigital[4] = new ListLedGroup(keyboard, numpad4Keys);

                    numpadDigital[5] = new ListLedGroup(keyboard, numpad2Keys);
                    numpadDigital[5].AddLed(CorsairKeyboardLedId.Keypad7, CorsairKeyboardLedId.Keypad3);
                    numpadDigital[5].RemoveLed(CorsairKeyboardLedId.Keypad9, CorsairKeyboardLedId.Keypad1);

                    numpadDigital[6] = new ListLedGroup(keyboard, numpad2Keys);
                    numpadDigital[6].AddLed(CorsairKeyboardLedId.Keypad3, CorsairKeyboardLedId.Keypad7);
                    numpadDigital[6].RemoveLed(CorsairKeyboardLedId.Keypad9);

                    var numpad7Keys = new CorsairLedId[] {
                    CorsairKeyboardLedId.Keypad7,
                    CorsairKeyboardLedId.NumLock,
                    CorsairKeyboardLedId.KeypadSlash,
                    CorsairKeyboardLedId.KeypadAsterisk,
                    CorsairKeyboardLedId.Keypad9,
                    CorsairKeyboardLedId.Keypad6,
                    CorsairKeyboardLedId.Keypad3,
                    CorsairKeyboardLedId.KeypadPeriodAndDelete };
                    numpadDigital[7] = new ListLedGroup(keyboard, numpad7Keys);

                    numpadDigital[8] = new ListLedGroup(keyboard, numpad2Keys);
                    numpadDigital[8].AddLed(CorsairKeyboardLedId.Keypad7, CorsairKeyboardLedId.Keypad3);

                    numpadDigital[9] = new ListLedGroup(keyboard, numpad4Keys);
                    numpadDigital[9].AddLed(CorsairKeyboardLedId.KeypadSlash);

                    numpadDigital[0] = new ListLedGroup(keyboard, numpad7Keys);
                    numpadDigital[0].AddLed(CorsairKeyboardLedId.Keypad0,
                        CorsairKeyboardLedId.Keypad1,
                        CorsairKeyboardLedId.Keypad4);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception in creating key groups!");
                Console.WriteLine("Message: " + ex.Message);
            }
        }
    }
}
