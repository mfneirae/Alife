using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fractalplant : MonoBehaviour {
    public float _degree, _scale;
    public int _numberStart;
    private int _number;
    private TrailRenderer _trailRender;
    public float _maxSize;
    System.Random rnd;
    private Vector2 CalculateFractal(float degree, float scale, int number)
    {
        double angle = number * (degree * Mathf.Deg2Rad);
        float r = scale * Mathf.Sqrt(number);
        float x = r * (float)System.Math.Cos(angle);
        float y = r * (float)System.Math.Sin(angle);
        Vector2 vec2 = new Vector2(x, y);
        return vec2;
    }
    private Vector2 _fractalposition;
	// Use this for initialization
	void Start () {
        rnd = new System.Random(GetInstanceID());
        _maxSize = rnd.Next(100, 200);
    }

    private void Awake()
    {
        _trailRender = GetComponent<TrailRenderer>();
        _number = _numberStart;
        transform.localPosition = CalculateFractal(_degree, _scale, _number);
    }

    // Update is called once per frame
    void FixedUpdate () {
        if (_number < _maxSize)
        {
            _fractalposition = CalculateFractal(_degree, _scale, _number);
            transform.localPosition = new Vector3(_fractalposition.x, _fractalposition.y, 0);
            _number++;
        }
    }
}
