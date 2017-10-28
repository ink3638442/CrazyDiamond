using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class CamController : MonoBehaviour
{
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
		Camera.main.DOFieldOfView(100, 2);

		// 中心位置, 軸, 度数
		transform.RotateAround(new Vector3(2.5f, 0, 2.5f), new Vector3(0, 1, 0), 0.5f);

		if (Input.GetKey(KeyCode.Space))
		{
			// 中心位置, 軸, 度数
			transform.RotateAround(new Vector3(2.5f, 0, 2.5f), new Vector3(0, 1, 0), -3f);
			Camera.main.DOFieldOfView(1, 2f);
		}
    }
}
