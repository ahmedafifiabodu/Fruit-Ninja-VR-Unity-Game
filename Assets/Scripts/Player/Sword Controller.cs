using UnityEngine;

public class SwordController : MonoBehaviour
{
    [Header("Sword")]
    [SerializeField] private Rigidbody swordRigidbody;

    [SerializeField] private float minVelocityToCut = 10f;

    [Header("Player & Fruit Pooler")]
    [SerializeField] private Player player;

    [SerializeField] private FruitPooler fruitPooler;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Fruit") || collision.gameObject.CompareTag("Freeze Fruit"))
        {
            if (swordRigidbody.velocity.magnitude > minVelocityToCut)
            {
                FruitMovement fruitMovement = collision.gameObject.GetComponent<FruitMovement>();
                collision.gameObject.SetActive(false);

                if (fruitMovement.IsHarmful)
                    player.health--;
                else
                    player.score += fruitMovement.ScoreValue;

                if (fruitMovement.CanFreeze)
                    fruitPooler.FreezeFruits(fruitMovement.FreezeDuration);

                foreach (GameObject slicedPrefab in fruitMovement.SlicedPrefabs)
                {
                    GameObject slicedFruit = Instantiate(slicedPrefab, collision.transform.position, Quaternion.identity);

                    if (slicedFruit.TryGetComponent<Rigidbody>(out var slicedFruitRigidbody))
                    {
                        Vector3 force = new(Random.Range(-1f, 1f), Random.Range(0.5f, 1f), Random.Range(-1f, 1f));
                        slicedFruitRigidbody.AddForce(force, ForceMode.Impulse);
                    }

                    Destroy(slicedFruit, 2f);
                }
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
            player.HasSword = true;
    }
}