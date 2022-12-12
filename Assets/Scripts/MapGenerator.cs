using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;

public class MapGenerator : MonoBehaviour
{
    [SerializeField]
    private BlockManager blockManager;
    [SerializeField]
    Vector3 sizemap;
    // Start is called before the first frame update
    void Awake()
    {
        StartCoroutine(GenerateMap());
    }


    IEnumerator GenerateMap()
    {

        Time.timeScale = 0;
        int block = 0;
        Map map= new Map();

        for (int i = (int)(sizemap.x / 2) - (int)sizemap.x; i < sizemap.x / 2; i++)
        {
            for (int j = (int)(sizemap.z / 2) - (int)sizemap.z; j < sizemap.z / 2; j++)
            {
                for (int k = (int)-sizemap.y; k < 0; k++)
                {
                    int r = Random.Range(0, 3);
                   Instantiate(blockManager.objects[r], new Vector3(i, k, j), Quaternion.identity,gameObject.transform);
                   map.mapdata[i+ (int)(sizemap.x / 2), j+ (int)(sizemap.z / 2), k+(int) sizemap.y] = r;
                    
                }
                
            }
            yield return new WaitForEndOfFrame();
        }
        SaveManager.Save(map);
        Time.timeScale = 1;

    }
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
