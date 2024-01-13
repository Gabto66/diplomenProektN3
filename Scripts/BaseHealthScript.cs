using UnityEngine;

public class BaseHealthScript : MonoBehaviour
{
    public int currentHealth;
    public const int health = 200;
    // Start is called before the first frame update
    void Start()
    {

    }

    private void EndGame()
    {
        Application.Quit();
    }

    // Update is called once per frame
    void Update()
    {
        if (currentHealth <= 0)
        {
            EndGame();
        }

    }
}
