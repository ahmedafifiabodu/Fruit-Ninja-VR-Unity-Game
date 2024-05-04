using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] internal int health = 5;
    internal int score = 0;
    public bool HasSword { get; set; } = false;
}