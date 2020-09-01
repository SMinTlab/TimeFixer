using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;
using DG.Tweening;

public class Menu : MonoBehaviour
{
    [SerializeField] public int num = 6;
    List<GameObject> menu_items = new List<GameObject>();
    int select_index = 0;
    float theta = 0;
    int moving = 0;
    float duration = 0.5f;


    // Start is called before the first frame update
    void Start()
    {
        DG.Tweening.DOTween.SetTweensCapacity(tweenersCapacity: 800, sequencesCapacity: 200);
        theta = 2.0f*Mathf.PI/num;
        GameObject menu_empty = (GameObject)Resources.Load("MenuItems/menu_empty");
        Vector3 menu_empty_scale = menu_empty.GetComponent<Transform>().localScale;
        menu_empty_scale.x = 0.5f;
        menu_empty_scale.y = 0.5f;

        for (int i = 0; i < num; i++)
        {
            menu_items.Add(Instantiate(menu_empty, new Vector3(Mathf.Sin(theta * i), Mathf.Cos(theta * i), 0.0f), Quaternion.identity));
            
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        if (moving != 0)
        {

        }
        else
        {
            if (Input.GetKey(KeyCode.RightArrow))
            {
                moving = 1;
                select_index = (select_index + 1) % num;
                PlayMoveTween();

            }
            if (Input.GetKey(KeyCode.LeftArrow))
            {
                moving = -1;
                select_index = (select_index - 1) % num;
                PlayMoveTween();
            }
        }
    }

    void PlayMoveTween()
    {

        for(int i=0; i < num; i++)
        {
            Transform rect = menu_items[i].transform;
            
            Tween t = rect.DOMove(new Vector3(Mathf.Sin(theta * (i + select_index)), Mathf.Cos(theta * (i + select_index)), 0f), duration
            ).OnComplete(()=> {
                moving = 0;
            });

        }
    }
}
