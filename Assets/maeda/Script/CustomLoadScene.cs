using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

/// <summary>
/// �ݒ�p�N���X(�h���s��)
/// </summary>
public sealed class CustomLoadSceneOption
{
    public Color fadeColor = Color.white;
    public float fadeOutTime = 0.5f;
    public float minLoadingTime = 0;
    public float fadeInTime = 0.5f;
    public string loadingSceneName = "LoadScene";
    public bool isDefaultFade = true;
    public Action<GameObject> OnFadeOutStart = null; // �t�F�[�h�A�E�g�J�n���ɌĂ΂��
    public Action OnLoadingStart = null; // ���[�h�J�n���ɌĂ΂��
    public Action OnDidLoadFinish = null; // ���[�h�I�����ɌĂ΂��
    public Action<GameObject> OnFadeInStart = null; // �t�F�[�h�C���J�n���ɌĂ΂��
    public Action OnDidFinish = null; // ���[�h�I����ɌĂ΂��
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
                // �t�F�[�h�A�E�g
                var color = defaultFadeImage.color;
                color.a += Time.deltaTime / option.fadeOutTime;
                color.a = Mathf.Clamp01(color.a);
                defaultFadeImage.color = color;
            }
            else if (state == State.FadeIn)
            {
                // �t�F�[�h�C��
                var color = defaultFadeImage.color;
                color.a -= Time.deltaTime / option.fadeInTime;
                color.a = Mathf.Clamp01(color.a);
                defaultFadeImage.color = color;
            }
        }
    }

    /// <summary>
    /// �V�[���̓ǂݍ���
    /// </summary>
    /// <param name="sceneName"></param>
    /// <param name="_option"></param>
    public void LoadScene(string sceneName, CustomLoadSceneOption _option = null)
    {
        if (state != State.Ready)
        {
            Debug.LogWarning("�J�ڏ������ɂ��A���N�G�X�g�̓L�����Z������܂����B");
            return;
        }

        this.sceneName = sceneName;

        // ���[�U�ݒ肪�Ȃ���΃f�t�H���g�ݒ�ōs��
        option = _option ?? new CustomLoadSceneOption();

        // �L�����o�X
        canvasObj = new GameObject("Canvas");
        canvasObj.transform.SetParent(transform, false);
        canvasObj.layer = LayerMask.NameToLayer("UI");

        var canvas = canvasObj.AddComponent<Canvas>();
        canvas.renderMode = RenderMode.ScreenSpaceOverlay;
        canvas.sortingOrder = 999;

        canvasObj.AddComponent<CanvasScaler>();

        // �f�t�H���g�̃t�F�[�h�摜
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

        // ���[�h��ʂ̗L��
        isLoadingScene = !string.IsNullOrEmpty(option.loadingSceneName) && 0 < option.minLoadingTime;

        // �t�F�[�h�A�E�g�J�n
        OnFadeOutStart();
    }

    /// <summary>
    /// �t�F�[�h�A�E�g�J�n����
    /// </summary>
    private void OnFadeOutStart()
    {
        state = State.FadeOut;
        option.OnFadeOutStart?.Invoke(canvasObj);

        // �t�F�[�h�A�E�g�I�����̏���
        StartCoroutine(Delay(option.fadeOutTime, () =>
        {
            if (isLoadingScene)
            {
                // ���[�h��ʂ֑J�ڂ���
                SceneManager.sceneLoaded += OnLoadingStart;
                SceneManager.LoadScene(option.loadingSceneName);
            }
            else
            {
                // ���̃V�[���̓ǂݍ��݂�����������J�ڂ���
                OnLoadNextSceneAsync();
            }
        }));
    }

    /// <summary>
    /// ���[�h��ʊJ�n����
    /// </summary>
    /// <param name="nextScene"></param>
    /// <param name="mode"></param>
    private void OnLoadingStart(Scene nextScene, LoadSceneMode mode)
    {
        SceneManager.sceneLoaded -= OnLoadingStart;

        canvasObj.SetActive(false);

        // ���̃V�[���̓ǂݍ��݂�񓯊��ŊJ�n����
        StartCoroutine(OneFrameDelay(OnLoadNextSceneAsync));
    }

    /// <summary>
    /// ���̃V�[����񓯊��œǂݍ���
    /// </summary>
    private void OnLoadNextSceneAsync()
    {
        state = State.LoadingScene;
        option.OnLoadingStart?.Invoke();

        // �o�b�N�O���E���h�ŃV�[����ǂݍ��݊J�n
        asyncLoad = SceneManager.LoadSceneAsync(sceneName);

        // �V�[���ǂݍ��݊�����A�����I�ɃV�[���̐؂�ւ���s����
        asyncLoad.allowSceneActivation = false;

        // �V�[���̓ǂݍ��݊����܂őҋ@����
        StartCoroutine(LoadNextSceneAsync(option.minLoadingTime));
    }

    /// <summary>
    /// �V�[���̓ǂݍ��݂���������̂�҂�
    /// </summary>
    /// <param name="waitTime"></param>
    /// <returns></returns>
    private IEnumerator LoadNextSceneAsync(float waitTime)
    {
        // ���[�h�������Ɋ������Ă��A�ŏ����[�h���Ԃ͑ҋ@����
        yield return new WaitForSeconds(waitTime);

        // �V�[���ǂݍ��݊�����A�����I�ɃV�[���̐؂�ւ�������
        asyncLoad.allowSceneActivation = true;

        // �V�[���ǂݍ��݊�����҂�&������J�ڂ���
        while (!asyncLoad.isDone) yield return null;

        option.OnDidLoadFinish?.Invoke();

        // �t�F�[�h�C���J�n     
        OnFadeInStart();
    }

    /// <summary>
    /// �t�F�[�h�C���J�n����
    /// </summary>
    private void OnFadeInStart()
    {
        state = State.FadeIn;
        option.OnFadeInStart?.Invoke(canvasObj);

        if (!canvasObj.activeSelf) canvasObj.SetActive(true);

        // ��莞�Ԍ�ɏI��
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
