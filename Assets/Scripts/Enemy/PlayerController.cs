using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public GameObject Prefab;
    public float delay = 0.3f; // Ýstenilen gecikme süresi
    private float lastTimePressed = -1.0f; // Son basýlma zamaný

    // Update is called once per frame
    void Update()
    {
        // On spacebar press, send dog
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (Time.time - lastTimePressed >= delay)
            {
                // Tuþa basýldýðýnda ve gecikme süresi geçtiðinde burasý çalýþýr
                lastTimePressed = Time.time;
                // Burada yapmak istediðiniz iþlemleri gerçekleþtirebilirsiniz
                Instantiate(Prefab, transform.position, Prefab.transform.rotation);
            }
        }
    }
}