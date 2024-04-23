using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TutorialBehaviour : MonoBehaviour
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

   
        switch(currentPopupIndex)
        {
            case 0:
                if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.D))
                {
                    canShowNextPopup = true;
                }
                break;
            case 1:
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    canShowNextPopup = true;
                }
                break;
            case 2:
                if (Input.GetKeyDown(KeyCode.E))
                {
                    canShowNextPopup = true;
                }
                break;
            case 3:
                if (Input.GetKeyDown(KeyCode.Q))
                {
                    canShowNextPopup = true;
                }
                break;
            case 4:
                if (Input.GetKeyDown(KeyCode.Mouse0))
                {
                    canShowNextPopup = true;
                }
                break;
            case 5:
                if (Input.GetKeyDown(KeyCode.Mouse0))
                {
                    timeSinceLastPopup = 0;
                    showNextPopup();
                    canShowNextPopup = false;
                }
                break;

               
            
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
}
