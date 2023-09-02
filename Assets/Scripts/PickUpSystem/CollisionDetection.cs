using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionLogger : MonoBehaviour
{
    public Transform objTransform;
    public GameObject targetObject; // Hedef objeyi Unity Inspector'dan atayýn
    private bool isCollided = false;

    void Start()
    {
        objTransform = GetComponent<Transform>();
    }

    void Update()
    {
        if(isCollided)
        {
            Vector3 objPosition = objTransform.position;
            isCollided = false;
        }
       
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Axe") && gameObject.CompareTag("Mission"))
        {
            Debug.Log("Axe and Mission collided");
            isCollided = true;
            // Hedef objenin konumunu, bu objenin konumuna atayýn
            targetObject.transform.position = objTransform.position;
        }
    }
}
