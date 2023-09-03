using UnityEngine;

public class CameraSwitcher : MonoBehaviour
{
    public Camera mainCamera; // Ana kamera
    public Camera secondaryCamera; // Ýkincil kamera
    private bool isMainCameraActive = true; // Baþlangýçta ana kamera aktif
    private bool control = false; // Kontrol durumu
    private bool pressE = false; // E tuþuna basýldý mý?
    public GameObject player; // Oyuncu
    public GameObject cub1; // Küp 1
    public GameObject cub2; // Küp 2
    public GameObject cub3; // Küp 3
    public GameObject cub4; // Küp 4


    private void Start()
    {
        // Kameralarý etkinleþtirme ve devre dýþý býrakma
        mainCamera.enabled = true;
        secondaryCamera.enabled = false;
    }

    private void Update()
    {
        // E tuþuna basýldýðýnda kamera deðiþikliði yap
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
        // Çarpýþma gerçekleþtiðinde kamera deðiþikliði yap
        if (collision.gameObject.CompareTag("Player"))
        {
            control = true;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        // Çarpýþma gerçekleþtiðinde kamera deðiþikliði yap
        if (other.gameObject.CompareTag("Player"))
        {
            control = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        // Çarpýþma sona erdiðinde kontrol durumunu sýfýrla
        if (other.gameObject.CompareTag("Player"))
        {
            control = false;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        // Çarpýþma sona erdiðinde kontrol durumunu sýfýrla
        if (collision.gameObject.CompareTag("Player"))
        {
            control = false;
        }
    }

    private void ToggleCameras()
    {
        isMainCameraActive = !isMainCameraActive; // Kamera durumunu deðiþtir

        // Kameralarý etkinleþtirme ve devre dýþý býrakma
        mainCamera.enabled = isMainCameraActive;
        secondaryCamera.enabled = !isMainCameraActive;
    }

    
}
