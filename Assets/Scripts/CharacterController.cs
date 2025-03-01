using JetBrains.Annotations;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    public GameObject player;
    public float flapStrength;
    public LogicScript logic;
    public bool birdIsAlive = true;
    public AudioSource jump;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && birdIsAlive)
        {
            Jump();
            jump.Play();
        }
    }

    void Jump()
    {
        player.GetComponent<Rigidbody2D>().linearVelocity = Vector2.up * flapStrength;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        logic.gameOver();
        birdIsAlive = false;
        Time.timeScale = 0;
    }
}
