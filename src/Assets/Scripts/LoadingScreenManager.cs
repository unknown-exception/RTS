using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class LoadingScreenManager : MonoBehaviour
{
    private Image progressBar;
    private Text loadingText;

    private string sceneToLoad = "GameScene";

    void Start()
    {
        CreateUI();
        StartCoroutine( LoadAsyncScene() );
    }

    void CreateUI()
    {
        // Canvas
        GameObject canvasGO = new GameObject( "Canvas" );
        Canvas canvas = canvasGO.AddComponent<Canvas>();
        canvas.renderMode = RenderMode.ScreenSpaceOverlay;
        canvasGO.AddComponent<CanvasScaler>();
        canvasGO.AddComponent<GraphicRaycaster>();

        // Progress Bar
        GameObject progressGO = new GameObject( "ProgressBar" );
        progressGO.transform.SetParent( canvasGO.transform );
        progressBar = progressGO.AddComponent<Image>();
        progressBar.color = Color.green;
        progressBar.type = Image.Type.Filled;
        progressBar.fillMethod = Image.FillMethod.Horizontal;
        progressBar.fillAmount = 0f;

        RectTransform rt = progressGO.GetComponent<RectTransform>();
        rt.sizeDelta = new Vector2( 400, 30 );
        rt.anchoredPosition = Vector2.zero;

        GameObject textGO = new GameObject( "LoadingText" );
        textGO.transform.SetParent( canvasGO.transform );
        loadingText = textGO.AddComponent<Text>();
        loadingText.text = "Loading...";
        loadingText.font = Resources.GetBuiltinResource<Font>( "LegacyRuntime.ttf" );
        loadingText.fontSize = 24;
        loadingText.alignment = TextAnchor.MiddleCenter;

        RectTransform textRT = textGO.GetComponent<RectTransform>();
        textRT.sizeDelta = new Vector2( 400, 30 );
        textRT.anchoredPosition = new Vector2( 0, 40 );

        if ( Camera.main == null )
        {
            GameObject camGO = new GameObject( "Main Camera" );
            Camera cam = camGO.AddComponent<Camera>();
            cam.tag = "MainCamera";
        }
    }

    IEnumerator LoadAsyncScene()
    {
        AsyncOperation op = SceneManager.LoadSceneAsync( sceneToLoad );
        op.allowSceneActivation = false;

        while ( !op.isDone )
        {
            float progress = Mathf.Clamp01( op.progress / 0.9f );
            progressBar.fillAmount = progress;
            loadingText.text = $"Loading... {( int ) (progress * 100)}%";

            if ( op.progress >= 0.9f )
            {
                progressBar.fillAmount = 1f;
                yield return new WaitForSeconds( 0.5f );
                op.allowSceneActivation = true;
            }

            yield return null;
        }
    }
}
