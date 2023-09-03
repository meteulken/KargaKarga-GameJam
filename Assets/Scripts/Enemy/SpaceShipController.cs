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
        // Sola hareket i�in "A" tu�unu kullan
        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(Vector3.forward * Time.deltaTime * speed);
        }

        // Sa�a hareket i�in "D" tu�unu kulland
        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(-Vector3.forward * Time.deltaTime * speed);
        }
    }
}
