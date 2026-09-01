using System.Collections;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

namespace KomorebiKitchen
{
    public class GameManager : MonoBehaviour
    {
        [field: SerializeField] public int Money { get; private set; }
        public string TimeText { get; private set; }

        private int _day;

        [SerializeField] private int _closeHour;

        public float ClockMinute { get; private set; }

        private bool _isPause;

        public UnityEvent<bool> OnSetting { get; private set; } = new();
        public UnityEvent<int> OnDateUpdated { get; private set; } = new();
        public UnityEvent<string> OnTimeUpdated { get; private set; } = new();
        public UnityEvent<int> OnMoneyUpdated { get; private set; } = new();

        public UnityEvent<bool> OnShopMenu { get; private set; } = new();

        MainUI MainUI;

        [Header("Input References")]
        public InputActionReference _pauseGame;
        public InputActionReference _openShopMenu;

        private void OnEnable()
        {
            _pauseGame.action.Enable();
            _openShopMenu.action.Enable();
            
            _pauseGame.action.performed += Pause;
            _openShopMenu.action.performed += OpenShopMenu;
        }

        private void OpenShopMenu(InputAction.CallbackContext context)
        {
            bool isPause;

            if (Time.timeScale == 0)
            {
                UnityEngine.Cursor.lockState = CursorLockMode.Locked;
                Time.timeScale = 1;
                isPause = false;

            }
            else
            {
                UnityEngine.Cursor.lockState = CursorLockMode.None;
                Time.timeScale = 0;
                isPause = true;
            }


            OnShopMenu.Invoke(isPause);
        }



        private void ShopTest(UIDocument ttt)
        {
            
        }


        private void OnDisable()
        {
            _pauseGame.action.Disable();
            _openShopMenu.action.Disable();


            _pauseGame.action.performed -= Pause;
            _openShopMenu.action.performed -= OpenShopMenu;
        }

        


        private void Pause(InputAction.CallbackContext context)
        {
            bool isPause;

            if (Time.timeScale == 0)
            {
                UnityEngine.Cursor.lockState = CursorLockMode.Locked;
                Time.timeScale = 1;
                isPause = false;

            }
            else
            {
                UnityEngine.Cursor.lockState = CursorLockMode.None;
                Time.timeScale = 0;
                isPause = true;
            }

            OnSetting.Invoke(isPause);
            //Time.timeScale = Time.timeScale == 1 ? 0 : 1;
        }

        public static GameManager Instance { get; private set; }

        private void Awake()
        {
            if (Instance != null)
            {
                Destroy(this);
                Debug.LogError("Found more than one Game Manager in The Scene");
            }
            else
            {
                Instance = this;
            }
        }

        private void Start()
        {
            _day = PlayerPrefs.GetInt("Day");
            Debug.Log($"New Day = {_day}");
            OnDateUpdated.Invoke(_day);
            StartCoroutine(GameClock());
        }

        public void AddMoney(int amount)
        {
            Money += amount;
            Debug.Log("Money = " + Money);

            OnMoneyUpdated.Invoke(Money);

            AudioManager.Instance.PlayOneShot(FMODEvents.Instance.AddMoney, default);

        }

        public void LoadNextDay()
        {
            _day++;
            PlayerPrefs.SetInt("Day", _day);
            PlayerPrefs.Save();
            SceneManager.LoadScene(0);
        }

        private IEnumerator GameClock()
        {
            int hour = 9;
            int minute = 0;

            while (true)
            {
                minute++;

                if (minute >= 60)
                {
                    minute = 0;
                    hour++;
                }

                if (hour >= 24)
                {
                    hour = 0;
                }

                if (hour == _closeHour)
                {
                    LoadNextDay();
                }

                //clockText.text = $"{hour:00}:{minute:00}";
                TimeText = $"{hour:00}:{minute:00}";
                OnTimeUpdated.Invoke(TimeText);
                yield return new WaitForSeconds(0.67f); // 1 วิ = 1 นาทีในเกม
            }
        }
    }
}