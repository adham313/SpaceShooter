using UnityEngine;

public class SpawnSystem : MonoBehaviour
{
    [Header("Enemy Settings")]
    public GameObject[] enemyPrefabs;

    [Header("Effects")]
    [Tooltip("اسحب الـ Prefab بتاع الـ SpawnParticles هنا")]
    public GameObject spawnParticlePrefab; 

    [Header("Spawn Times")]
    public float spawnInterval = 2f;
    private float timer;

    [Header("Spawn Points")]
    public Transform[] spawnPoints;

    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= spawnInterval)
        {
            SpawnEnemy();
            timer = 0f;
        }
    }

    void SpawnEnemy()
    {
        if (enemyPrefabs == null || enemyPrefabs.Length == 0) return;

        int randomEnemyIndex = Random.Range(0, enemyPrefabs.Length);
        GameObject selectedEnemy = enemyPrefabs[randomEnemyIndex];

        Vector3 spawnPosition = transform.position;
        Quaternion spawnRotation = Quaternion.identity;

        if (spawnPoints != null && spawnPoints.Length > 0)
        {
            int randomPointIndex = Random.Range(0, spawnPoints.Length);
            spawnPosition = spawnPoints[randomPointIndex].position;
            spawnRotation = spawnPoints[randomPointIndex].rotation;
        }

        // 1. إنشاء العدو
        Instantiate(selectedEnemy, spawnPosition, spawnRotation);

        // 2. إنشاء تأثير الجزيئات في نفس المكان وتدميره بعد ثانية
        if (spawnParticlePrefab != null)
        {
            GameObject particleInstance = Instantiate(spawnParticlePrefab, spawnPosition, Quaternion.identity);
            Destroy(particleInstance, 1f); // مسح التأثير من الذاكرة بعد ثانية
        }
    }
}