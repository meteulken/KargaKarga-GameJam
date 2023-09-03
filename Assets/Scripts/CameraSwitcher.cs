using UnityEngine;

public class CameraSwitcher : MonoBehaviour
{
    public Camera mainCamera; // Ana kamera
    public Camera secondaryCamera; // �kincil kamera
    private bool isMainCameraActive = true; // Ba�lang��ta ana kamera aktif
    private bool control = false; // Kontrol durumu
    private bool pressE = false; // E tu�una bas�ld� m�?
    public GameObject player; // Oyuncu
    public GameObject cub1; // K�p 1
    public GameObject cub2; // K�p 2
    public GameObject cub3; // K�p 3
    public GameObject cub4; // K�p 4


    private void Start()
    {
        // Kameralar� etkinle�tirme ve devre d��� b�rakma
        mainCamera.enabled = true;
        secondaryCamera.enabled = false;
    }

    private void Update()
    {
        // E tu�una bas�ld���nda kamera de�i�ikli�i yap
        if (Input.GetKeyDown(KeyCode.E) && control)
        {
            cub1.SetActive(true);
            cub2.SetActive(true);
            cub3.SetActive(true);
            cub4.SetActive(true);

            pressE = true;
            ToggleCameras();

        }
        if(pressE == true && Input.GetKeyDown(KeyCode.E))
        {
            cub1.SetActive(false);
            cub2.SetActive(false);
            cub3.SetActive(false);
            cub4.SetActive(false);

        }

    }

    private void OnCollisionEnter(Collision collision)
    {
        // �arp��ma ger�ekle�ti�inde kamera de�i�ikli�i yap
        if (collision.gameObject.CompareTag("Player"))
        {
            control = true;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        // �arp��ma ger�ekle�ti�inde kamera de�i�ikli�i yap
        if (other.gameObject.CompareTag("Player"))
        {
            control = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        // �arp��ma sona erdi�inde kontrol durumunu s�f�rla
        if (other.gameObject.CompareTag("Player"))
        {
            control = false;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        // �arp��ma sona erdi�inde kontrol durumunu s�f�rla
        if (collision.gameObject.CompareTag("Player"))
        {
            control = false;
        }
    }

    private void ToggleCameras()
    {
        isMainCameraActive = !isMainCameraActive; // Kamera durumunu de�i�tir

        // Kameralar� etkinle�tirme ve devre d��� b�rakma
        mainCamera.enabled = isMainCameraActive;
        secondaryCamera.enabled = !isMainCameraActive;
    }

    
}
