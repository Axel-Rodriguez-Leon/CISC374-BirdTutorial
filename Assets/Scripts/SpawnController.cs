using UnityEngine;

public class SpawnController : MonoBehaviour
{
    public GameObject pipes;
    public float spawnRate = 2;
    private float timer = 0;
    public float heightOffset = 10;
    public LogicScript logic;
    private float playerDifficulty = 10;
    //public PipesController pipesController;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();
        //pipesController = GameObject.FindGameObjectWithTag("Pipes").GetComponent<PipesController>();
        spawnPipe();
    }

    // Update is called once per frame
    void Update()
    {
        if (logic.playerScore >= playerDifficulty)
        {
            spawnRate = Mathf.Max(0.5f, spawnRate - 0.2f); ;
            playerDifficulty += 10;
            Debug.Log($"Spawn Rate: {spawnRate}");
        }
        if (timer < spawnRate) 
        {
            timer += Time.deltaTime;
        }
        else
        {
            spawnPipe();
            timer = 0;
        }
        
    }

    void spawnPipe()
    {
        float lowestPoint = transform.position.y - heightOffset;
        float highestPoint = transform.position.y + heightOffset;

        Instantiate(pipes, new Vector3(transform.position.x, Random.Range(lowestPoint, highestPoint), 0), transform.rotation);
    }
}
