using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlickerControl : MonoBehaviour
{
    public bool isFlickering = false;
    public float timeDelay;
    public float lowerOffRange = 0.01f;
    public float upperOffRange = 0.5f;
    public float lowerOnRange = 0.01f;
    public float upperOnRange = 0.5f;
    
    void Update()
    {
        if (!isFlickering)
        {
            StartCoroutine(FlickeringLight());
        }
    }

    IEnumerator FlickeringLight()
    {
        isFlickering = true;
        this.gameObject.GetComponent<Light>().enabled = false;
        timeDelay = Random.Range(lowerOffRange, upperOffRange);
        yield return new WaitForSeconds(timeDelay);
        this.gameObject.GetComponent<Light>().enabled = true;
        timeDelay = Random.Range(lowerOnRange, upperOnRange);
        yield return new WaitForSeconds(timeDelay);
        isFlickering = false;
    }
}
