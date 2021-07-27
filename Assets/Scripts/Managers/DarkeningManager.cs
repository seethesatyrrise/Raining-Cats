using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DarkeningManager : MonoBehaviour
{

    [SerializeField] Light sceneLight;

    float coefficient = 0.075f;
    float step = 0.001f;
    float targetIntensity = 1;

    // Update is called once per frame
    void Update()
    {
        if (sceneLight.intensity > targetIntensity)
            sceneLight.intensity -= step;
    }

    public void DecreaseIntensity()
    {
        targetIntensity -= coefficient;
    }
}
