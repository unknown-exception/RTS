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
            if ( scene.name == "MenuScene" )
            {
                GameObject go = new GameObject( "MenuManager" );
                go.AddComponent<MenuManager>();
            }
            else if (scene.name == "LoadingScene")
            {
                GameObject go = new GameObject("LoadingManager");
                go.AddComponent<LoadingScreenManager>();
            }
            else if (scene.name == "GameScene")
            {
                new GameObject("GameManager").AddComponent<GameManager>();
            }
        }
    }
}