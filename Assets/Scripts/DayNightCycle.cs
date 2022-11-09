using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DayNightCycle : MonoBehaviour
{
    public Material Skybox;
    [Space]
    public float atmosphereMin = 0.3f;
    public float atmosphereMax = 1f;
    [Space]
    public float exposureMin = 0.6f;
    public float exposureMax = 2f;
    [Space]
    public float speed = 0.001f;
    public float pauseTime = 3f;

    private float atmosphereVal;
    private float exposureVal;
    private bool nightToDay = true;
    private bool isPaused = false;

    [HideInInspector]
    public bool cyclePlaying = true;
    void Start() {
        atmosphereVal = (atmosphereMin + atmosphereMax)/2;
        exposureVal = (exposureMin + exposureMax)/2;
        RenderSettings.skybox.SetFloat("_AtmosphereThickness", atmosphereVal);
        RenderSettings.skybox.SetFloat("_Exposure", exposureVal);
    }

    void Update() {
        if (atmosphereVal >= atmosphereMax && nightToDay) {
            nightToDay = false;
            StartCoroutine(pauseCycle());
        } else if (atmosphereVal <= atmosphereMin && !nightToDay) {
            nightToDay = true;
            StartCoroutine(pauseCycle());
        }
        if (cyclePlaying && !isPaused) {
            if (nightToDay) {
                RenderSettings.skybox.SetFloat("_AtmosphereThickness", atmosphereVal += speed);
                RenderSettings.skybox.SetFloat("_Exposure", exposureVal += (speed*2)); 
            }
            else {
                RenderSettings.skybox.SetFloat("_AtmosphereThickness", atmosphereVal -= speed);
                RenderSettings.skybox.SetFloat("_Exposure", exposureVal -= (speed*2)); 
            }
        }
    }

    IEnumerator pauseCycle() {
        isPaused = true;
        yield return new WaitForSeconds(pauseTime);
        isPaused = false;
    }
}