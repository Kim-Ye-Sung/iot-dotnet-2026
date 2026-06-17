using UnityEngine;

public class Collectible : MonoBehaviour
{
    [Header("회전 설정")]
    [Tooltip("프레임당 회전 속도")]
    [Range(1,10)]
    public float rotationSpeed = 0.5f;

    public GameObject CollectEffect;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0, rotationSpeed, 0);
    }

    private void OnTriggerEnter(Collider ohter)
    {
        Instantiate(CollectEffect, transform.position, transform.rotation);
        Destroy(gameObject);
    }
}
