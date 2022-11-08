using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

public class LightControlScript : MonoBehaviour {
    public List<Light> Lights;

    private VisualElement frame;
    private Button button_1P;
    private Button button_3P;
    private Button button_ortho;
    private Button button_script;

    void Start() {
        SetIntensity(0);
    }

    void OnEnable() {
        var uiDocument = GetComponent<UIDocument>();
        var rootVisualElement = uiDocument.rootVisualElement;

        frame = rootVisualElement.Q<VisualElement>("Frame");

        button_1P = frame.Q<Button>("1st_Person");
        button_3P = frame.Q<Button>("3rd_Person");
        button_ortho = frame.Q<Button>("Orthographic");
        button_script = frame.Q<Button>("Scripted");

        button_1P.RegisterCallback<ClickEvent>(ev => SetIntensity(0));
        button_3P.RegisterCallback<ClickEvent>(ev => SetIntensity(1));
        button_ortho.RegisterCallback<ClickEvent>(ev => SetIntensity(2));
        button_script.RegisterCallback<ClickEvent>(ev => SetIntensity(3));
    }

    private void SetIntensity(int n) {
        Lights.ForEach(light => light.intensity = n);
    }
}
