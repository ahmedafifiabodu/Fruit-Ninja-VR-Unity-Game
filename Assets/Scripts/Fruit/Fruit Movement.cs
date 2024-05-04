using System.Collections;
using UnityEngine;

public class FruitMovement : MonoBehaviour
{
    [Header("Fruit Movement")]
    [SerializeField] private float verticalForce = 150f;

    [SerializeField] private float horizontalForce = 75f;
    [SerializeField] private Rigidbody rb;

    public int ScoreValue { get; set; } = 1;
    public bool IsHarmful { get; set; }
    public bool CanFreeze { get; set; }
    public float FreezeDuration { get; set; }
    public GameObject[] SlicedPrefabs { get; set; }

    private bool isFrozen = false;
    private Coroutine resumeCoroutine;
    private float lastCollisionTime;

    public void Freeze(float duration)
    {
        if (isFrozen && resumeCoroutine != null)
            StopCoroutine(resumeCoroutine);

        isFrozen = true;
        rb.useGravity = false;
        rb.isKinematic = true;
        resumeCoroutine = StartCoroutine(ResumeAfterDelay(duration));
    }

    private IEnumerator ResumeAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        Resume();
    }

    private void Resume()
    {
        isFrozen = false;
        rb.useGravity = true;
        rb.isKinematic = false;
        rb.AddForce(new Vector3(
            Random.Range(-horizontalForce, horizontalForce),
            verticalForce,
            0));

        OnCollisionEnter(null);
    }

    private void OnEnable()
    {
        rb.velocity = Vector3.zero;
        rb.AddForce(new Vector3(
            Random.Range(-horizontalForce, horizontalForce),
            verticalForce,
            0));
        lastCollisionTime = Time.time;
        StartCoroutine(CheckCollision());
    }

    private IEnumerator CheckCollision()
    {
        yield return new WaitForSeconds(5);
        if (Time.time - lastCollisionTime >= 5)
        {
            gameObject.SetActive(false);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision != null && collision.gameObject.CompareTag("Ground") && !isFrozen)
        {
            gameObject.SetActive(false);
        }
        lastCollisionTime = Time.time;
    }
}