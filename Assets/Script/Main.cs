using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Main : MonoBehaviour
{
    public static readonly float CELL_SIZE = 1.28f;
    private GameObject menu = null;
    private GameObject player = null;
    private GameObject icon_frame = null;
    private GameObject icon = null;
    private GameObject canvas = null;
    private bool isTalk = false;

    // Start is called before the first frame update
    void Start()
    {
        GameObject floor_wood = (GameObject)Resources.Load("Cells/Floor_wood");
        Transform floor_transform = floor_wood.GetComponent<Transform>();
        Vector3 floor_scale = floor_transform.localScale;

        GameObject wall_empty = (GameObject)Resources.Load("Cells/Wall_empty");

        player = Instantiate((GameObject)Resources.Load("Characters/Player_test/Main"), new Vector3(0.0f, 0.0f, -2.0f), Quaternion.identity) as GameObject;
        player.GetComponent<Player>().main = this;
        GameObject main_camera = Instantiate((GameObject)Resources.Load("Camera/Main Camera"), new Vector3(0.0f, 0.0f, -4.0f), Quaternion.identity) as GameObject;
        canvas = GameObject.Find("MessageWindow");
        canvas.GetComponent<Canvas>().worldCamera = (UnityEngine.Camera)main_camera.GetComponent<UnityEngine.Camera>();
        //canvas.SetActive(false);
        int size = 10;
        for (int i = 0; i < size; i++)
        {
            for (int j = 0; j < size; j++)
            {
                Instantiate(floor_wood, new Vector3((-5.0f + (float)j)*CELL_SIZE, (-5.0f + (float)i)* CELL_SIZE, 0.0f), Quaternion.identity);
            }
            
        }
        Instantiate(wall_empty, new Vector3(0f, 1f, -2f), Quaternion.identity);

        
        
        main_camera.GetComponent<Camera>().setPlayer(player);
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.E))
        {
            if (!isMenu())
            {
                menu = Instantiate((GameObject)Resources.Load("Menu/MenuScript"), new Vector3(0f, 0f, 0f), Quaternion.identity) as GameObject;
                menu.GetComponent<Menu>().player_position = player.GetComponent<Transform>().position;
            }
            else
            {
                Destroy(menu);
                menu = null;
            }
        }
        if (!isTalk)
        {
            if (Input.GetKey(KeyCode.T))
            {
                if (canvas.activeSelf) canvas.SetActive(false);
                else canvas.SetActive(true);

            }
        }
        
    }

    public bool isMenu()
    {
        return menu != null;
    }
}
