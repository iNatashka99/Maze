using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveFire : MonoBehaviour
{
    public float R,height;
    private float alpha;
    public float speed;
    // Start is called before the first frame update
    private void Start()
    {
        transform.localPosition = new Vector3(R,height,R);
        alpha = 0;
    }
    // Update is called once per frame
    void Update()
    {
        alpha = alpha + Time.deltaTime*speed;
        float x = R * Mathf.Cos(alpha);
        float y = R * Mathf.Sin(alpha);
        transform.localPosition = new Vector3(x, height, y);

    }
}
