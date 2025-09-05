using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    void Start()
    {
        GameObject canvasGO = new GameObject( "Canvas" );
        Canvas canvas = canvasGO.AddComponent<Canvas>();
        canvas.renderMode = RenderMode.ScreenSpaceOverlay;
        canvasGO.AddComponent<CanvasScaler>();
        canvasGO.AddComponent<GraphicRaycaster>();

        GameObject textGO = new GameObject( "GameText" );
        textGO.transform.SetParent( canvasGO.transform );
        Text gameText = textGO.AddComponent<Text>();
        gameText.text = "Game Started!";
        gameText.font = Resources.GetBuiltinResource<Font>("LegacyRuntime.ttf");
        gameText.fontSize = 32;
        gameText.alignment = TextAnchor.MiddleCenter;
        gameText.color = Color.white;

        RectTransform rt = textGO.GetComponent<RectTransform>();
        rt.sizeDelta = new Vector2( 400, 60 );
        rt.anchoredPosition = Vector2.zero;
        GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
        cube.transform.position = Vector3.zero;

        if ( Camera.main == null )
        {
            GameObject camGO = new GameObject( "Main Camera" );
            Camera cam = camGO.AddComponent<Camera>();
            cam.tag = "MainCamera";
        }
    }
}
