using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class ActionController : MonoBehaviour
{
    public GameObject character;
    private ActionBasedController controller;

    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<ActionBasedController>();

        
    }

    private void ActionPerformed(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        character.GetComponent<CharacterMovement>().Jump();
    }

    private void MovementPerformed(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        Vector2 vec2 = controller.translateAnchorAction.action.ReadValue<Vector2>();
        Vector3 vec3 = transform.TransformDirection(new Vector3(vec2.x, 0.0f, vec2.y));
        vec2.x = vec3.x;
        vec2.y = vec3.z;
        character.GetComponent<CharacterMovement>().MoveCharacter(vec2);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        controller.translateAnchorAction.action.performed += MovementPerformed;

        controller.activateAction.action.performed += ActionPerformed;
    }
}
