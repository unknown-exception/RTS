using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    private Button newGameButton;

    void Start()
    {
        GameObject canvasGO = new GameObject( "Canvas" );
        Canvas canvas = canvasGO.AddComponent<Canvas>();
        canvas.renderMode = RenderMode.ScreenSpaceOverlay;
        canvasGO.AddComponent<CanvasScaler>();
        canvasGO.AddComponent<GraphicRaycaster>();

        GameObject buttonGO = new GameObject( "NewGameButton" );
        buttonGO.transform.SetParent( canvasGO.transform );
        newGameButton = buttonGO.AddComponent<Button>();

        Image btnImage = buttonGO.AddComponent<Image>();
        btnImage.color = Color.cyan;

        RectTransform rt = buttonGO.GetComponent<RectTransform>();
        rt.sizeDelta = new Vector2( 200, 60 );
        rt.anchoredPosition = Vector2.zero;

        GameObject textGO = new GameObject( "Text" );
        textGO.transform.SetParent( buttonGO.transform );
        Text btnText = textGO.AddComponent<Text>();
        btnText.text = "New Game";
        btnText.font = Resources.GetBuiltinResource<Font>( "LegacyRuntime.ttf" );
        btnText.fontSize = 24;
        btnText.alignment = TextAnchor.MiddleCenter;
        btnText.color = Color.black;

        if (FindFirstObjectByType<UnityEngine.EventSystems.EventSystem>() == null )            
        {
            GameObject es = new GameObject( "EventSystem" );
            es.AddComponent<UnityEngine.EventSystems.EventSystem>();
            es.AddComponent<UnityEngine.EventSystems.StandaloneInputModule>();
        }

        RectTransform textRT = textGO.GetComponent<RectTransform>();
        textRT.sizeDelta = new Vector2( 200, 60 );
        textRT.anchoredPosition = Vector2.zero;

        newGameButton.onClick.AddListener( ()=> SceneManager.LoadScene("LoadingScene") );

        if ( Camera.main == null )
        {
            GameObject camGO = new GameObject( "Main Camera" );
            Camera cam = camGO.AddComponent<Camera>();
            cam.tag = "MainCamera";
        }
    }
}
