using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSwitcher : MonoBehaviour
{
    public Camera mainCamera; // Ana kamera
    public Camera secondaryCamera; // Ýkincil kamera

    private void OnTriggerEnter(Collider other)
    {
        // Tetikleyici bölgeye baþka bir nesne girdiðinde çalýþýr
        if (other.CompareTag("Player")) // Sadece "Player" etiketine sahip nesneleri kontrol eder
        {
            mainCamera.enabled = false; // Ana kamerayý kapat
            secondaryCamera.enabled = true; // Ýkincil kamerayý aç

          
        }
    }
}
