using UnityEngine;
using UnityEngine.SceneManagement;

public class playermovment1 : MonoBehaviour
{
    public float speed = 5f;
    public bool GameOver = false;
    public GameObject gameOverObj;

    // حدود الشاشة
    public float minX, maxX, minY, maxY;

    void Update()
    {
        // لو حصل جيم أوفر، نوقف الحركة ونظهر الشاشة
        if (GameOver)
        {
            if (gameOverObj != null && !gameOverObj.activeSelf)
            {
                gameObject.GetComponent<SpriteRenderer>().enabled = false;
                gameOverObj.SetActive(true);
            }
            return; 
        }

        // 1. استقبال الحركة بالأربع اتجاهات
        float moveX = Input.GetAxis("Horizontal");
        float moveY = Input.GetAxis("Vertical");

        Vector2 movement = new Vector2(moveX, moveY);
        
        // تحريك اللاعب
        transform.Translate(movement * speed * Time.deltaTime, Space.World);

        // 2. توجيه بوش السفينة في اتجاه الحركة (فوق، تحت، يمين، شمال، والزوايا بينهم)
        if (movement != Vector2.zero)
        {
            // حساب الزاوية بناءً على اتجاه الـ X والـ Y
            float angle = Mathf.Atan2(movement.y, movement.x) * Mathf.Rad2Deg;
            
            // بنطرح 90 درجة لو كانت رسمة السفينة في الأصل باصة لفوق (Default Sprite Up)
            // لو رسمة السفينة باصة لليمين في الأصل، امسح الـ - 90 دي
            Quaternion targetRotation = Quaternion.Euler(new Vector3(0, 0, angle - 90f));
            
            // لفة سلسة وناعمة بدل ما تقلب فجأة
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, 15f * Time.deltaTime);
        }

        // 3. تطبيق حدود الشاشة عشان اللاعب مايطلعش بره
        Vector3 clampedPosition = transform.position;
        clampedPosition.x = Mathf.Clamp(clampedPosition.x, minX, maxX);
        clampedPosition.y = Mathf.Clamp(clampedPosition.y, minY, maxY);
        transform.position = clampedPosition;
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            GameOver = true;
        }
    }

    public void RESTART()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}