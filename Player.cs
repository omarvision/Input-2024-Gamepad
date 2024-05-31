using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    public float MoveSpeed = 8f;
    public float TurnSpeed = 120f;
    public float JumpForce = 6f;

    private Rigidbody rb = null;
    private Vector2 move_value;

    private void Start()
    {
        rb = this.GetComponent<Rigidbody>();
    }
    private void Update()
    {
        this.transform.Translate(Vector3.forward * MoveSpeed * move_value.y * Time.deltaTime);
        this.transform.Rotate(this.transform.up * TurnSpeed * move_value.x * Time.deltaTime);
    }
    private void OnJump(InputValue value) //"Player Input" component
    {
        rb.AddRelativeForce(Vector3.up * JumpForce, ForceMode.VelocityChange);
    }
    private void OnMove(InputValue value)  //"Player Input" component
    {
        //this msg receiver only happens when the leftstick changes
        move_value = value.Get<Vector2>();
    }
}
