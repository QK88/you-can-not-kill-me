using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BagButton : MonoBehaviour
{
    public void OpenButton()
    {
        GameManager.instance.clickBag = true;
    }
}
