using UnityEngine;

public class PipesController : MonoBehaviour
{
    public float moveSpeed = 25;
    public float deadZone = -45;
    public LogicScript logic;
    private float difficultyLevel = 10;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += (Vector3.left * moveSpeed) * Time.deltaTime;


        if (transform.position.x < deadZone)
        {
            Debug.Log("Pipe Deleted");
            Destroy(gameObject);
        }
    }

    public void increaseDifficulty()
    {
        if (logic.playerScore > difficultyLevel)
        {
            moveSpeed += 10;
            difficultyLevel += 10;
        }
    }
}
