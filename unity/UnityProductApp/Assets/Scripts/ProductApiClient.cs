using System;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.Networking;

public class ProductApiClient : MonoBehaviour
{
    [SerializeField]
    private TMP_Text txtLog;

    private string serviceUrl = "http://localhost:5276/api/products";

    public void  LoadProducts()
    {
        StartCoroutine(GetProducts());
    }

    private IEnumerator GetProducts()
    {
        using UnityWebRequest request = UnityWebRequest.Get(serviceUrl);

        yield return request.SendWebRequest();

        if (request.result != UnityWebRequest.Result.Success)
        {
            txtLog.text = request.error;
            yield break;
        }

        txtLog.text = request.downloadHandler.text;
    }
}
