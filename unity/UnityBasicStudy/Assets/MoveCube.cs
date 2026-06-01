using UnityEditor;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;

public class MoveCube : MonoBehaviour
{
    //Vector3 position;

    private float speed = 3f;
    private float rotateSpeed = 100f;

    Rigidbody rb;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    // 화면이 시작되고 최초 한번만 실행되는 초기화 메서드
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    //Update is called once per frame
    // 각 프레임마다 호출. 30fps => 1초동안 30번 호출
    void Update() 
    {
        //position = Vector3.zero;    // 현재 위치 초기화

        //if (Input.GetKey(KeyCode.UpArrow)) 
        //{ 
        //    position.z = 0.05f; 
        //} 

        //if (Input.GetKey(KeyCode.DownArrow)) 
        //{ 
        //    position.z = -0.05f; 
        //}

        //if (Input.GetKey(KeyCode.LeftArrow))
        //{
        //    position.x = -0.05f;
        //}

        //if (Input.GetKey(KeyCode.RightArrow))
        //{
        //    position.x = 0.05f;
        //}

        //transform.Translate(position);



        //앞뒤 이동
        float move = Input.GetAxis("Vertical");
        move = move * speed * Time.deltaTime;



        transform.Translate(Vector3.forward * move);

        //좌우 회전
        float rotate = Input.GetAxis("Horizontal");
        rotate = rotate * rotateSpeed * Time.deltaTime;

        transform.Rotate(Vector3.up * rotate);


        //// 앞뒤 이동
        //float move = Input.GetAxis("Vertical");
        //Vector3 moveAmount = transform.forward * move * speed * Time.fixedDeltaTime;

        //rb.MovePosition(rb.position + moveAmount);

        //// 좌우 회전
        //float rotate = Input.GetAxis("Horizontal");
        //Quaternion turn = Quaternion.Euler(0f, rotate * rotateSpeed * Time.fixedDeltaTime, 0f);

        //rb.MoveRotation(rb.rotation * turn);
    }
}
