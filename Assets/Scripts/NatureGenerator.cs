using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NatureGenerator : MonoBehaviour
{
    public GameObject[] objects;

    public void PlaceTrees(Map map,Vector3 sizemap)
    {



        //erosao
        for (int i = (int)(sizemap.x / 2) - (int)sizemap.x; i < sizemap.x / 2; i++)
        {
            for (int j = (int)(sizemap.z / 2) - (int)sizemap.z; j < sizemap.z / 2; j++)
            {

                int r = Random.Range(0, 100);
                if (r > 90)
                {
                   if( map.mapdata[i + (int)(sizemap.x / 2), j + (int)(sizemap.z / 2), (int)sizemap.y - 1] == -1)
                    {
                        Instantiate(objects[0], new Vector3(i,-15, j), Quaternion.identity, gameObject.transform);
                    }
                    else
                    {
                        Instantiate(objects[0], new Vector3(i, -16, j), Quaternion.identity, gameObject.transform);
                    }
                }
            }

        }



    }
}
