using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireMove : MonoBehaviour
{
    public float speed1;
    private Vector3 moveDirection;
    public Transform target;

    // Update is called once per frame
    void Update()
    {
        moveDirection = (target.transform.position - transform.position).normalized;
        // Sadece x ekseninde ileri gitmesi i�in Vector3.right kullan�yoruz
        transform.Translate(target.up * speed1 * Time.deltaTime);


    }
}
