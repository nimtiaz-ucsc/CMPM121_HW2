using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

public class ControlScript : MonoBehaviour {
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

    void Start() {
        EnableCamera(0);
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

        button_1P.RegisterCallback<ClickEvent>(ev => EnableCamera(0));
        button_3P.RegisterCallback<ClickEvent>(ev => EnableCamera(1));
        button_ortho.RegisterCallback<ClickEvent>(ev => EnableCamera(2));
        button_script.RegisterCallback<ClickEvent>(ev => EnableCamera(3));

        button_on.RegisterCallback<ClickEvent>(ev => SetIntensity(2));
        button_dimmed.RegisterCallback<ClickEvent>(ev => SetIntensity(1));
        button_off.RegisterCallback<ClickEvent>(ev => SetIntensity(0));
    }

    private void EnableCamera(int n) {
        Cameras.ForEach(cam => cam.enabled = false);
        Cameras[n].enabled = true;
    }

    private void SetIntensity(int n) {
        // Lights.ForEach(light => light.intensity *= (n/2));
    }
}
