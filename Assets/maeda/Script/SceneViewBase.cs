using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using UnityEngine;


    public abstract class SceneViewBase<T, TParameter> : MonoBehaviour, ISceneView
        where T : SceneViewBase<T, TParameter>
        where TParameter : SceneParameterBase
    {
        private static T _instance;
        public static T Instance
        {
            get
            {
                if (!_instance) { _instance = FindObjectOfType<T>(); }
                return _instance;
            }
        }

        public TParameter Parameter { get; set; }

        protected virtual void Awake() => _instance = this as T;

        public virtual void OnStartScene(TParameter parameter) { }

        public virtual void OnActiveScene(string prevSceneName, SceneParameterBase parameter) { }

        public virtual void OnDeactivateScene(string nextSceneName) { }

        public virtual void OnUnloadScene() { }

        public virtual TParameter GetDefaultParameter() => null;

        public void WrapStartScene(SceneParameterBase parameter) => OnStartScene(parameter?.ReadValue<TParameter>());

        public void WrapActiveScene(string prevSceneName, SceneParameterBase parameter) => OnActiveScene(prevSceneName, parameter);

        public void WrapDeactivateScene(string nextSceneName) => OnDeactivateScene(nextSceneName);

        public void WrapUnloadScene() => OnUnloadScene();

        public SceneParameterBase WrapGetDefaultParameter() => GetDefaultParameter();

        public void SetParameter(SceneParameterBase parameter) => Parameter = parameter?.ReadValue<TParameter>();
    }

