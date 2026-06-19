using System;
using System.Collections;
using UnityEngine;

public class SensorTrigger : MonoBehaviour
{
    [Header("컨베이어 1")]
    public ConveyorBelt conveyor1;

    [Header("컨베이어 2")]
    public ConveyorBelt conveyor2;

    private bool isProcessing = false;

    public BoxSpawner spawner;

    // 다른 Collider가 들어와서 Trigger가 발생하면?
    private void OnTriggerEnter(Collider other)
    {
        if (isProcessing) return;

        if(other.CompareTag("Product"))
        {
            // 시간이 걸리는 작업을 여러 프레임에 나눠서 실행하는 기능
            StartCoroutine(Process());
        }
    }

    private IEnumerator Process()
    {
        Debug.Log("제품 감지!");

        isProcessing = true;

        conveyor1.Stop();   // isRunning=false;
        conveyor2.Stop();
        spawner.Stop();

        yield return new WaitForSeconds(3.0f);  // 3초동안 대기한 뒤 다음 로직으로

        conveyor1.StartBelt();
        conveyor2.StartBelt();
        spawner.StartSpawner();

        yield return new WaitForSeconds(1.0f);

        isProcessing = false;
    }
}
