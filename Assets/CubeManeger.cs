using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;


public class CubeManeger : MonoBehaviour
{
	const int CUBE_NUMS = 5;

    [SerializeField]
	GameObject cubePrefab;

    List<GameObject> cubeList = new List<GameObject>();

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

                    cubeList.Add(go);
                }
            }
        }
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

                        cubeList[index].transform.DOMove(new Vector3(x, y, z), 1f);
                        cubeList[index].transform.rotation = Quaternion.identity;
                    }
                }
            }
        }
    }
}
