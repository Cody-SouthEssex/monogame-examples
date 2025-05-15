using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SceneManagement.Input
{
    static internal class KeyManager
    {
        static List<Keys> oldState = new List<Keys>();
        static KeyboardState oldKeyboardState;
        static KeyboardState newState;
        static bool doonce = true;

        static public bool IsKeyPressed(Keys key) 
        {
            newState = Keyboard.GetState();

            if (newState.IsKeyDown(key))
            {
                if (!oldState.Contains(key))
                {
                    Debug.WriteLine("hello im being presseed");
                    oldState = newState.GetPressedKeys().ToList();
                    return true;
                }
            }
            else if (newState.GetPressedKeyCount() == 0)
            {
                oldState.Clear();

            }
            return false;
        }

        static public bool IsKeyHeld(Keys key)
        {
            newState = Keyboard.GetState();

            if (newState.IsKeyDown(key))
            {
                if (oldKeyboardState.IsKeyDown(key))
                {
                    oldKeyboardState = newState;
                    Debug.WriteLine("Key Is Held Down");
                    return true;
                }
            }

            oldKeyboardState = newState;
            return false;
        }

        static public bool IsKeyReleased(Keys key)
        {
            newState = Keyboard.GetState();

            if (oldKeyboardState.IsKeyDown(key) && !newState.IsKeyDown(key)) 
            { 
                Debug.WriteLine("Key Is released"); 
                oldKeyboardState = newState; 
                return true; 
            }

            oldKeyboardState = newState;
            return false;  
        }


    }
}
