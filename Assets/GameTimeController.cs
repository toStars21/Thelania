using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameTimeController : MonoBehaviour
{
    public static GameTimeController Instance;
    public Text TimeCounter;

    private TimeSpan _playingTime;
    private bool _timerGoing;
    private float _elapsedTime;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        TimeCounter.text = "0:00";
        _timerGoing = false;
    }

    public void BeginTimer()
    {
        _timerGoing = true;
        _elapsedTime = 0f;

        StartCoroutine(UpdateTimer());
    }

    public void EndTimer()
    {
        _timerGoing = false;
    }

    private IEnumerator UpdateTimer()
    {
        while (_timerGoing)
        {
            _elapsedTime += Time.deltaTime;
            _playingTime = TimeSpan.FromSeconds(_elapsedTime);
            var timePlayingStr = _playingTime.ToString("mm':'ss");
            TimeCounter.text = timePlayingStr;

            yield return null;
        }
    }


}
