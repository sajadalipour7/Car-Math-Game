using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonPressed : Button
{

    public bool PublicIsPressed()
    {
        return base.IsPressed();
    }
}
