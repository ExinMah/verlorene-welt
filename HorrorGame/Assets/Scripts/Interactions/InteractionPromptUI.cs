using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.Burst.CompilerServices;
using UnityEngine;
using UnityEngine.Serialization;

public class InteractionPromptUI : MonoBehaviour
{
    public static bool textOn = false;
    public static string promptTextMessage;
    private float timer = 0.0f;
    private TextMeshProUGUI promptText;

    private void Start()
    {
        promptText = GetComponent<TextMeshProUGUI>();
        textOn = false;
        promptText.text = "";
    }

    private void Update()
    {
        if (textOn)
        {
            Debug.Log("Text is on");
            promptText.enabled = true;
            promptText.text = promptTextMessage;
        }
        else
        {
            promptText.enabled = false;
        }
    }
}
