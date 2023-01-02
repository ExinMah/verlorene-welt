using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TypewriterEffectUI : MonoBehaviour
{
    private TMP_Text _text;
    private string writer;
    
    [SerializeField] private AudioClip audioClip;
    private AudioSource _audioSource;

    [SerializeField] private float delayBeforeStart = 0.0f;
    [SerializeField] private float timeBetweenChars = 0.1f;
    [SerializeField] private string leadingChar = "";
    [SerializeField] private bool leadingCharBeforeDelay = false;
    
    // Start is called before the first frame update
    void Start()
    {
        _text = GetComponent<TMP_Text>()!;

        if (_text != null)
        {
            writer = _text.text;
            _text.text = "";

            StartCoroutine(TypeWriter());
        }
        
    }

    IEnumerator TypeWriter()
    {
        _text.text = leadingCharBeforeDelay ? leadingChar : "";

        yield return new WaitForSeconds(delayBeforeStart);
        
        
        foreach (char c in writer)
        {
            if (_text.text.Length > 0)
            {
                _text.text = _text.text.Substring(0, _text.text.Length - leadingChar.Length);
            }

            _text.text += c;
            _text.text += leadingChar;
            yield return new WaitForSeconds(timeBetweenChars);
        }

        if (leadingChar != "")
        {
            _text.text = _text.text.Substring(0, _text.text.Length - leadingChar.Length);
        }
    }
}
