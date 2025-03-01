using UnityEngine;

public class PipeMiddleController : MonoBehaviour
{
    public LogicScript logic;
    public AudioSource scoreSound;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 3)
        {
            scoreSound.Play();
            logic.addScore(1);
            logic.updateHigh();
        }
        
    }
}
