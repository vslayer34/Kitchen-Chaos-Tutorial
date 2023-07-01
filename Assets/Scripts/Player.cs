using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            Debug.Log("W Pressed!!");
        }
        else
        {
            Debug.Log("-");
        }
    }
}
