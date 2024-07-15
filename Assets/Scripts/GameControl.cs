using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameControl : MonoBehaviour
{

    [SerializeField] private GameObject _gameNamePanel;
    [SerializeField] private GameObject _playButton;
    [SerializeField] private GameObject _descriptionPanel;
    [SerializeField] private GameObject _startButton;
    [SerializeField] private GameObject _timerPanel;
    [SerializeField] private GameObject _pin1Panel;
    [SerializeField] private GameObject _pin2Panel;
    [SerializeField] private GameObject _pin3Panel;
    [SerializeField] private GameObject _drillButton;
    [SerializeField] private GameObject _hummerButton;
    [SerializeField] private GameObject _lockpickButton;
    [SerializeField] private Text _timerText;
    [SerializeField] private GameObject _losePanel;
    [SerializeField] private GameObject _retryButton;
    [SerializeField] private Text _pin1Text;
    [SerializeField] private Text _pin2Text;
    [SerializeField] private Text _pin3Text;
    [SerializeField] private GameObject _winPanel;
    [SerializeField] private int _givenTime;

    private bool isGameOn;
    private float remainedTime;
    private float currentTime;
    private float startTime;
    private int pin1value;
    private int pin2value;
    private int pin3value;

    public void Start()  
    {
        _gameNamePanel.SetActive(true);
        _playButton.SetActive(true);

        _descriptionPanel.SetActive(false);
        _startButton.SetActive(false);

        SetGameElements(false);

        _losePanel.SetActive(false);
        _retryButton.SetActive(false);

        _winPanel.SetActive(false);

        isGameOn = false;
    }

    public void Update()  
    {
        currentTime = Mathf.Round(Time.time);

        if (isGameOn)
        {
            remainedTime = _givenTime - (currentTime - startTime);
            _timerText.text = remainedTime.ToString();

            if (pin1value == 5 && pin2value == 5 && pin3value == 5)
            {
                SetGameElements(false);

                _winPanel.SetActive(true);
                _retryButton.SetActive(true);

                isGameOn = false;
            }
            
            if (remainedTime <= 0)
            {
                SetGameElements(false);

                _losePanel.SetActive(true);
                _retryButton.SetActive(true);

                isGameOn = false;
            }
        }
    }

    public void OnPlayClick()  
    {
        _gameNamePanel.SetActive(false);
        _playButton.SetActive(false);

        _descriptionPanel.SetActive(true);
        _startButton.SetActive(true);
    }

    public void OnStartClick()
    {
        _descriptionPanel.SetActive(false);
        _startButton.SetActive(false);

        SetGameElements(true);

        _losePanel.SetActive(false);
        _retryButton.SetActive(false);

        _winPanel.SetActive(false);

        pin1value = Random.Range(0, 11);
        pin2value = Random.Range(0, 11);
        pin3value = Random.Range(0, 11);
        SetPinText();

        isGameOn = true;
        remainedTime = _givenTime;
        startTime = currentTime;
        _timerText.text = remainedTime.ToString();
    }

    public void SetGameElements(bool setValue)
    {
        _timerPanel.SetActive(setValue);
        _pin1Panel.SetActive(setValue);
        _pin2Panel.SetActive(setValue);
        _pin3Panel.SetActive(setValue);
        _drillButton.SetActive(setValue);
        _hummerButton.SetActive(setValue);
        _lockpickButton.SetActive(setValue);
    }

    public void SetPinText()
    {
        _pin1Text.text = pin1value.ToString();
        _pin2Text.text = pin2value.ToString();
        _pin3Text.text = pin3value.ToString();
    }

    public void OnDrillClick()
    {
        if (pin1value < 10)
            pin1value = pin1value + 1;
        if (pin2value > 0)
            pin2value = pin2value - 1;
        SetPinText();        
    }

    public void OnHummerClick()
    {
        if (pin1value > 0)
            pin1value = pin1value - 1;
        if (pin2value < 9)
            pin2value = pin2value + 2;
        else
            pin2value = 10;
        if (pin3value > 0)
            pin3value = pin3value - 1;
        SetPinText();
    }

    public void OnLockpickClick()
    {
        if (pin1value > 0)
            pin1value = pin1value - 1;
        if (pin2value < 10)
            pin2value = pin2value + 1;
        if (pin3value < 10)
            pin3value = pin3value + 1;
        SetPinText();
    }
}
