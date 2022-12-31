using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(AudioSource))]

public class DoorInteraction : MonoBehaviour
{
    [SerializeField] private string openPromptText = "Press [F] to open door";
    [SerializeField] private string closePromptText = "Press [F] to close door";
    [SerializeField] private string lockedPromptText = "The door seems to be locked";
    
    private string boolText = "isDoorOpen";
    private string unlockedDoorTag = "UnlockedDoor";
    private string lockDoorTag = "LockedDoor";
    
    private bool isDoorOpen = false;
    private bool openDoor = false;
    private bool closeDoor = false;
    private GameObject currentDoor;

    public AudioClip doorOpenSound;
    public AudioClip doorCloseSound;


    private void Start()
    {
    }

    public void SetCurrentDoor(GameObject obj)
    {
        currentDoor = obj;
    }
    
    private void Update()
    {
        if (Keyboard.current[Key.F].wasPressedThisFrame)
        {
            Debug.Log("F key was pressed");

            if (!isDoorOpen)
            {
                Door(doorOpenSound, true, true, currentDoor);
            }
            else
            {
                Door(doorCloseSound, false, false, currentDoor);
            }
        }
    }

    public void OpenDoor(RaycastHit hit)
    {
        if (hit.collider.gameObject.tag == unlockedDoorTag && !isDoorOpen)
        {
            currentDoor = hit.collider.gameObject;
            InteractionPromptUI.promptTextMessage = openPromptText;
            InteractionPromptUI.textOn = true;
        }
        else if (hit.collider.gameObject.tag == lockDoorTag && !isDoorOpen)
        {
            InteractionPromptUI.promptTextMessage = lockedPromptText;
            InteractionPromptUI.textOn = true;
        }
    }

    public void CloseDoor(RaycastHit hit)
    {
        if (isDoorOpen)
        {
            currentDoor = hit.collider.gameObject;
            InteractionPromptUI.textOn = true;
            InteractionPromptUI.promptTextMessage = closePromptText;
        }
    }

    public void Door(AudioClip audioClip, bool openCheck, bool doorIsOpen, GameObject thisDoor)
    {
        AudioSource audio = GetComponent<AudioSource>();
        audio.clip = audioClip;
        audio.Play();
        isDoorOpen = openCheck;
        thisDoor.GetComponent<Animator>().SetBool(boolText, doorIsOpen);
    }
}
