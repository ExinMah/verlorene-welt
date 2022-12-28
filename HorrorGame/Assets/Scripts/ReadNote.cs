using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]

public class ReadNote : MonoBehaviour
{
    public Camera cam;
    public GameObject player;
    public GameObject noteUI;
    //public MouseLook mouseLook;

    public GameObject pickUpText;
    public GameObject closeNoteText;
    public AudioClip pickUpSound;

    public bool isCollide;

    // Start is called before the first frame update
    void Start()
    {
        //noteUI.SetActive(false);
        pickUpText.SetActive(false);

        isCollide = false;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Collide")
        {
            isCollide = true;
            pickUpText.SetActive(true);
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Collide")
        {
            isCollide = false;
            pickUpText.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Interact") && isCollide)
        {
            Debug.Log("Pressed F");
           // mouseLook.enabled = false;
            noteUI.SetActive(true);

            closeNoteText.SetActive(true);
            Debug.Log("note displayed");
            pickUpText.SetActive(false);
            playPickUpSound();
            //player.GetComponent<FirstPersonController>();
            //Debug.Log("freeze walk");

            //cam.GetComponent<Camera>().enabled = false;
            //Cursor.visible = true;
            //Cursor.lockState = CursorLockMode.None;
        }
        if (Input.GetButtonDown("NotInteract") && noteUI == true)
        {
            Debug.Log("disable note");
            //mouseLook.enabled = true;
            noteUI.SetActive(false);
            closeNoteText.SetActive(false);
        }

    }

    public void BackButton()
    {
        noteUI.SetActive(false);
        cam.GetComponent<Camera>().enabled = true;
    }

    void playPickUpSound()
    {
        AudioSource audio = GetComponent<AudioSource>();
        audio.clip = pickUpSound;
        audio.Play();
    }
}
