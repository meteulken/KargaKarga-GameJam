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
        // Nesnenin �zerinde skor scriptine eri�

        Destroy(gameObject); // Nesneyi yok et
    }
}
