using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterSensor : MonoBehaviour
{
    public float length_checkground;
    private void Update()
    {
        DebugRaycastCheck(Vector3.down, length_checkground, Color.red);
    }
    public bool isGround()
    {
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.down), length_checkground))
        {
            Debug.Log("isground");
            return true;
        }
        else
        {
            return false;
        }

    }
    public void DebugRaycastCheck(Vector3 _direction, float _length, Color _color)
    {
        Debug.DrawRay(transform.position, transform.TransformDirection(_direction) * _length, _color);
    }

}
