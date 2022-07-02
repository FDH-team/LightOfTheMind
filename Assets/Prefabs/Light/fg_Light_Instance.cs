using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fg_Light_Instance : MonoBehaviour
{
    public Light light;

    private void Start()
    {
        light = GetComponent<Light>();
        ObjectsManager.m_LightObjects.Add(this);
    }

    public void UpdateColor(Vector4 NewColor, float TimeMultiple)
    {
        light.color = Color.Lerp(light.color, NewColor, Time.deltaTime * TimeMultiple);
    }

}
