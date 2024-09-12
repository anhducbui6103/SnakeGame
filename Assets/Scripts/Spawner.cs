using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject prefab;
    private GameObject currentFood;

    private void Start()
    {
        SpawnFood();
    }
    public void SpawnFood()
    {
        if (currentFood == null)
        {
            Destroy(currentFood);
        }

        float x = Random.Range(-23, 23);
        float y = Random.Range(-11, 11);
        Vector3 spawnPosition = new Vector3(x, y, 0);

        currentFood = Instantiate(prefab, spawnPosition, Quaternion.identity);
    }

    public void OnEatFood()
    {
        SpawnFood();
    }
}
