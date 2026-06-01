using UnityEngine;

public class ExitTrigger : MonoBehaviour
{
    public GameObject GameOverText;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            GameOverText.SetActive(true);
            Time.timeScale = 0.0f;
        }
    }
}
