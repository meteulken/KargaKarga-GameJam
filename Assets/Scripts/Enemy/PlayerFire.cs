using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFire : MonoBehaviour
{
    public GameObject Prefab;
    public float delay = 0.3f; // �stenilen gecikme s�resi
    private float lastTimePressed = -1.0f; // Son bas�lma zaman�
    public float spawnDistance = 15.0f; // Nesnenin spawn edilece�i mesafe
    public Vector3 yuksek;

    private void Start()
    {
       
    }

    private void Update()
    {
        // On spacebar press, send dog
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (Time.time - lastTimePressed >= delay)
            {
                // Tu�a bas�ld���nda ve gecikme s�resi ge�ti�inde buras� �al���r
                lastTimePressed = Time.time;

                // Yeni nesneyi nesnenizin forward y�n�nde spawn et
                Vector3 spawnPosition = transform.position + transform.forward * spawnDistance + yuksek;
                Instantiate(Prefab, spawnPosition, Prefab.transform.rotation);
            }
        }
    }
}
