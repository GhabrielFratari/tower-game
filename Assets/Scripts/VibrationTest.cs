using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VibrationTest : MonoBehaviour
{
    public void Vibrate()
    {
        AndroidVibration.Vibrate(50);
    }
    
}
