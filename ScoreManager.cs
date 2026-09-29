using UnityEngine;
using TMPro; // عشان نستخدم مكتبة TextMeshPro

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;

    [Header("UI Reference")]
    public TextMeshProUGUI scoreText; // اسحب نص السكور هنا

    private int score = 0;

    void Awake()
    {
        // عمل Singleton عشان نوصل للـ ScoreManager بسهولة من أي كود
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        UpdateScoreUI();
    }

    // دالة زيادة السكور
    public void AddScore(int amount)
    {
        score += amount;
        UpdateScoreUI();
    }

    // تحديث النص على الشاشة
    void UpdateScoreUI()
    {
        if (scoreText != null)
        {
            scoreText.text = "Score: " + score;
        }
    }
}