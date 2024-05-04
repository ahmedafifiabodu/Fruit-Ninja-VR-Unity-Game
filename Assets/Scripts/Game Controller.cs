using TMPro;
using UnityEngine;

public class GameController : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private Player player;

    [SerializeField] private Transform playerTransform;

    [SerializeField] private FruitPooler fruitPooler;
    [SerializeField] private TextMeshProUGUI infoText;

    [Header("Game Settings")]
    [SerializeField] private float Radius = 5f;

    [SerializeField] private float spawnDuration = 2f;
    [SerializeField] private float spawnTimer = 0f;
    [SerializeField] private float resetTimer = 0f;
    [SerializeField] private float gameTimer = 0f;

    private void Start() => spawnTimer = spawnDuration;

    private void Update()
    {
        if (gameTimer > 0 && player.health > 0)
        {
            gameTimer -= Time.deltaTime;

            if (player.HasSword)
            {
                spawnTimer -= Time.deltaTime;

                if (spawnTimer <= 0)
                {
                    spawnTimer = spawnDuration;

                    for (int i = 0; i < Random.Range(1, fruitPooler.PoolSize); i++)
                    {
                        GameObject fruit = fruitPooler.GetFruit();

                        Vector2 randomPosInCircle = Random.insideUnitCircle * Radius;
                        Vector3 spawnPosition = playerTransform.position + playerTransform.forward * randomPosInCircle.magnitude + new Vector3(randomPosInCircle.x, 0.5f, randomPosInCircle.y);

                        fruit.transform.position = spawnPosition;
                        fruit.SetActive(true);
                    }
                }
            }

            infoText.text = "Time: " + Mathf.Floor(gameTimer) + "\nScore: " + player.score + "\nHP: " + player.health;
        }
        else if (gameTimer <= 0 || player.health <= 0)
        {
            infoText.text = "Game Over! Score: " + player.score;
            resetTimer -= Time.deltaTime;

            if (resetTimer <= 0)
                UnityEngine.SceneManagement.SceneManager.LoadScene(UnityEngine.SceneManagement.SceneManager.GetActiveScene().name);
        }
    }
}