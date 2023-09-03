using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public GameObject Prefab;
    public float delay = 0.3f; // �stenilen gecikme s�resi
    private float lastTimePressed = -1.0f; // Son bas�lma zaman�

    // Update is called once per frame
    void Update()
    {
        // On spacebar press, send dog
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (Time.time - lastTimePressed >= delay)
            {
                // Tu�a bas�ld���nda ve gecikme s�resi ge�ti�inde buras� �al���r
                lastTimePressed = Time.time;
                // Burada yapmak istedi�iniz i�lemleri ger�ekle�tirebilirsiniz
                Instantiate(Prefab, transform.position, Prefab.transform.rotation);
            }
        }
    }
}