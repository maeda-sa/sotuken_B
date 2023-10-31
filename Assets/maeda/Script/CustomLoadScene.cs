using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

/// <summary>
/// 設定用クラス(派生不可)
/// </summary>
public sealed class CustomLoadSceneOption
{
    public Color fadeColor = Color.white;
    public float fadeOutTime = 0.5f;
    public float minLoadingTime = 0;
    public float fadeInTime = 0.5f;
    public string loadingSceneName = "LoadScene";
    public bool isDefaultFade = true;
    public Action<GameObject> OnFadeOutStart = null; // フェードアウト開始時に呼ばれる
    public Action OnLoadingStart = null; // ロード開始時に呼ばれる
    public Action OnDidLoadFinish = null; // ロード終了時に呼ばれる
    public Action<GameObject> OnFadeInStart = null; // フェードイン開始時に呼ばれる
    public Action OnDidFinish = null; // ロード終了後に呼ばれる
}

public class CustomLoadScene : MonoBehaviour
{
    private static CustomLoadScene instance;
    public static CustomLoadScene Instance
    {
        get
        {
            if (instance == null)
            {
                var obj = new GameObject(typeof(CustomLoadScene).Name);
                instance = obj.AddComponent<CustomLoadScene>();
            }
            return instance;
        }
    }

    private enum State
    {
        Ready,
        FadeOut,
        LoadingScene,
        FadeIn,
    }

    private State state = State.Ready;
    private GameObject canvasObj;
    private Image defaultFadeImage;
    private AsyncOperation asyncLoad;
    private CustomLoadSceneOption option;
    private bool isLoadingScene;
    private string sceneName;

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

    private void Update()
    {
        if (option.isDefaultFade)
        {
            if (state == State.FadeOut)
            {
                // フェードアウト
                var color = defaultFadeImage.color;
                color.a += Time.deltaTime / option.fadeOutTime;
                color.a = Mathf.Clamp01(color.a);
                defaultFadeImage.color = color;
            }
            else if (state == State.FadeIn)
            {
                // フェードイン
                var color = defaultFadeImage.color;
                color.a -= Time.deltaTime / option.fadeInTime;
                color.a = Mathf.Clamp01(color.a);
                defaultFadeImage.color = color;
            }
        }
    }

    /// <summary>
    /// シーンの読み込み
    /// </summary>
    /// <param name="sceneName"></param>
    /// <param name="_option"></param>
    public void LoadScene(string sceneName, CustomLoadSceneOption _option = null)
    {
        if (state != State.Ready)
        {
            Debug.LogWarning("遷移処理中により、リクエストはキャンセルされました。");
            return;
        }

        this.sceneName = sceneName;

        // ユーザ設定がなければデフォルト設定で行う
        option = _option ?? new CustomLoadSceneOption();

        // キャンバス
        canvasObj = new GameObject("Canvas");
        canvasObj.transform.SetParent(transform, false);
        canvasObj.layer = LayerMask.NameToLayer("UI");

        var canvas = canvasObj.AddComponent<Canvas>();
        canvas.renderMode = RenderMode.ScreenSpaceOverlay;
        canvas.sortingOrder = 999;

        canvasObj.AddComponent<CanvasScaler>();

        // デフォルトのフェード画像
        if (option.isDefaultFade)
        {
            var imageObj = new GameObject("Image");
            imageObj.transform.SetParent(canvasObj.transform, false);
            imageObj.AddComponent<CanvasRenderer>();

            defaultFadeImage = imageObj.AddComponent<Image>();
            var color = option.fadeColor;
            color.a = 0;
            defaultFadeImage.color = color;

            var rec = imageObj.GetComponent<RectTransform>();
            rec.anchorMin = Vector2.zero;
            rec.anchorMax = Vector2.one;
            rec.offsetMin = Vector2.zero;
            rec.offsetMax = Vector2.zero;
        }

        // ロード画面の有無
        isLoadingScene = !string.IsNullOrEmpty(option.loadingSceneName) && 0 < option.minLoadingTime;

        // フェードアウト開始
        OnFadeOutStart();
    }

    /// <summary>
    /// フェードアウト開始処理
    /// </summary>
    private void OnFadeOutStart()
    {
        state = State.FadeOut;
        option.OnFadeOutStart?.Invoke(canvasObj);

        // フェードアウト終了時の処理
        StartCoroutine(Delay(option.fadeOutTime, () =>
        {
            if (isLoadingScene)
            {
                // ロード画面へ遷移する
                SceneManager.sceneLoaded += OnLoadingStart;
                SceneManager.LoadScene(option.loadingSceneName);
            }
            else
            {
                // 次のシーンの読み込みが完了したら遷移する
                OnLoadNextSceneAsync();
            }
        }));
    }

    /// <summary>
    /// ロード画面開始処理
    /// </summary>
    /// <param name="nextScene"></param>
    /// <param name="mode"></param>
    private void OnLoadingStart(Scene nextScene, LoadSceneMode mode)
    {
        SceneManager.sceneLoaded -= OnLoadingStart;

        canvasObj.SetActive(false);

        // 次のシーンの読み込みを非同期で開始する
        StartCoroutine(OneFrameDelay(OnLoadNextSceneAsync));
    }

    /// <summary>
    /// 次のシーンを非同期で読み込む
    /// </summary>
    private void OnLoadNextSceneAsync()
    {
        state = State.LoadingScene;
        option.OnLoadingStart?.Invoke();

        // バックグラウンドでシーンを読み込み開始
        asyncLoad = SceneManager.LoadSceneAsync(sceneName);

        // シーン読み込み完了後、自動的にシーンの切り替えを不許可
        asyncLoad.allowSceneActivation = false;

        // シーンの読み込み完了まで待機する
        StartCoroutine(LoadNextSceneAsync(option.minLoadingTime));
    }

    /// <summary>
    /// シーンの読み込みが完了するのを待つ
    /// </summary>
    /// <param name="waitTime"></param>
    /// <returns></returns>
    private IEnumerator LoadNextSceneAsync(float waitTime)
    {
        // ロードがすぐに完了しても、最小ロード時間は待機する
        yield return new WaitForSeconds(waitTime);

        // シーン読み込み完了後、自動的にシーンの切り替えを許可
        asyncLoad.allowSceneActivation = true;

        // シーン読み込み完了を待つ&完了後遷移する
        while (!asyncLoad.isDone) yield return null;

        option.OnDidLoadFinish?.Invoke();

        // フェードイン開始     
        OnFadeInStart();
    }

    /// <summary>
    /// フェードイン開始処理
    /// </summary>
    private void OnFadeInStart()
    {
        state = State.FadeIn;
        option.OnFadeInStart?.Invoke(canvasObj);

        if (!canvasObj.activeSelf) canvasObj.SetActive(true);

        // 一定時間後に終了
        StartCoroutine(Delay(option.fadeInTime, () =>
        {
            option.OnDidFinish?.Invoke();
            Destroy(gameObject);
        }));
    }

    private IEnumerator Delay(float delayTime, Action action)
    {
        if (0 < delayTime)
        {
            yield return new WaitForSeconds(delayTime);
            action?.Invoke();
        }
        else
        {
            action?.Invoke();
            yield return null;
        }
    }

    private IEnumerator OneFrameDelay(Action action)
    {
        yield return null;
        action?.Invoke();
    }
}
