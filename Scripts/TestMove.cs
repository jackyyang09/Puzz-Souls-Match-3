using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Experimental

public class TestMove : MonoBehaviour
{

    public float MOVE_SPD = 1.0f;

    void Update() {
        if (gameObject.transform.position.x < 0)
            transform.Translate(Vector3.right * MOVE_SPD * Time.deltaTime, Space.World);
    }
}




