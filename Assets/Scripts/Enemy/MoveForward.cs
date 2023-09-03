using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveForward : MonoBehaviour
{
    public float speed;
    private Vector3 spawnPos = new Vector3(-1, 0, 0);
    // Update is called once per frame
    void Update()
    {
        transform.Translate(spawnPos * speed * Time.deltaTime);
    }
}