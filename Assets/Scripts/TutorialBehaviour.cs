using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TutorialBehaviour : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI[] popups;
    private int currentPopupIndex = 0;
    [SerializeField] private float timeBetweenPopups = 1f;
    private float timeSinceLastPopup = 0f;
    private bool canShowNextPopup = false;

    // Update is called once per frame

    private void Start()
    {
        popups[0].gameObject.SetActive(true);
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

        if(currentPopupIndex == 0)
        {
            if(Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.D))
            {
                canShowNextPopup = true;
            }
        }
        
    }

    public void showNextPopup()
    {
        if (currentPopupIndex + 1 < popups.Length)
        {
            popups[currentPopupIndex].gameObject.SetActive(false);
            currentPopupIndex++;
            popups[currentPopupIndex].gameObject.SetActive(true);
        }
    }
}
