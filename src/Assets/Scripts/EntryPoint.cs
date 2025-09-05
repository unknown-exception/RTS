using System.Collections.Generic;
using System;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.TutorialInfo.Scripts
{
    public class EntryPoint
    {
        [RuntimeInitializeOnLoadMethod( RuntimeInitializeLoadType.BeforeSceneLoad )]
        static void Init()
        {
            SceneManager.sceneLoaded += OnSceneLoaded;
            SceneManager.LoadScene( "MenuScene" );
        }

        static void OnSceneLoaded( Scene scene, LoadSceneMode mode )
        {
            if (_sceneManagers.TryGetValue(scene.name, out Type managerType))
                new GameObject(managerType.Name).AddComponent(managerType);
            else
                Debug.LogWarning($"No manager mapped for scene: {scene.name}");
        }

        private static Dictionary<string, Type> _sceneManagers = new Dictionary<string, Type>
        {
            { "MenuScene", typeof(MenuManager) },
            { "LoadingScene", typeof(LoadingScreenManager) },
            { "GameScene", typeof(GameManager) }
        };  
    }
}