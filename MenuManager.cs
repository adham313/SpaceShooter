using UnityEngine;
using UnityEngine.SceneManagement; // مكتبة التنقل بين المشاهد

public class MenuManager : MonoBehaviour
{
    public void PlayGame()
    {
        // هيحمل المشهد رقم 1 (اللي هو مشهد اللعبة)
        SceneManager.LoadScene(1);
    }

    // دالة الخروج المضافة
    public void QuitGame()
    {
        Debug.Log("Exiting Game..."); // بتظهر في الكونسول للتأكيد وأنت بتجرب
        Application.Quit();            // بتقفل اللعبة لما تعملها Build
    }
}