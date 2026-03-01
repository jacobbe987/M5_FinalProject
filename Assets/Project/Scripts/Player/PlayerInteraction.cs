using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    private I_InteractableObj _interactableObj;

    [SerializeField] private float _maxDistanceToInteraction;
    [SerializeField] private GameObject _interactionCanvas;
    [SerializeField] private TextMeshProUGUI _interactionText;
    [SerializeField] private LayerMask _interactableLayer;


    private void Update()
    {
        CheckInteractable();
        if(_interactableObj != null && Input.GetKeyDown(KeyCode.F))
        {
            _interactableObj.Interact();
        } 
    }
    private void CheckInteractable()
    {
        Ray ray = new Ray(transform.position, transform.forward);
        RaycastHit hit;

        if(Physics.Raycast(ray, out hit,_maxDistanceToInteraction,_interactableLayer))
        {
            I_InteractableObj interactable = hit.collider.GetComponent<I_InteractableObj>();

            if(interactable != null)
            {
                _interactableObj = interactable;
                _interactionCanvas.SetActive(true);
                _interactionText.text = _interactableObj.InteractableText();
                return;
            }
        }

        _interactableObj = null;
        _interactionCanvas.SetActive(false);
    }
}
