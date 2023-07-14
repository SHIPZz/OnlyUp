using System;
using System.Collections;
using System.Collections.Generic;
using Invector.vCharacterController;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.CrossPlatformInput.PlatformSpecific;

public class TestInput : MonoBehaviour
{
    [SerializeField] private Button _jump;
    [SerializeField] private Button _run;

   [SerializeField] private vThirdPersonInput _thirdPersonController;
   

    private void Start()
    {
        _run.onClick.AddListener(_thirdPersonController.MoveInput);
        _jump.onClick.AddListener(Jump);
    }
    
    public Vector2 GetAxis() => 
        new(SimpleInput.GetAxis("Horizontal"), SimpleInput.GetAxis("Vertical"));

    private void Update()
    {
        float horizontal = SimpleInput.GetAxis("Horizontal");
        float vertical = SimpleInput.GetAxis("Vertical");

        Vector3 move = new Vector3(horizontal, 0, vertical);
        
        if(move == Vector3.zero)
            return;

        _thirdPersonController.cc.MoveToPosition(move);
        _thirdPersonController.cc.input.x = horizontal;
        _thirdPersonController.cc.input.z = vertical;
    }

    private void Jump()
    {
        _thirdPersonController.cc.Jump(true);
    }
}