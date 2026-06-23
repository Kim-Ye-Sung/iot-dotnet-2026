using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 5.0f;
    public float mouseSensitivity = 200.0f;
    public float jumpPower = 5.0f;

    private Rigidbody rb;
    private Animator animator;

    private bool isGrounded = true;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Update()
    {
        // WASD 이동
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = new Vector3(x, 0, z);
        transform.Translate(move * speed * Time.deltaTime);

        // 이동 중인지 확인
        bool isMove = move.magnitude > 0;

        animator.SetBool("IsMove", isMove);
        animator.SetBool("Idle", !isMove && !animator.GetBool("IsJump"));

        // 마우스 좌우 회전
        float mouseX = Input.GetAxis("Mouse X");
        transform.Rotate(Vector3.up * mouseX * mouseSensitivity * Time.deltaTime);

        // 점프
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.AddForce(Vector3.up * jumpPower, ForceMode.Impulse);

            isGrounded = false;

            animator.SetBool("IsJump", true);
            animator.SetBool("Idle", false);
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        isGrounded = true;

        animator.SetBool("IsJump", false);
    }
}