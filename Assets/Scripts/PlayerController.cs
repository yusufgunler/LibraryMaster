using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed;
    public float turnSpeed;
    Vector3 direction;

    public void FixedUpdate()
    {
        Vector3 addedRot = new Vector3(VariableJoystick.Instance.Horizontal * speed * Time.deltaTime, 0, VariableJoystick.Instance.Vertical *speed* Time.deltaTime);
        transform.position += addedRot;

        direction = (Vector3.forward*VariableJoystick.Instance.Vertical   + VariableJoystick.Instance.Horizontal * Vector3.right);

        Rotate();

    }

    public void Rotate()
    {
        if (VariableJoystick.Instance.isTouched)
        {
            transform.rotation = (Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(direction), turnSpeed * Time.deltaTime));

            Debug.Log(direction);
        }

    }

    public void RotadeSnap()
    {
        transform.rotation = Quaternion.LookRotation(direction);
    }

    private void StartMove()
    {
        
    }

}
