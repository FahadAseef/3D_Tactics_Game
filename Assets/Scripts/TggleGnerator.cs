using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;
using UnityEngine.UI;

public class TggleGnerator : MonoBehaviour
{
    public GameObject obstaclePrefab;
    public GameObject togglePrefab; // Assign a prefab of a Toggle UI element in the Inspector
    public Transform gridParent; // Assign a parent Transform in the Inspector to hold the grid
    public Vector2 toggleSize = new Vector2(100, 100); // Size of each toggle button

    private Toggle[,] toggles;
    public GameObject[,] cubes;
    public GameObject[] cubees;
    private int gridSize = 10;

    void Start()
    {
        toggles = new Toggle[gridSize, gridSize];
        cubes = new GameObject[gridSize, gridSize];

        // Create grid of toggles and cubes
        for (int i = 0; i < gridSize; i++)
        {
            //int index = i;
            for (int j = 0; j < gridSize; j++)
            {
                int index = i * gridSize + j;
                // Create Toggle
                GameObject toggleObject = Instantiate(togglePrefab, gridParent);
                Toggle toggle = toggleObject.GetComponent<Toggle>();
                toggles[i, j] = toggle;

                // Set position of toggle in the grid
                RectTransform toggleRectTransform = toggleObject.GetComponent<RectTransform>();
                toggleRectTransform.anchoredPosition = new Vector2(-750 + i * toggleSize.x,100 + -j * toggleSize.y);


                //Create a cube and position it
                /*
                GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
                cube.transform.position = new Vector3(i, 0, j);
                cubes[i, j] = cube;
                */

                // Setup Toggle listener
                toggle.isOn = false;
                int x = i, y = j;
                toggle.onValueChanged.AddListener((isOn) => OnToggleChanged( index , isOn));
            }



        }


    }


    private GameObject newBlocker;
    void OnToggleChanged( int intex , bool isOn)
    {
        int x = intex % gridSize;
        int y = intex / gridSize;

        if (isOn)
        {
            // Create an obstacle on the cube
            Vector3 position = new Vector3(cubees[intex].transform.position.x, 0.5f, cubees[intex].transform.position.z);
            newBlocker = Instantiate(obstaclePrefab, position, Quaternion.identity);
            //cubees[intex].gameObject.tag = "obstacle";
            //newBlocker.transform.parent = cubes[x, y].transform; // Make the obstacle a child of the cube
            newBlocker.transform.parent = cubees[intex].transform; // Make the obstacle a child of the cube
        }
        else if (!isOn)
        {
            Destroy(newBlocker);
            cubees[intex].gameObject.tag = "cube";
        }
        /*
        else
        {
            // Remove the obstacle from the cube
            if (cubes[x, y].transform.childCount > 0)
            {
                foreach (Transform child in cubes[x, y].transform)
                {
                    if (child.gameObject.CompareTag("Obstacle")) // Ensure we're destroying the obstacle
                    {
                        Destroy(child.gameObject);
                    }
                }
            }
        }
        */
    }
}
