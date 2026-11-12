using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

public class CoinInstancer : MonoBehaviour
{
    List<Vector3> coinPositions = new();
    [SerializeField]
    public GameObject coinPrefab;

    public bool reloadCoins = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        foreach (Transform child in transform.GetComponentsInChildren<Transform>())
        {
            if (child == transform) continue;
            coinPositions.Add(child.position);
        }
        StartCoroutine(InstantiateCoins());
    }

    private IEnumerator InstantiateCoins()
    {
        foreach (Vector3 coinPosition in coinPositions)
        {
            AsyncOperationHandle coinOperation = Addressables.InstantiateAsync("Coin");
            yield return coinOperation;
            GameObject coinInstance = coinOperation.Result as GameObject;
            coinInstance.transform.position = coinPosition;

        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
