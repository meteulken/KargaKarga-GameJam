using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFire : MonoBehaviour
{
    public GameObject Prefab;
    public float delay = 0.3f; // Ýstenilen gecikme süresi
    private float lastTimePressed = -1.0f; // Son basýlma zamaný
    public float spawnDistance = 15.0f; // Nesnenin spawn edileceði mesafe
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
                // Tuþa basýldýðýnda ve gecikme süresi geçtiðinde burasý çalýþýr
                lastTimePressed = Time.time;

                // Yeni nesneyi nesnenizin forward yönünde spawn et
                Vector3 spawnPosition = transform.position + transform.forward * spawnDistance + yuksek;
                Instantiate(Prefab, spawnPosition, Prefab.transform.rotation);
            }
        }
    }
}
