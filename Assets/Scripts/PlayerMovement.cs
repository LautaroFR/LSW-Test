using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float movementSpeed;

    InputAction moveAction;
    Vector2 direction;

    void Awake()
    {
        moveAction = GetComponent<PlayerInput>().actions["Move"];
    }

    void FixedUpdate()
    {
        MovementUpdate();
    }

    void MovementUpdate()
    {
        direction = moveAction.ReadValue<Vector2>();
        transform.position += new Vector3(direction.x, direction.y, 0) * movementSpeed * Time.deltaTime;
    }
}
