using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossUI : MonoBehaviour
{

    public RawImage Cliff;
    public RawImage Mountain;
    public RawImage Cave;

    public Color WrongColor;
    public Color GoodColor;
    // Start is called before the first frame update
    void Start()
    {
        changeColor(true, null);
    }

    public void changeColor(bool locked, string name)
    {
        if (locked)
        {
            Cliff.color = WrongColor;
            Mountain.color = WrongColor;
            Cave.color = WrongColor;
        }
        else
        {
            if (Cliff.name == name)
            {
                Cliff.color = GoodColor;
            }
            else if (Mountain.name == name)
            {
                Mountain.color = GoodColor;
            }
            else if (Cave.name == name)
            {
                Cave.color = GoodColor;
            }
        }
    }
}
