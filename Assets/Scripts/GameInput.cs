using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameInput : MonoBehaviour
{
    public Vector2 GetInputVectorNormalized()
    {
        Vector2 inputVector = new Vector2(0.0f, 0.0f);

        if (Input.GetKey(KeyCode.W))
        {
            inputVector.y = 1.0f;
        }
        if (Input.GetKey(KeyCode.S))
        {
            inputVector.y = -1.0f;
        }
        if (Input.GetKey(KeyCode.D))
        {
            inputVector.x = 1.0f;
        }
        if (Input.GetKey(KeyCode.A))
        {
            inputVector.x = -1.0f;
        }

        return inputVector.normalized;
    }
}
