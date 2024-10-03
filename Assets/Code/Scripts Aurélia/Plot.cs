using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plot : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private SpriteRenderer sr;
    [SerializeField] private Color hoverColor;

    private GameObject tower;
    private Color startColor;

    private void Start(){
       startColor = sr.color;
    }

    public void OnMouseEnter() {
        sr.color = hoverColor;
    }

    public void OnMouseExit() {
        sr.color = startColor;
    }

    public void OnMouseDown() {
        Debug.Log("Build Tower Here" + name);
    }
}
