using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingsControl : MonoBehaviour
{
    public int _speed;
    public int _jump;

    public void Quality(int q)
    {
        QualitySettings.SetQualityLevel(q);
    }

    public void AcceptSpeed()
    {
        DataHolder.speed = _speed;
        Debug.Log("Установлена скорость: " + DataHolder.speed);
    }

    public void AcceptJump()
    {
        DataHolder.jump = _jump;
        Debug.Log("Установлен прыжок с высотой: " + DataHolder.jump);
    }

    public void AcceptColor()
    {
        int r1, g1, b1;
        r1 = Random.Range(0, 255);
        g1 = Random.Range(0, 255);
        b1 = Random.Range(0, 255);
        DataHolder.r = r1 / 255f;
        DataHolder.g = g1 / 255f;
        DataHolder.b = b1 / 255f;
        Debug.Log("Установлен цвет: " + r1 + " " + g1 + " " + b1);
    }
}