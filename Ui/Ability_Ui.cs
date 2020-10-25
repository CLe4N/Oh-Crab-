using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ability_Ui : MonoBehaviour
{
    public bool abilityIsTouch;

    public void ability_On()
    {
        abilityIsTouch = true;
    }

    public void ability_Off()
    {
        abilityIsTouch = false;
    }
}
