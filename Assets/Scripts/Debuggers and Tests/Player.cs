using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private CharacterController _characterController;
    private IMover _mover;
    private Rotator _rotator;

    public IPlayerInput PlayerInput { get; set; } = new PlayerInput();

    private void Awake()
    {
        _characterController = GetComponent<CharacterController>();
        _mover = new NavMeshMover(this);
        _rotator = new Rotator(this);
    }
    void Start()
    {
        _characterController = GetComponent<CharacterController>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            _mover = new Mover(this);
        }

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            _mover = new NavMeshMover(this);
        } 
        _mover.Tick();
       _rotator.Tick();
    }
}