using UnityEngine;

public class CupMovement : MonoBehaviour
{
    public Transform leftPoint; // Sol pozisyon objesi
    public Transform rightPoint; // Sa� pozisyon objesi
    public GameObject cup; // Sa�a sola hareket edecek olan "cup" objesi

    private float baseMoveSpeed = 8.0f; // Ba�lang�� h�z�
    private float currentMoveSpeed; // Ge�erli h�z
    private float speedIncreaseAmount = 2.5f; // H�z art�� miktar�

    private Vector2 targetPosition; // Hedef pozisyon
    private bool movingRight = true; // Sa�a m� sola m� hareket etmekte oldu�unu belirleyen bayrak

    private void Start()
    {
        // �lk hedef pozisyonu sa�daki pozisyon olarak ayarlay�n
        targetPosition = rightPoint.position;
        currentMoveSpeed = baseMoveSpeed; // Ge�erli h�z� ba�lang�� h�z�na ayarlay�n
    }

    private void Update()
    {
        // "cup" objesini hedef pozisyona do�ru hareket ettirin
        cup.transform.position = Vector2.MoveTowards(cup.transform.position, targetPosition, currentMoveSpeed * Time.deltaTime);

        // "cup" hedef pozisyona ula�t���nda y�n�n� de�i�tirin
        if ((Vector2)cup.transform.position == targetPosition)
        {
            if (movingRight)
            {
                targetPosition = (Vector2)leftPoint.position; // Sol pozisyona git
            }
            else
            {
                targetPosition = (Vector2)rightPoint.position; // Sa� pozisyona git
            }

            movingRight = !movingRight; // Y�n� tersine �evir
        }
    }

    // H�z� art�rmak i�in kullan�lacak fonksiyon
    public void IncreaseSpeed()
    {
        currentMoveSpeed += speedIncreaseAmount;
    }
}
