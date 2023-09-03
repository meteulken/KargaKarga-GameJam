using UnityEngine;

public class CupMovement : MonoBehaviour
{
    public Transform leftPoint; // Sol pozisyon objesi
    public Transform rightPoint; // Sað pozisyon objesi
    public GameObject cup; // Saða sola hareket edecek olan "cup" objesi

    private float baseMoveSpeed = 8.0f; // Baþlangýç hýzý
    private float currentMoveSpeed; // Geçerli hýz
    private float speedIncreaseAmount = 2.5f; // Hýz artýþ miktarý

    private Vector2 targetPosition; // Hedef pozisyon
    private bool movingRight = true; // Saða mý sola mý hareket etmekte olduðunu belirleyen bayrak

    private void Start()
    {
        // Ýlk hedef pozisyonu saðdaki pozisyon olarak ayarlayýn
        targetPosition = rightPoint.position;
        currentMoveSpeed = baseMoveSpeed; // Geçerli hýzý baþlangýç hýzýna ayarlayýn
    }

    private void Update()
    {
        // "cup" objesini hedef pozisyona doðru hareket ettirin
        cup.transform.position = Vector2.MoveTowards(cup.transform.position, targetPosition, currentMoveSpeed * Time.deltaTime);

        // "cup" hedef pozisyona ulaþtýðýnda yönünü deðiþtirin
        if ((Vector2)cup.transform.position == targetPosition)
        {
            if (movingRight)
            {
                targetPosition = (Vector2)leftPoint.position; // Sol pozisyona git
            }
            else
            {
                targetPosition = (Vector2)rightPoint.position; // Sað pozisyona git
            }

            movingRight = !movingRight; // Yönü tersine çevir
        }
    }

    // Hýzý artýrmak için kullanýlacak fonksiyon
    public void IncreaseSpeed()
    {
        currentMoveSpeed += speedIncreaseAmount;
    }
}
