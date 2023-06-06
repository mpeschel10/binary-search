using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DuplicateHiddenTile : MonoBehaviour
{
    [SerializeField] int totalTileCount = 40;
    [SerializeField] float offsetX = 1;

    static string letters = "abcdefghijklmnopqrstuvwxyzΑαΒβΓγΔδΕεΖζΗηΘθΙιΚκΛλΜμΝνΞξΟοΠπΡρΣσςΤτΥυΦφΧχΨψΩω";
    void Start()
    {
        GameObject firstTile = GetComponentInChildren<HiddenTile>().gameObject;
        Quaternion oldRotation = firstTile.transform.rotation;
        Vector3 oldPosition = firstTile.transform.position;
        Vector3 offset = Vector3.right * offsetX;

        for(int i = 1; i < totalTileCount; i++)
        {
            Vector3 newPosition = firstTile.transform.position + i * offset;
            GameObject newObject = Object.Instantiate(firstTile, newPosition, oldRotation);
            newObject.transform.SetParent(this.transform);

            TMP_Text[] texts = newObject.GetComponentsInChildren<TMP_Text>();
            foreach (TMP_Text text in texts)
            {
                if (text.name == "TileFace")
                {
                    text.text = " ";//letters[i].ToString();   
                } else { // text.name == "TileIndex"
                    text.text = i.ToString();
                }
            }

            HiddenTile newTile = newObject.GetComponent<HiddenTile>();
            newTile.hiddenText = Mathf.Pow(2, i).ToString();
        }
    }

}
