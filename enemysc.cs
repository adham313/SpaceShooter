using UnityEngine;

public class enemysc : MonoBehaviour
{
    public GameObject target;
    public float speed;

    [Header("Explosion Effect")]
    public GameObject explosionPrefab;

    [Header("Score")]
    public int scoreValue = 10; // كمية السكور اللي بياخدها اللاعب لما يقتل العدو ده

    void Start()
    {
        target = GameObject.FindWithTag("Player");
    }

    void Update()
    {
        if (target != null)
        {
            transform.position = Vector2.MoveTowards(transform.position, target.transform.position, speed * Time.deltaTime);   
        }
    }

    private void OnTriggerEnter2D(Collider2D collistion)
    {
        if (collistion.gameObject.CompareTag("bullet"))
        {
            Destroy(collistion.gameObject);
            Die();
        }
    }

    void Die()
    {
        if (explosionPrefab != null)
        {
            GameObject explosion = Instantiate(explosionPrefab, transform.position, Quaternion.identity);
            Destroy(explosion, 1.5f);
        }

        // زيادة السكور لو الـ ScoreManager موجود
        if (ScoreManager.instance != null)
        {
            ScoreManager.instance.AddScore(scoreValue);
        }

        Destroy(gameObject);
    }
}