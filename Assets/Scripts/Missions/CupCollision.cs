using UnityEngine;

public class CupCollision : MonoBehaviour
{
    private bool cupsCollided = false;
    public GameObject cupToMove;
    public ProgressBar progressBarScript; // ProgressBar scriptini buraya s�r�kleyin.

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && cupsCollided)
        {
            float newXPosition = Random.Range(-14f, 14f);
            Vector3 newPosition = new Vector3(newXPosition, cupToMove.transform.position.y, cupToMove.transform.position.z);
            cupToMove.transform.position = newPosition;

            Debug.Log("E tu�una bas�ld� ve iki Cup �arp��t�!");

            // Progress bar� art�rmak i�in ProgressBar scriptini kullan
            if (progressBarScript != null)
            {
                progressBarScript.IncreaseProgressBar(10f);
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Cup"))
        {
            cupsCollided = true;
            CupMovement cupMovementScript = collision.gameObject.GetComponent<CupMovement>();
            if (cupMovementScript != null)
            {
                cupMovementScript.IncreaseSpeed();
            }
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Cup"))
        {
            cupsCollided = false;
        }
    }
}
