using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyEnemy : MonoBehaviour
{
    private float leftLimit = -45;
    private float bottomLimit = 0;

    // Update is called once per frame
    void Update()
    {
        // Destroy dogs if x position less than left limit
        if (transform.position.x < 5)
        {
            Debug.Log("Game Over!");
        }
        // Destroy balls if y position is less than bottomLimit
        //else if (transform.position.y < bottomLimit)
        //{
        //    Debug.Log("Game Over!");
        //    Destroy(gameObject);
        //}

    }
}