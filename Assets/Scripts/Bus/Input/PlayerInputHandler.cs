using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.InputSystem;

public class PlayerInputHandler : MonoBehaviour
{
    [SerializeField]
    GameObject controlHint;
    public float HorizontalInput { private set; get; }
    void Start()
    {

    }

    public void OnMoveInput(InputAction.CallbackContext context)
    {
        HorizontalInput = context.ReadValue<float>();
    }
}
