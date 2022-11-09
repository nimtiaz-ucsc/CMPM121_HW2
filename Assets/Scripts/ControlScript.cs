using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

public class ControlScript : MonoBehaviour {

    public GameObject CameraGroup;
    public List<Camera> Cameras;
    public List<Light> Lights;

    private VisualElement cameraFrame;
    private VisualElement lightingFrame;
    private Button button_1P;
    private Button button_3P;
    private Button button_ortho;
    private Button button_script;
    private Button button_on;
    private Button button_dimmed;
    private Button button_off;
    private Button button_cycle;

    void Start() {
        EnableCamera(0);
        SetLights(2);
    }

    void OnEnable() {
        var uiDocument = GetComponent<UIDocument>();
        var rootVisualElement = uiDocument.rootVisualElement;

        cameraFrame = rootVisualElement.Q<VisualElement>("CameraFrame");
        lightingFrame = rootVisualElement.Q<VisualElement>("LightingFrame");

        button_1P = cameraFrame.Q<Button>("1st_Person");
        button_3P = cameraFrame.Q<Button>("3rd_Person");
        button_ortho = cameraFrame.Q<Button>("Orthographic");
        button_script = cameraFrame.Q<Button>("Scripted");

        button_on = lightingFrame.Q<Button>("On");
        button_dimmed = lightingFrame.Q<Button>("Dimmed");
        button_off = lightingFrame.Q<Button>("Off");
        button_cycle = lightingFrame.Q<Button>("DayNight_Cycle");

        button_1P.RegisterCallback<ClickEvent>(ev => EnableCamera(0));
        button_3P.RegisterCallback<ClickEvent>(ev => EnableCamera(1));
        button_ortho.RegisterCallback<ClickEvent>(ev => EnableCamera(2));
        button_script.RegisterCallback<ClickEvent>(ev => EnableCamera(3));

        button_on.RegisterCallback<ClickEvent>(ev => SetLights(2));
        button_dimmed.RegisterCallback<ClickEvent>(ev => SetLights(1));
        button_off.RegisterCallback<ClickEvent>(ev => SetLights(0));
        
        button_cycle.RegisterCallback<ClickEvent>(ev => {
            CameraGroup.GetComponent<DayNightCycle>().cyclePlaying = !CameraGroup.GetComponent<DayNightCycle>().cyclePlaying;
            if (CameraGroup.GetComponent<DayNightCycle>().cyclePlaying) {
                button_cycle.text = "Pause\nDay/Night Cycle";
            } else {
                button_cycle.text = "Play\nDay/Night Cycle";
            }
        });
    }

    private void EnableCamera(int n) {
        Cameras.ForEach(cam => cam.enabled = false);
        Cameras[n].enabled = true;
    }

    private void SetLights(float n) {
        Lights[0].intensity = 1f;
        Lights[1].intensity = 8f;
        Lights[2].intensity = 1f;
        Lights.ForEach(light => light.intensity *= n/2);
    }
}
