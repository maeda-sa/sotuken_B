using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Cysharp.Threading.Tasks;
using UnityEngine.SceneManagement;

namespace Utility.SceneManagement
{
    public class UnitySceneManager : MonoBehaviour
    {
        protected SceneParameterBase _parameter;
        protected readonly Dictionary<int, ISceneView> _history = new();

        protected static UnitySceneManager _instance;
        public static UnitySceneManager Instance
        {
            get
            {
                if (!_instance)
                {
                    _instance = OnBeforeSceneLoad();
                }
                return _instance;
            }
        }

        [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
        protected static UnitySceneManager OnBeforeSceneLoad()
        {
            if (_instance) { return _instance; }

            var obj = new GameObject(nameof(UnitySceneManager));
            _instance = obj.AddComponent<UnitySceneManager>();

            return _instance;
        }

        protected virtual void Awake() => Initialize();

        protected virtual void Initialize()
        {
            DontDestroyOnLoad(this);
            SceneManager.sceneLoaded += OnLoaded;
            SceneManager.activeSceneChanged += OnActiveSceneChanged;
            SceneManager.sceneUnloaded += OnSceneUnloaded;
        }

        /// <summary>
        /// 新規シーンを読み込んだ時に呼ばれる
        /// </summary>
        /// <param name="scene"></param>
        /// <param name="mode"></param>
        protected void OnLoaded(Scene scene, LoadSceneMode mode)
        {
            if (!_history.TryGetValue(scene.handle, out ISceneView view))
            {
                view = GetOrAddActiveSceneView(scene);
                if (view != null) { _history.Add(scene.handle, view); }
            }

            if (mode == LoadSceneMode.Additive)
            {
                SceneManager.SetActiveScene(scene);
            }

            if (view != null)
            {
                var parameter = _parameter ?? view.WrapGetDefaultParameter();
                view.SetParameter(parameter);
                view.WrapStartScene(parameter);
            }
        }

        /// <summary>
        /// アクティブシーンが切り替わったときに呼ばれる
        /// </summary>
        /// <param name="scene"></param>
        /// <param name="scene1"></param>
        protected void OnActiveSceneChanged(Scene scene, Scene scene1)
        {
            if (scene.IsValid())
            {
                if (_history.TryGetValue(scene.handle, out ISceneView view))
                {
                    view.WrapDeactivateScene(scene1.name);
                }
            }

            if (scene1.IsValid())
            {
                if (!_history.TryGetValue(scene1.handle, out ISceneView view))
                {
                    view = GetOrAddActiveSceneView(scene1);
                    if (view != null) { _history.Add(scene1.handle, view); }
                }

                if (view != null)
                {
                    var parameter = _parameter ?? view.WrapGetDefaultParameter();
                    view.SetParameter(parameter);
                    view.WrapActiveScene(scene.name, parameter);
                }
            }
        }

        /// <summary>
        /// シーンが破棄された時に呼ばれる
        /// </summary>
        /// <param name="scene"></param>
        protected void OnSceneUnloaded(Scene scene)
        {
            if (_history.TryGetValue(scene.handle, out ISceneView view))
            {
                view.WrapUnloadScene();
                _history.Remove(scene.handle);
            }
        }

        /// <summary>
        /// Scene内のISceneViewを返す
        /// </summary>
        /// <param name="scene"></param>
        /// <returns></returns>
        protected ISceneView GetOrAddActiveSceneView(Scene scene)
        {
            var objs = scene.GetRootGameObjects();
            var gameObjs = new List<ISceneView>();
            foreach (var obj in objs)
            {
                // 派生クラスの為、インターフェースで取得
                gameObjs.AddRange(obj.GetComponentsInChildren<ISceneView>(true));
            }
            var sceneView = gameObjs.Count > 0 ? gameObjs[0] : null;
            return sceneView;
        }

        // --------------------------static---------------------------------

        public static async void LoadScene(string name, SceneParameterBase parameter = null, LoadSceneMode mode = LoadSceneMode.Single)
        => await LoadSceneAsync(name, parameter, mode);

        public static AsyncOperation LoadSceneAsync(string name, SceneParameterBase parameter = null, LoadSceneMode mode = LoadSceneMode.Single)
        {
            _instance._parameter = parameter;
            return SceneManager.LoadSceneAsync(name, mode);
        }

        public static async void UnloadScene(string name, SceneParameterBase parameter = null)
            => await UnloadSceneAsync(name, parameter);

        public static AsyncOperation UnloadSceneAsync(string name, SceneParameterBase parameter = null)
        {
            _instance._parameter = parameter;
            return SceneManager.UnloadSceneAsync(name);
        }
    }
}
