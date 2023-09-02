using UnityEngine;
using UnityEngine.UI;

public class ObjectSlider : MonoBehaviour
{
    public Transform rightPosition;
    public Transform leftPosition;
    public Button sliderButton;
    public float slideSpeed = 5f;

    private Vector3 targetPosition;
    private Vector3 initialPosition;

    void Start()
    {
        initialPosition = sliderButton.transform.position;
        targetPosition = leftPosition.position; // Baþlangýçta sola doðru hareket edecek
        sliderButton.onClick.AddListener(ToggleDirection);
    }

    void Update()
    {
        float step = slideSpeed * Time.deltaTime;
        sliderButton.transform.position = Vector3.MoveTowards(sliderButton.transform.position, targetPosition, step);

        if (Vector3.Distance(sliderButton.transform.position, targetPosition) < 0.001f)
        {
            ToggleDirection();
        }
    }

    void ToggleDirection()
    {
        // Hedef pozisyonunu deðiþtir
        targetPosition = (targetPosition == leftPosition.position) ? rightPosition.position : leftPosition.position;
    }
}
