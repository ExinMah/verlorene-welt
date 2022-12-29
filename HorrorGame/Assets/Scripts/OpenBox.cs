using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenBox : MonoBehaviour
{

    public Animator box;
    public GameObject openBoxText;
    public GameObject closeBoxText;

    public AudioClip boxOpenSound;
    public AudioClip boxCloseSound;

    public bool isCollide;

    // Start is called before the first frame update
    void Start()
    {
        isCollide = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (isCollide && Input.GetButtonDown("Interact"))
        {
            Debug.Log("Pressed F to open");
            BoxOpen();

        }
        else if (isCollide && box.GetBool("isOpen")/* && Input.GetButtonDown("Interact")*/)
        {
            Debug.Log("Box is open");
            openBoxText.SetActive(false);
            closeBoxText.SetActive(true);
            Debug.Log("Showed close text");

            if (Input.GetButtonDown("NotInteract"))
            {
                Debug.Log("Pressed F to close");
                BoxClose();
            }


        }
        //else
        //{
        //    CrateClose();
        //}
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Collide")
        {
            isCollide = true;
            Debug.Log("Collide enter with box");
            openBoxText.SetActive(true);
            Debug.Log("open box Text displayed");
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Collide")
        {
            isCollide = false;
            Debug.Log("exit collided");
            openBoxText.SetActive(false);
            Debug.Log("open box Text disappeared");

            closeBoxText.SetActive(false);
            
           
        }
    }

    void BoxOpen()
    {
        box.SetBool("isOpen", true);
        Debug.Log("Open box!");
        AudioSource audio = GetComponent<AudioSource>();
        audio.clip = boxOpenSound;
        audio.Play();
        Debug.Log("Open box sound");
    }

    void BoxClose()
    {
        box.SetBool("isOpen", false);
        Debug.Log("Close box!");
        AudioSource audio = GetComponent<AudioSource>();
        audio.clip = boxCloseSound;
        audio.Play();
        Debug.Log("Close box sound");
    }
}
