using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SightFix : MonoBehaviour
{
    private RectTransform sightItself;

    private Vector2 sightPlace;

    public void ChangeW(object Pobject, PitchChange.MilArgs PmilArgs)
    {
        sightPlace.y = PmilArgs.SmilNow;
        sightItself.anchoredPosition = sightPlace;
    }
    // Start is called before the first frame update
    void Awake()
    {
        sightPlace = new Vector2(0f, 0f);
        sightItself = this.GetComponent<RectTransform>();
        sightItself.anchoredPosition = sightPlace;
        PitchChange.EchangeMil += this.ChangeW;
    }
}
