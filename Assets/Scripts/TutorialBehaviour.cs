using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class TutorialBehaviour : Observer
{
    [SerializeField] private string[] popups;
    [SerializeField] private TextMeshProUGUI popupObject;
    [SerializeField] private InputActionAsset inputActionAsset;
    private int currentPopupIndex = 0;
    [SerializeField] private float timeBetweenPopups = 1f;
    private float timeSinceLastPopup = 0f;
    private bool canShowNextPopup = false;

    // Update is called once per frame

    private void Start()
    {
        ReplaceBindsInPopups();
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

    private void ReplaceBindsInPopups()
    {
        for (int i = 0; i < popups.Length; i++)
        {
            if (popups[i].Contains("MOVELEFT"))
            {
                popups[i] = popups[i].Replace("MOVELEFT", inputActionAsset.FindAction("MoveLeft").GetBindingDisplayString(0));
            }
            if (popups[i].Contains("MOVERIGHT"))
            {
                popups[i] = popups[i].Replace("MOVERIGHT", inputActionAsset.FindAction("MoveRight").GetBindingDisplayString(0));
            }
            if (popups[i].Contains("JUMP"))
            {
                popups[i] = popups[i].Replace("JUMP", inputActionAsset.FindAction("Jump").GetBindingDisplayString(0));
            }
            if (popups[i].Contains("SKILL"))
            {
                popups[i] = popups[i].Replace("SKILL", inputActionAsset.FindAction("UseSkill").GetBindingDisplayString(0));
            }
            if (popups[i].Contains("SWITCH"))
            {
                popups[i] = popups[i].Replace("SWITCH", inputActionAsset.FindAction("SwitchSkill").GetBindingDisplayString(0));
            }
            if (popups[i].Contains("INTERACT"))
            {
                popups[i] = popups[i].Replace("INTERACT", inputActionAsset.FindAction("Interact").GetBindingDisplayString(0));
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
