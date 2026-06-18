using UnityEngine;

public class BoxSpawner : MonoBehaviour
{
    public GameObject prdPrefab;

    public float interval = 3.0f;

    float timer = 0.0f;

    // Update is called once per frame
    void Update()
    {
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
}
