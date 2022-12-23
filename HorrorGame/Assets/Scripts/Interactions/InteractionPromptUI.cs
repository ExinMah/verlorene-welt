using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;

public class InteractionPromptUI : MonoBehaviour
{
    private Camera mainCam;
    [SerializeField] private GameObject uiPanel;
    [FormerlySerializedAs("_promptText")] [SerializeField] private TextMeshProUGUI promptText;

    private void Start()
    {
        mainCam = Camera.main;
        uiPanel.SetActive(false);
    }

    private void LateUpdate()
    {
        var rotation = mainCam.transform.rotation;
        transform.LookAt(transform.position + rotation * Vector3.forward, rotation * Vector3.up);
    }

    public bool isDisplayed = false;
    
    public void SetUp(string _promptText)
    {
        this.promptText.text = _promptText;
        uiPanel.SetActive(true);
        isDisplayed = true;
    }

    public void CloseUI()
    {
        isDisplayed = false;
    }
}
