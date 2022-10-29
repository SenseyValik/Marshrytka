using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bus : MonoBehaviour
{
    PlayerInputHandler PlayerInputHandler;
    void Start()
    {
        PlayerInputHandler = GameObject.Find("InputHandler").GetComponent<PlayerInputHandler>();
    }

    // Update is called once per frame
    void Update()
    {
        float horizontalMovementInput = PlayerInputHandler.HorizontalInput;
        if (horizontalMovementInput > 0) Debug.Log("D");
        else if (horizontalMovementInput < 0) Debug.Log("A");
    }
}   
