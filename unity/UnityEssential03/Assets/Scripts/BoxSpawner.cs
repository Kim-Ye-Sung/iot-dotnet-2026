using Unity.VisualScripting;
using UnityEngine;

public class BoxSpawner : MonoBehaviour
{
    public GameObject prdPrefab;

    public float interval = 3.0f;

    private float timer = 0.0f;
    private bool isRunning = true;

    // Update is called once per frame
    void Update()
    {
        if(!isRunning)  // isRunning이 false면 아래 로직 실행안함
        {
            return;
        }

        if(prdPrefab != null)
        {
            timer += Time.deltaTime;

            if(timer >= interval)
            {
                timer = 0.0f;

                // instant 예제, 샘플
                Instantiate(prdPrefab,
                             transform.position,
                             Quaternion.identity);
            }
        }

    }

    public void Stop()
    {
        isRunning = false;
    }

    public void StartSpawner()
    {
        isRunning = true;
    }
}
