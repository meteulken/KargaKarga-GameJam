using UnityEngine;

public class DetectCollisionsX : MonoBehaviour
{
    private void Start()
    {
        
    }
    private void Update()
    {

    }
    private void OnTriggerEnter(Collider other)
    {
        // Nesnenin üzerinde skor scriptine eriþ

        Destroy(gameObject); // Nesneyi yok et
    }
}
