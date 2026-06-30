using UnityEngine;

public class Coin : MonoBehaviour
{
    // 코인의 회전속도
    private float rotateSpeed;

    public int score = 10;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // 코인별로 회전속도를 랜덤하게 설정
        rotateSpeed = Random.Range(50.0f, 360.0f);
    }

    // Update is called once per frame
    void Update()
    {
        // 계속해서 회전
        transform.Rotate(Vector3.up * rotateSpeed * Time.deltaTime);
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            GameManager.Instance.AddScore(score);

            Destroy(gameObject);
        }
    }
}
