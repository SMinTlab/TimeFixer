using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Main : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GameObject floor_wood = (GameObject)Resources.Load("Cells/Floor_wood");
        Transform floor_transform = floor_wood.GetComponent<Transform>();
        Vector3 floor_scale = floor_transform.localScale;
        GameObject player_test = (GameObject)Resources.Load("Characters/Player_test/Main");
        int size = 10;
        for (int i = 0; i < size; i++)
        {
            for (int j = 0; j < size; j++)
            {
                Instantiate(floor_wood, new Vector3((-5.0f + (float)j)*2*floor_scale.x, (-5.0f + (float)i)*2*floor_scale.y, 0.0f), Quaternion.identity);
            }
            
        }
        
        Instantiate(player_test, new Vector3(0.0f, 0.0f, -1.0f), Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
