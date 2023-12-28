using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ISceneView
{
    void SetParameter(SceneParameterBase parameter);
    void WrapStartScene(SceneParameterBase parameter);
    void WrapActiveScene(string prevSceneName, SceneParameterBase parameter);
    void WrapDeactivateScene(string nextSceneName);
    void WrapUnloadScene();
    SceneParameterBase WrapGetDefaultParameter();
}

