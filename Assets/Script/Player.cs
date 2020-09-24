using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
	public Main main;
    Vector3 MOVE_X = new Vector3(Main.CELL_SIZE, 0, 0);
    Vector3 MOVE_Y = new Vector3(0, Main.CELL_SIZE, 0);

    float steps = 2.5f;
    Vector3 target;
    Vector3 prevPos;

    Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        target = transform.position;
		animator = GetComponent<Animator>();
		
		
	}

    // Update is called once per frame
    void Update()
    {
        if (!main.isMenu())
        {
			if (transform.position == target)
			{
				SetTargetPosition();
			}
			Move();
		}
        
    }

    void SetTargetPosition(){
        prevPos = target;
 
		if (Input.GetKey (KeyCode.RightArrow)) {
			target = transform.position + MOVE_X;
			SetAnimationParam (1);
			return;
		}
		if (Input.GetKey (KeyCode.LeftArrow)) {
			target = transform.position - MOVE_X;
			SetAnimationParam (2);
			return;
		}
		if (Input.GetKey (KeyCode.UpArrow)) {
			target = transform.position + MOVE_Y;
			SetAnimationParam (3);
			return;
		}
		if (Input.GetKey (KeyCode.DownArrow)) {
			target = transform.position - MOVE_Y;
			SetAnimationParam (0);
			return;
		}
    }

    // WalkParam  0;下移動　1;右移動　2:左移動　3:上移動
	void SetAnimationParam(int param){
		animator.SetInteger ("walk", param);
		animator.SetTrigger("walk_trigger");
	}
 
	// ③ 目的地へ移動する
	void Move(){
		transform.position = Vector3.MoveTowards (transform.position, target, steps * Time.deltaTime);
	}
}
