using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputController : MonoBehaviour
{
    public KeyCode keyCode;
    ICheckable checkable;
    
    // Start is called before the first frame update
    void Start()
    {
        checkable = GetComponent<ICheckable>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(keyCode)) checkable.CenterCheck();
        if (Input.GetKeyUp(keyCode)) checkable.CenterUP();
        if (Input.GetKeyDown(keyCode)) checkable.CenterDown();
    }
}



