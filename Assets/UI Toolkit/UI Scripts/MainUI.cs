using KomorebiKitchen;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class MainUI : MonoBehaviour
{
    private VisualElement _root;

    private Label _dateLabel;
    private Label _timeLabel;
    private Label _moneyLabel;

    private VisualElement _gameDataElement;
    private VisualElement _settingElement;

    [SerializeField] private GameManager _gameManager;

    private void OnEnable()
    {
        _gameManager.OnSetting.AddListener(PopupSetting);
        _gameManager.OnDateUpdated.AddListener(UpdateDateUI);
        _gameManager.OnTimeUpdated.AddListener(UpdateTimeUI);
        _gameManager.OnMoneyUpdated.AddListener(UpdateMoneyUI);
    }

    private void OnDisable()
    {
        _gameManager.OnSetting.AddListener(PopupSetting);
        _gameManager.OnDateUpdated.RemoveListener(UpdateDateUI);
        _gameManager.OnTimeUpdated.RemoveListener(UpdateTimeUI);
        _gameManager.OnMoneyUpdated.RemoveListener(UpdateMoneyUI);
    }

    private void Awake()
    {
        _root = GetComponent<UIDocument>().rootVisualElement;
        _gameDataElement = _root.Q<VisualElement>("GameData");
        _settingElement = _root.Q<VisualElement>("Setting");
        _dateLabel = _root.Q<Label>("Date");
        _timeLabel = _root.Q<Label>("Time");
        _moneyLabel = _root.Q<Label>("Money");
    }

    private void Start()
    {
        //_moneyText.text = "6666";
        //_timeText.text = "111";
    }


    public void UpdateDateUI(int day)
    {
        _dateLabel.text = day.ToString();
    }

    private void UpdateTimeUI(string timeText)
    {
        _timeLabel.text = timeText;
    }

    private void UpdateMoneyUI(int money)
    {
        _moneyLabel.text = money.ToString();
    }

    private void PopupSetting(bool isPause)
    {
        if (isPause == true)
        {
            _gameDataElement.style.display = DisplayStyle.None;
            _settingElement.style.display = DisplayStyle.Flex;
        }
        else
        {
            _gameDataElement.style.display = DisplayStyle.Flex;
            _settingElement.style.display = DisplayStyle.None;
        }
    }
}
