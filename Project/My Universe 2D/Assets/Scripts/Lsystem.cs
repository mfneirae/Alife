using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lsystem : MonoBehaviour {
    private string axiom = "F";
    private string currentString;
    private Dictionary<char, string> rules = new Dictionary<char, string>();
    private float angle;
    private float length;
    private float count;
    private float x;
    public float period = 3.0f;
    private float nexactiontime = 0.0f;
    private Stack<Transforminfo> transformStack = new Stack<Transforminfo>();
    void Start()
    {
        rules.Add('F', "FF-[-F+F+F]+[+F-F-F]");
        currentString = axiom;
        angle = 22.5f;
        length = 0.3f;
        count = Mathf.Round(Random.Range(2.0f, 3.0f));
        x = 1;
        Generate();
    }
    private void FixedUpdate()
    {
        if (Time.time > nexactiontime)
        {
            nexactiontime += period;
            if (count > 0.0f )
            {
                count -= 1;
                angle = Random.Range(15.0f, 50.0f) * Mathf.Pow(-1,count);
                if (count == 1)
                {
                    x = 0;
                }
                Generate();
            }
        }
    }
    void Generate()
    {
        length = length * 0.6f;
        string newString = "";
        char[] stringCharacters = currentString.ToCharArray();
        for (int i = 0; i < stringCharacters.Length; i++)
        {
            char currentCharacter = stringCharacters[i];
            if (rules.ContainsKey(currentCharacter))
            {
                newString += rules[currentCharacter];
            }
            else
            {
                newString += currentCharacter.ToString();
            }
        }
        currentString = newString;
        for (int i = 0; i < stringCharacters.Length; i++)
        {            char currentCharacter = stringCharacters[i];
            if (currentCharacter == 'F')
            {
                Vector3 initialPosition = transform.position;
                transform.Translate(Vector3.up * length);
                if (x==1)
                {
                    Debug.DrawLine(initialPosition, transform.position, Color.red, Time.deltaTime * 1000000, false);
                }
                else
                {
                    Debug.DrawLine(initialPosition, transform.position, Color.green, Time.deltaTime * 1000000, false);
                }
            }
            else if (currentCharacter == '+')
            {
                transform.Rotate(Vector3.forward * angle);
            }
            else if (currentCharacter == '-')
            {
                transform.Rotate(Vector3.forward * -angle);
            }
            else if (currentCharacter == '[')
            {
                Transforminfo ti = new Transforminfo();
                ti.position = transform.position;
                ti.rotation = transform.rotation;
                transformStack.Push(ti);
            }
            else if (currentCharacter == ']')
            {
                Transforminfo ti = transformStack.Pop();
                transform.position = ti.position;
                transform.rotation = ti.rotation;
            }
        }
    }
}
