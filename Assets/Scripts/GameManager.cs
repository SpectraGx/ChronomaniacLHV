using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public bool isGamePause;

    private void Awake() {
        isGamePause=false;
    }
}
