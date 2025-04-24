using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SceneManagement.Scenes
{
    static internal class SceneManager
    {
        static private readonly Stack<Scene> sceneStack;
        static private readonly Dictionary<SceneEnum, Scene> sceneDictionary = new Dictionary<SceneEnum, Scene>();
        static private SceneEnum currentScene;
        
        static public void AddScene(SceneEnum key, Scene scene) 
        { 
            sceneDictionary.Add(key, scene);
            scene.Load();   
        }
        
        static public Scene GetCurrentScene() 
        {
            return sceneDictionary.TryGetValue(currentScene, out Scene value)? value : null;
        }
        static public void SetCurrentScene(SceneEnum key)
        {
            currentScene = key;
        }
    }
}
