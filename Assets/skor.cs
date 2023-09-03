using UnityEngine;

public class skor : MonoBehaviour
{
    public int skorValue;

    // Start is called before the first frame update
    void Start()
    {
        skorValue = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (skorValue >= 3) // Skor 3 veya daha fazla ise
        {
            Debug.Log("Kazandýnýz");
        }
    }
}
