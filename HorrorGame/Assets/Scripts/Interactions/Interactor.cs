using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Serialization;

public class Interactor : MonoBehaviour
{
    [SerializeField] private Transform interactionPoint;
    [SerializeField] private float interactionPointRadius = 0.5f;
    [SerializeField] private LayerMask interactableMask;
    [SerializeField] private InteractionPromptUI interactionPromptUI;
    
    private readonly Collider[] _colliders = new Collider[3];
    [SerializeField] private int numFound;

    private IInteractable _interactable;
    private void Update()
    {
        numFound = Physics.OverlapSphereNonAlloc(interactionPoint.position, interactionPointRadius, _colliders,
            interactableMask);

        if (numFound > 0)
        {
            _interactable = _colliders[0].GetComponent<IInteractable>();

            if (_interactable != null)
            {
                if (!interactionPromptUI.isDisplayed) interactionPromptUI.SetUp(_interactable.InteractionPrompt);

                if (Keyboard.current.fKey.wasPressedThisFrame) _interactable.Interact(this);
            }
            else
            {
                if (_interactable != null) _interactable = null;
                if (interactionPromptUI.isDisplayed) interactionPromptUI.CloseUI();
            }
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(interactionPoint.position, interactionPointRadius);
    }
}
