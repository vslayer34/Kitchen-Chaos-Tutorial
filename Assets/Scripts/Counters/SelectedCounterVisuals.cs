using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectedCounterVisuals : MonoBehaviour
{
    [SerializeField] GameObject selectedCounterVisual;
    [SerializeField] BaseCounter baseCounter;


    private void Start()
    {
        Player.Instance.OnSelectedCounterChanged += Player_OnSelectedCounterChanged;
    }

    private void Player_OnSelectedCounterChanged(object sender, Player.OnSelectedCounterChangedEventArgs e)
    {
        if (e.SelectedCounter == baseCounter)
        {
            ShowSelectedEffect();
        }
        else
        {
            HideSelectedEffect();
        }
    }

    private void ShowSelectedEffect()
    {
        selectedCounterVisual.SetActive(true);
    }
    private void HideSelectedEffect()
    {
        selectedCounterVisual.SetActive(false);
    }
}
