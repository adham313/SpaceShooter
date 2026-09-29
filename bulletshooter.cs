using UnityEngine;

public class bulletshooter : MonoBehaviour
{
    public GameObject bulletObj;
    public Transform shootingPoint;
    
    private float Timer;
    public float resetTimer;
    private playermovment1 playersc;

    void Start()
    {
        // حطينا السطر ده عشان يربط الـ player بالسكريبت أول ما اللعبة تبدأ
        playersc = FindObjectOfType<playermovment1>();
    }

    void Update()
    {
        if (playersc != null && playersc.GameOver == false) 
        {
            if (Input.GetKey(KeyCode.Space) && Timer <= 0)
            {
                Instantiate(bulletObj, shootingPoint.position, transform.rotation);
                Timer = resetTimer;
            }
            else
            {
                Timer -= Time.deltaTime;
            }
        }
    }
}