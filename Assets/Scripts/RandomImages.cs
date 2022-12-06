using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomImages : MonoBehaviour
{

    public GameObject obj;
    public int num;
    public float min_width,width, height, min_height;


    // Start is called before the first frame update
    void Start()
    {
        for (int i=0;i<num;i++)
        {
            float x = Random.Range(min_width, width);
            float y = Random.Range(min_height, height);
            float z = Random.Range(min_width, width);

            Vector3 pos = new Vector3(x, y, z);
            Vector3 rot = new Vector3(90, 0, 0);

            GameObject f = Instantiate(obj);
            
            f.transform.position = pos;
            f.transform.Rotate(rot);f.transform.parent = transform;

        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
