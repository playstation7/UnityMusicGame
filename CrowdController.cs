using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrowdController : MonoBehaviour
{
    //-0.35f:1.2f
    public GameObject prefab;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("peopleCreate");
    }

    IEnumerator peopleCreate() 
    {
        while (true) 
        {
            if(ConcertManager.people < GameSettings.MaxPeopleCrowd) 
                Instantiate(prefab,transform);
            yield return new WaitForSeconds(0.5f);
        }
    }
}
