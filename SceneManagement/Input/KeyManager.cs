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
        static KeyboardState oldState;
        static KeyboardState newState;

        static public bool IsKeyPressed(Keys key) 
        {
            newState = Keyboard.GetState();

            if (newState.IsKeyDown(key))
            {
                
                if (!oldState.IsKeyDown(key)) 
                { 
                    Debug.WriteLine("hello im being presseed"); 
                    oldState = newState;  
                    return true; 
                }
            }
            oldState = newState;
            return false;
        }

        static public bool IsKeyHeld(Keys key)
        {
            newState = Keyboard.GetState();

            if (newState.IsKeyDown(key))
            {
                if (oldState.IsKeyDown(key))
                {
                    oldState = newState;
                    Debug.WriteLine("Key Is Held Down");
                    return true;
                }
            }

            oldState = newState;
            return false;
        }

        static public bool IsKeyReleased(Keys key)
        {
            newState = Keyboard.GetState();

            if (oldState.IsKeyDown(key) && !newState.IsKeyDown(key)) 
            { 
                Debug.WriteLine("Key Is released"); 
                oldState = newState; 
                return true; 
            }

            oldState = newState;
            return false;  
        }


    }
}
