using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLocker : MonoBehaviour
{
    public bool notAmenu;
    // Start is called before the first frame update
    void Start()
    {
        if (notAmenu)
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
        if (!notAmenu)
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
    }
}
