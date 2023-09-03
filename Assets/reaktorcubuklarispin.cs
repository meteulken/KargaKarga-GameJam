using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class reaktorcubuklarispin : MonoBehaviour
{
    public float rotationSpeed = 250f;

    private void Update()
    {
        // Nesnenin Z rotasyonunu arttýrma
        transform.Rotate(0f, -rotationSpeed * Time.deltaTime, 0f );
    }
}
