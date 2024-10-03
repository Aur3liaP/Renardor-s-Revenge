using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager1 : MonoBehaviour
{

    public static LevelManager1 main;

    public Transform StartPoint;
    public Transform[] path;

    private void Awake() {
        main = this;
    }


}