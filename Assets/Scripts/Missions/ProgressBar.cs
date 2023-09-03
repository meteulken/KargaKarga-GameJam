using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ProgressBar : MonoBehaviour
{
    public Slider progressBar;
    private float currentValue = 10f;
    public float decreaseAmount = 5f;
    public float decreaseInterval = 5f;
    private bool isDecreasing = false;
    public CupCollision cupCollisionScript;
    public bool IsEPressed { get; private set; }

    private void Start()
    {
        if (progressBar != null)
        {
            progressBar.value = currentValue;
        }

        // Ba�lang��ta azalma i�lemini ba�lat
        StartDecreasing();
    }

    private void Update()
    {
        // E tu�una bas�ld���nda ProgressBar'� 10 birim art�r
        if (Input.GetKeyDown(KeyCode.E) && cupCollisionScript)
        {
            IncreaseProgressBar(10f);
            IsEPressed = true; // "E" tu�una bas�ld���nda true yap
        }
        else
        {
            IsEPressed = false; // "E" tu�una bas�lmad���nda veya �arp��ma olmad���nda false yap
        }
    }

    public void IncreaseProgressBar(float amount)
    {
        if (progressBar != null)
        {
            // Progress bar�n de�erini art�r, ancak maksimum de�eri a�ma
            progressBar.value = Mathf.Clamp(progressBar.value + amount, 0f, progressBar.maxValue);
        }
    }

    private IEnumerator DecreaseProgressBar()
    {
        while (currentValue > 0f)
        {
            // Belirli bir s�re bekle
            yield return new WaitForSeconds(decreaseInterval);

            // ProgressBar'� belirli bir miktar azalt
            currentValue = Mathf.Clamp(currentValue - decreaseAmount, 0f, progressBar.maxValue);

            // ProgressBar'�n de�erini g�ncelle
            progressBar.value = currentValue;
        }
    }

    public void StartDecreasing()
    {
        if (!isDecreasing)
        {
            // Coroutine'i ba�lat
            StartCoroutine(DecreaseProgressBar());
            isDecreasing = true;
        }
    }
}
