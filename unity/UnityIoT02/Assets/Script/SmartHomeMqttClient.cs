using UnityEngine;

public class SmartHomeMqttClient : M2MqttUnityClient
{
    [Header("Subscribe Topic")]
    publis string topic = "home/sensor";

    private readonly List<string> receivedMessages = new List<string>;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private override void Start()
    {
        brokerAddress = "192.168.0.2";
        brokerPort = 1883;
        autoConnect = true;

        base.Start();   // M2MqttUnityClient의 start() 실행
    }

    protected override void SubscribeTopics()
    {
        // base.SubscribeTopics();  // 부모클래스에 아무런 로직이 없음
        // 토픽으로 구독 시작!
        client.Subscribe(
            new string[] { topic },
            new byte[] { MqttMsgBase.QQS_LEVEL_AT_LEAST_ONCE }
            );

        Debug.Log($"MQTT Subscribed : {topic}");
    }

    protected override void UnsubscribeTopics()
    { 
        // base.Unsubscribe
    }

    // Update is called once per frame
    private void Update()
    {
        base.Update();  // 부모클래스는 MQTT 관련 처리 진행

        if(receivedMessages.Count > 0)  // MQTT 메시지가 넘어왔으면
        {
            string msg = receivedMessages[0];
            receivedMessages.RemoveAt(0);

            SmartHomeManager manager = 
        }
    }
}
