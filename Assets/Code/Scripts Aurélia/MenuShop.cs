using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MenuShop : MonoBehaviour
{
    [Header("References")]
    [SerializeField] TextMeshProUGUI currencyUI;

    private int selectedTower = 0;

    private void OnGUI(){
        currencyUI.text = LevelManager.main.currency.ToString();
    }

    public void SetSelected() {
        
    }
}
