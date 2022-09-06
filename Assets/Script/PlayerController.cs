using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed;
    public float turnSpeed;
    public VariableJoystick variableJoystick;
    Vector3 direction;

    public void FixedUpdate()
    {
        Vector3 addedRot = new Vector3(variableJoystick.Horizontal * speed * Time.deltaTime, 0, variableJoystick.Vertical *speed* Time.deltaTime);
        transform.position += addedRot;

        direction = variableJoystick.Horizontal * Vector3.forward + variableJoystick.Vertical * Vector3.right;

        Rotate();

    }

    public void Rotate()
    {
        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(direction), turnSpeed * Time.deltaTime);

    }

    public void RotadeSnap()
    {
        transform.rotation = Quaternion.LookRotation(direction);
    }

    private void StartMove()
    {
        
    }
}
