using UnityEngine;

public class CameraSwitcher : MonoBehaviour
{
    public Camera mainCamera; // Ana kamera
    public Camera secondaryCamera; // �kincil kamera

    private bool isMainCameraActive = true; // Ba�lang��ta ana kamera aktif

    private void Start()
    {
        // Ba�lang��ta ikincil kameray� devre d��� b�rak
        secondaryCamera.enabled = false;
    }

    private void Update()
    {
        // E tu�una bas�ld���nda kamera de�i�ikli�i yap
        if (Input.GetKeyDown(KeyCode.E))
        {
            isMainCameraActive = !isMainCameraActive; // Kamera durumunu de�i�tir

            // Kameralar� etkinle�tirme ve devre d��� b�rakma
            mainCamera.enabled = isMainCameraActive;
            secondaryCamera.enabled = !isMainCameraActive;
        }
    }
}
