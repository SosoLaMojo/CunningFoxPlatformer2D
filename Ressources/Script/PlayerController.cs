using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(PlayerMotor))]

public class PlayerController : MonoBehaviour{

    private PlayerMotor motor;

    void Start()
    {
       motor = GetComponent<PlayerMotor>(); 
    }

    void Update()
    {
        // get value in the axes x and y
        float _x = Input.GetAxisRaw("Horizontal");
        float _y = Input.GetAxisRaw("Jump");

        // get velocity
        Vector2 _velocity = new Vector2 (_x, _y);

        // apply velocity in the player motor
        motor.RunAndJump(_velocity);
       
    }
}
