using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TutorialBehaviour : Observer
{
    [SerializeField] private string[] popups;
    [SerializeField] private TextMeshProUGUI popupObject;
    private int currentPopupIndex = 0;
    [SerializeField] private float timeBetweenPopups = 1f;
    private float timeSinceLastPopup = 0f;
    private bool canShowNextPopup = false;

    // Update is called once per frame

    private void Start()
    {
        popupObject.text = popups[currentPopupIndex];
    }
    void Update()
    {
        if(canShowNextPopup)
        {
            timeSinceLastPopup += Time.deltaTime;
            if (timeSinceLastPopup >= timeBetweenPopups)
            {
                timeSinceLastPopup = 0;
                showNextPopup();
                canShowNextPopup = false;
            }
        }


    }



    public void showNextPopup()
    {
        if (currentPopupIndex + 1 < popups.Length)
        {
            currentPopupIndex++;
            popupObject.text = popups[currentPopupIndex];
        }
    }

    public override void OnNotify(EventEnum currentEvent)
    {
        switch (currentEvent)
        {
            case EventEnum.Move:
                if (currentPopupIndex == 0)
                {
                    canShowNextPopup = true;
                }
                break;
            case EventEnum.Jump:
                if (currentPopupIndex == 1)
                {
                    canShowNextPopup = true;
                }
                break;
            case EventEnum.Dash:
                if (currentPopupIndex == 2)
                {
                    canShowNextPopup = true;
                }
                break;
            case EventEnum.Switch:
                if (currentPopupIndex == 3)
                {
                    canShowNextPopup = true;
                }
                break;
            case EventEnum.CollectSkillItem:
                if (currentPopupIndex == 4)
                {
                    canShowNextPopup = true;
                }
                break;
            case EventEnum.Vortex:
                if (currentPopupIndex == 5)
                {
                    timeSinceLastPopup = 0;
                    showNextPopup();
                    canShowNextPopup = false;
                }
                break;
            case EventEnum.VortexClick:
                if (currentPopupIndex == 6)
                {
                    canShowNextPopup = true;
                }
                break;
            case EventEnum.Key:
                if (currentPopupIndex == 7)
                {
                    canShowNextPopup = true;
                }
                break;
        }
        
    }
}
