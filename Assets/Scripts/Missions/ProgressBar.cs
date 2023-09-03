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

        // Baþlangýçta azalma iþlemini baþlat
        StartDecreasing();
    }

    private void Update()
    {
        // E tuþuna basýldýðýnda ProgressBar'ý 10 birim artýr
        if (Input.GetKeyDown(KeyCode.E) && cupCollisionScript)
        {
            IncreaseProgressBar(10f);
            IsEPressed = true; // "E" tuþuna basýldýðýnda true yap
        }
        else
        {
            IsEPressed = false; // "E" tuþuna basýlmadýðýnda veya çarpýþma olmadýðýnda false yap
        }
    }

    public void IncreaseProgressBar(float amount)
    {
        if (progressBar != null)
        {
            // Progress barýn deðerini artýr, ancak maksimum deðeri aþma
            progressBar.value = Mathf.Clamp(progressBar.value + amount, 0f, progressBar.maxValue);
        }
    }

    private IEnumerator DecreaseProgressBar()
    {
        while (currentValue > 0f)
        {
            // Belirli bir süre bekle
            yield return new WaitForSeconds(decreaseInterval);

            // ProgressBar'ý belirli bir miktar azalt
            currentValue = Mathf.Clamp(currentValue - decreaseAmount, 0f, progressBar.maxValue);

            // ProgressBar'ýn deðerini güncelle
            progressBar.value = currentValue;
        }
    }

    public void StartDecreasing()
    {
        if (!isDecreasing)
        {
            // Coroutine'i baþlat
            StartCoroutine(DecreaseProgressBar());
            isDecreasing = true;
        }
    }
}
