using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSwitcher : MonoBehaviour
{
    public Camera mainCamera; // Ana kamera
    public Camera secondaryCamera; // �kincil kamera

    private void OnTriggerEnter(Collider other)
    {
        // Tetikleyici b�lgeye ba�ka bir nesne girdi�inde �al���r
        if (other.CompareTag("Player")) // Sadece "Player" etiketine sahip nesneleri kontrol eder
        {
            mainCamera.enabled = false; // Ana kameray� kapat
            secondaryCamera.enabled = true; // �kincil kameray� a�

          
        }
    }
}
