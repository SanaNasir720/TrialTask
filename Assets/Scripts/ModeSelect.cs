using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModeSelect : MonoBehaviour
{
    private void Start() {
        
    }

    public enum Mode {
        MOVE = 1,
        SCALE = 2
    }

    public Mode mode;

    public void SetMode(int mode) {

        this.mode = (Mode) mode;
    }
}
