using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HiddenTile : MonoBehaviour, CameraSelector.Hoverable
{
    int defaultLayer = 0;
    TMP_Text face;
    [SerializeField] string hiddenText;
    SearchScore searchScore;

    void Start()
    {
        face = GetComponentInChildren<TMP_Text>();
        if(!GameObject.FindGameObjectWithTag("GameController").TryGetComponent(out searchScore))
        {
            Debug.LogWarning("HiddenTile started, but gameController.TryGetComponent(out SearchScore) returned false. Consider adding a SearchScore script component to the GameController");
        }
    }
    public void Click()
    {
        face.text = hiddenText;
        searchScore.Add();
        gameObject.layer = defaultLayer;
    }

    public void Hover()
    {
        gameObject.GetComponent<Outline>().AddLayer("can-click");
    }
    public void Unhover()
    {
        gameObject.GetComponent<Outline>().SubtractLayer("can-click");
    }
    public GameObject GetGameObject()
    {
        return gameObject;
    }
}
