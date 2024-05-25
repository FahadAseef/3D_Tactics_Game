using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class tileRayCaster : MonoBehaviour
{
    public Text infoText;

    void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
            Tile tile = hit.collider.GetComponent<Tile>();
            if (tile != null)
            {
                infoText.text = $"Tile Position: ({tile.tilePos})";
            }
        }
        else
        {
            infoText.text = "";
        }
    }
}
