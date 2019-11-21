using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fun : MonoBehaviour
{
    public float scale = 1f;
    public float freq = 1;
    public float factor = 1f;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Random.value < 0.5)
        {
            Vector2 vec = Vector2.one;
            vec *= Mathf.Sin(Time.time * freq) * Time.deltaTime * scale;
            transform.localScale = vec;

            Vector2 asd = transform.localScale;
            asd.x = Mathf.Abs(Mathf.Clamp(transform.localScale.x, 0.67f, 1.2f));
            asd.y = Mathf.Abs(Mathf.Clamp(transform.localScale.x, 2f, 3f));

            transform.localScale = asd / factor;
        }
    }
}
