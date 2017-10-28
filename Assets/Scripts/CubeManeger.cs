using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;


public class CubeManeger : MonoBehaviour
{
	const int CUBE_NUMS = 5;

    [SerializeField]
	GameObject cubePrefab;

	GameObject bigCube;

    List<GameObject> cubeList = new List<GameObject>();

    AudioSource set_as;
	AudioClip setSE;

    bool isSet = true;

    // Use this for initialization
    void Start()
    {
        for (int x = 0; x < CUBE_NUMS; x++)
        {
            for (int y = 0; y < CUBE_NUMS; y++)
            {
                for (int z = 0; z < CUBE_NUMS; z++)
                {
                    GameObject go = Instantiate(cubePrefab) as GameObject;
                    go.transform.position = new Vector3(x, y, z);

					bigCube = GameObject.Find("BigCube");
					go.transform.parent = bigCube.transform;
					
                    cubeList.Add(go);
                }
            }
        }
		bigCube.transform.Rotate(30, 30, 130);

        set_as = GetComponent<AudioSource>();
        setSE = set_as.clip;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            for (int x = 0; x < CUBE_NUMS; x++)
			{
				for (int y = 0; y < CUBE_NUMS; y++)
				{
					for (int z = 0; z < CUBE_NUMS; z++)
					{
						int index = z + (y * CUBE_NUMS) + (x * CUBE_NUMS * CUBE_NUMS);

                        cubeList[index].transform.DOMove(new Vector3(x, y, z), 2);
                        cubeList[index].transform.DORotate(new Vector3(0, 0, 0), 2);
                    }
                }
            }

            if (isSet)
            {
                set_as.PlayOneShot(setSE, 1);
                isSet = false;
            }
        }
        
        if (Input.GetKeyUp(KeyCode.Space))
        {
            // トゥイーン全解除
            DOTween.KillAll();
            // 無重力
            Physics.gravity = Vector3.zero;

            // 爆発
            for (int x = 0; x < CUBE_NUMS; x++)
			{
				for (int y = 0; y < CUBE_NUMS; y++)
				{
					for (int z = 0; z < CUBE_NUMS; z++)
					{
						int index = z + (y * CUBE_NUMS) + (x * CUBE_NUMS * CUBE_NUMS);
                        int v_x = Random.Range(-1000,1000);
                        int v_y = Random.Range(-1000,1000);
                        int v_z = Random.Range(-1000,1000);

                        Rigidbody rb = cubeList[index].GetComponent<Rigidbody>();
                        rb.AddForce(new Vector3(v_x, v_y, v_z));
                    }
                }
            }
            isSet = true;
        }
    }
}
