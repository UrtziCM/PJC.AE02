using UnityEngine;
using UnityEngine.AddressableAssets;

public class CoinController : MonoBehaviour
{
    
    private void OnTriggerEnter(Collider other)
    {
        Addressables.Release(gameObject);
    }
}
