using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class ActionController : MonoBehaviour
{
    public GameObject character;
    public GameObject arrow;
    private ActionBasedController controller;

    private void Awake()
    {
        arrow.GetComponent<ArrowMovement>().SetEnabled(false);
    }

    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<ActionBasedController>();

        
    }

    private void ActionPerformed(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        character.GetComponent<CharacterMovement>().Jump();
    }

    private void MovementStarted(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        arrow.GetComponent<ArrowMovement>().SetEnabled(true);
    }

    private void MovementPerformed(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        Vector2 vec2 = controller.translateAnchorAction.action.ReadValue<Vector2>();
        Vector3 vec3 = transform.TransformDirection(new Vector3(vec2.x, 0.0f, vec2.y));
        vec2.x = vec3.x;
        vec2.y = vec3.z;
        character.GetComponent<CharacterMovement>().SetMovement(vec2);
        arrow.GetComponent<ArrowMovement>().FacePosition(vec2);
    }

    private void MovementCanceled(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        arrow.GetComponent<ArrowMovement>().SetEnabled(false);
        character.GetComponent<CharacterMovement>().SetMovement(controller.translateAnchorAction.action.ReadValue<Vector2>());
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        controller.translateAnchorAction.action.started += MovementStarted;
        controller.translateAnchorAction.action.performed += MovementPerformed;
        controller.translateAnchorAction.action.canceled += MovementCanceled;

        controller.activateAction.action.performed += ActionPerformed;

        
    }
}
