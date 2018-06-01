using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fractalplant2 : MonoBehaviour {
    public GameObject _dot;
    public float _degree, _c;
    private int _n;
    public float _dotScale;
    public float _maxSize;
    public int _numberStart;
    System.Random rnd;
    private Vector2 CalculateFractal(float degree, float scale, int count)
    {
        double angle = count * (degree * Mathf.Deg2Rad);
        float r = scale * Mathf.Sqrt(count);
        float x = r * (float)System.Math.Cos(angle);
        float y = r * (float)System.Math.Sin(angle);
        Vector2 vec2 = new Vector2(x, y);
        return vec2;
    }
    private Vector2 _fractalposition;
    // Use this for initialization
    void Start()
    {
        rnd = new System.Random(GetInstanceID());
        _maxSize = rnd.Next(100, 200);
    }

    private void Awake()
    {
        _n = _numberStart;
        transform.localPosition = CalculateFractal(_degree, _c, _n);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (_n < _maxSize)
        {
            _fractalposition = CalculateFractal(_degree, _c, _n);
            GameObject dotInstance = (GameObject)Instantiate(_dot);
            dotInstance.transform.localPosition = new Vector3(_fractalposition.x, _fractalposition.y, 0);
            dotInstance.transform.localScale = new Vector3(_dotScale, _dotScale, _dotScale);
            _n++;
        }
    }
}