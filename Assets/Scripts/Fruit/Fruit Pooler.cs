using System.Collections.Generic;
using UnityEngine;

public class FruitPooler : MonoBehaviour
{
    public Fruit[] fruits;
    public int poolSize = 20;
    public int bombSize = 5;
    public GameObject fruitParent;

    internal int PoolSize
    { get { return poolSize; } }

    private List<GameObject> fruitPool;

    public void FreezeFruits(float duration)
    {
        foreach (GameObject fruit in fruitPool)
        {
            if (fruit.activeInHierarchy)
            {
                FruitMovement fruitMovement = fruit.GetComponent<FruitMovement>();
                fruitMovement.Freeze(duration);
            }
        }
    }

    private void Start()
    {
        fruitPool = new List<GameObject>();

        for (int i = 0; i < Random.Range(0, bombSize); i++)
        {
            GameObject bomb = Instantiate(fruits[0].prefab, fruitParent.transform);
            bomb.SetActive(false);

            FruitMovement bombMovement = bomb.GetComponent<FruitMovement>();
            bombMovement.ScoreValue = fruits[0].scoreValue;
            bombMovement.IsHarmful = fruits[0].isHarmful;
            bombMovement.SlicedPrefabs = fruits[0].slicedPrefabs;

            fruitPool.Add(bomb);
        }

        for (int i = 1; i < poolSize; i++)
        {
            int randomIndex = Random.Range(1, fruits.Length);
            GameObject fruit = Instantiate(fruits[randomIndex].prefab, fruitParent.transform);
            fruit.SetActive(false);

            FruitMovement fruitMovement = fruit.GetComponent<FruitMovement>();
            fruitMovement.ScoreValue = fruits[randomIndex].scoreValue;
            fruitMovement.IsHarmful = fruits[randomIndex].isHarmful;
            fruitMovement.SlicedPrefabs = fruits[randomIndex].slicedPrefabs;
            fruitMovement.CanFreeze = fruits[randomIndex].canFreeze;
            fruitMovement.FreezeDuration = fruits[randomIndex].freezeDuration;

            fruitPool.Add(fruit);
        }
    }

    public GameObject GetFruit()
    {
        foreach (GameObject fruit in fruitPool)
            if (!fruit.activeInHierarchy)
                return fruit;

        int randomIndex = Random.Range(0, fruits.Length);
        GameObject newFruit = Instantiate(fruits[randomIndex].prefab, fruitParent.transform);

        FruitMovement fruitMovement = newFruit.GetComponent<FruitMovement>();
        fruitMovement.ScoreValue = fruits[randomIndex].scoreValue;
        fruitMovement.IsHarmful = fruits[randomIndex].isHarmful;
        fruitMovement.SlicedPrefabs = fruits[randomIndex].slicedPrefabs;
        fruitMovement.CanFreeze = fruits[randomIndex].canFreeze;
        fruitMovement.FreezeDuration = fruits[randomIndex].freezeDuration;

        fruitPool.Add(newFruit);
        return newFruit;
    }
}

[System.Serializable]
public class Fruit
{
    public GameObject prefab;
    public GameObject[] slicedPrefabs;

    public int scoreValue;
    public bool isHarmful;

    public bool canFreeze;
    public float freezeDuration;
}