using UnityEngine;

public class CameraSwitcher : MonoBehaviour
{
    public Camera mainCamera; // Ana kamera
    public Camera secondaryCamera; // Ýkincil kamera

    private bool isMainCameraActive = true; // Baþlangýçta ana kamera aktif

    private void Start()
    {
        // Baþlangýçta ikincil kamerayý devre dýþý býrak
        secondaryCamera.enabled = false;
    }

    private void Update()
    {
        // E tuþuna basýldýðýnda kamera deðiþikliði yap
        if (Input.GetKeyDown(KeyCode.E))
        {
            isMainCameraActive = !isMainCameraActive; // Kamera durumunu deðiþtir

            // Kameralarý etkinleþtirme ve devre dýþý býrakma
            mainCamera.enabled = isMainCameraActive;
            secondaryCamera.enabled = !isMainCameraActive;
        }
    }
}
