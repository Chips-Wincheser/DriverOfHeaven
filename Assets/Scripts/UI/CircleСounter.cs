using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CircleСounter : MonoBehaviour
{
    [SerializeField] private RaceStarted _race;
    [SerializeField] private TMP_Text _text;

    private void OnEnable()
    {
        _race.CircleComplited+=RenderCircle;
    }

    private void OnDisable()
    {
        _race.CircleComplited-=RenderCircle;
    }

    private void RenderCircle(int circlePlayer)
    {
        _text.text=$"{circlePlayer}/4";
    }
}
