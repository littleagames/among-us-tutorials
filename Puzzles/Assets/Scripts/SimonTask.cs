using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SimonTask : MonoBehaviour
{
    public List<GameObject> _simonDisplay;
    public List<Image> _successIndicators;
    public Color LightUpColor;
    public Color LightUpOffColor;
    public float LightUpTime;
    public Color IndicatorOff = Color.gray;
    public Color IndicatorOn = Color.green;
    public Color IndicatorError = Color.red;
    public float WaitBetweenColors;
    public int NumberOfRounds = 5;
    private int[] _pattern;

    private int _currentRound = 0;
    private int _buttonPressRound = 0;
    private bool _waitForPlayerInput = false;
    private bool _waitToStart = true;
    private bool _stepFailed = false;

    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // TODO: Determine if if lighting sequence, or if waiting for player input
    }

    public void ButtonPressed(int index)
    {
        Debug.Log($"Button Presssed: {index}");
        if (_pattern[_buttonPressRound] == index)
        {
            SetCurrentRound(_currentRound + 1);
        }
        else
        {
            _stepFailed = true;
        }

        UpdateIndicators();
        // TODO: Check if pattern was correct
    }

    public void ResetGame()
    {
        Debug.Log("Reset Game");
        _waitToStart = true;
        SetCurrentRound(0);
        _buttonPressRound = 0;
        BuildPattern();
        _stepFailed = false;
    }

    private void BuildPattern()
    {
        // TODO: list of 5
        // TODO: Random # 0-8
        _pattern = new int[NumberOfRounds];
        Random.InitState("littleagames".GetHashCode());
        for (var i = 0; i < NumberOfRounds; i++)
        {
            var rand = Random.Range(0, 8);
            _pattern[i] = rand;
        }
    }

    private void SetCurrentRound(int round)
    {
        _currentRound = round;
        UpdateIndicators();
        _waitForPlayerInput = false;
    }

    private void UpdateIndicators()
    {
        if (_stepFailed)
        {
            foreach (var light in _successIndicators)
            {
                light.color = IndicatorError;
            }

            return;
        }

        foreach (var light in _successIndicators)
        {
            light.color = IndicatorOff;
        }

        for(var i = 0; i < _currentRound; i++)
        {
            _successIndicators[i].color = IndicatorOn;
        }
    }
}
