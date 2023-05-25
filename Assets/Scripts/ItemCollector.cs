using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemCollector : MonoBehaviour
{
    int coinsCollected = 0;
    [SerializeField] Text coinsText;
    private void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.CompareTag("Coin"))
        {
            Destroy(collider.gameObject);
            coinsCollected++;
            coinsText.text = "COINS: " + coinsCollected;
        }
    }
}
