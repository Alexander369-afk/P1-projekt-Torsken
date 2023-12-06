using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject gamePrefab; // Drag your game prefab into this field in the Unity Editor
    public Transform spawnPoint; // Set the spawn point for your game prefab
    public Transform endTrigger; // Set the position of the trigger to end the game

    private GameObject currentGameInstance;

    void Start()
    {
        // Instantiate the game prefab at the specified spawn point
        StartGame();
    }

    void StartGame()
    {
        currentGameInstance = Instantiate(gamePrefab, spawnPoint.position, Quaternion.identity);
    }

    void EndGame()
    {
        Destroy(currentGameInstance);

        // You can add additional logic here for game over effects or transitions
    }

    void Update()
    {
        // Check if the game has reached the end trigger position
        if (currentGameInstance != null && currentGameInstance.transform.position.x >= endTrigger.position.x)
        {
            EndGame();
        }
    }
}