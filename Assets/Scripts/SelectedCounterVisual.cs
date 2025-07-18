using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectedCounter : MonoBehaviour
{
    [SerializeField]private ClearCounter clearCounter;
    [SerializeField] private GameObject visualGameObject;
    
    private void Start()
    {
        Player.Instance.OnSelectedCounterChanged += Player_OnSelectedCounterChanged;
    }

    private void Player_OnSelectedCounterChanged(object sender, Player.OnSelectedCounterChangedEventArgs e)
    {
        if(e.selectedCounter == clearCounter)
        {
            Show();
            //Debug.Log("show");
        }
        else
        {
            Hide();
            //Debug.Log("hide");

        }
    }  
    private void Show()
    {
        visualGameObject.SetActive(true);
    }
        
    private void Hide()
    {
        visualGameObject.SetActive(false);
    }

}
