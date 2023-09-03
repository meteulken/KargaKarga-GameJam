using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceShipController : MonoBehaviour
{
    public float speed = 5.0f;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // Sola hareket için "A" tuþunu kullan
        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(Vector3.forward * Time.deltaTime * speed);
        }

        // Saða hareket için "D" tuþunu kulland
        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(-Vector3.forward * Time.deltaTime * speed);
        }
    }
}
