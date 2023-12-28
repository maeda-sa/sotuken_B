using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract record SceneParameterBase()
{
    public T ReadValue<T>() where T : class => this as T;
};
