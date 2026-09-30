using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartMenuButtonsController : MonoBehaviour
{
    public void PlayBTNMenu(GameObject gameMenuCanvas)
    {
        transform.parent.gameObject.SetActive(false);
        gameMenuCanvas.SetActive(true);

    }
}
