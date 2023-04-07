using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using static Unity.VisualScripting.Member;
using static UnityEngine.GraphicsBuffer;

public class UIController : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI scoreValue;
    [SerializeField] private Image[] healthBar;
    [SerializeField] private TextMeshProUGUI healthText;
    //[SerializeField] private Image crossHair;
    [SerializeField] private OptionsPopup optionsPopup;
    [SerializeField] private SettingsPopup settingsPopup;
    [SerializeField] private GameOverPopup gameOverPopup;

    private int popupsActive = 0;
    private void Awake()
    {
        Messenger<int>.AddListener(GameEvent.HEALTH_CHANGED, OnHealthChanged);
        Messenger.AddListener(GameEvent.POPUP_OPENED, OnPopupOpened);
        Messenger.AddListener(GameEvent.POPUP_CLOSED, OnPopupClosed);
    }
    public void ShowGameOverPopup()
    {
        gameOverPopup.Open();
    }
    private void OnPopupOpened()
    {
        if (popupsActive == 0)
        {
            SetGameActive(false);
        }
        popupsActive++;
    }
    private void OnPopupClosed()
    {
        popupsActive--;
        if (popupsActive == 0)
        {
            SetGameActive(true);
        }
    }
    private void OnDestroy()
    {
        Messenger<int>.RemoveListener(GameEvent.HEALTH_CHANGED, OnHealthChanged);
        Messenger.RemoveListener(GameEvent.POPUP_OPENED, OnPopupOpened);
        Messenger.RemoveListener(GameEvent.POPUP_CLOSED, OnPopupClosed);

    }
    // Start is called before the first frame update
    void Start()
    {
        //UpdateHealth(1.0f);
    }

    // Update is called once per frame
    void Update()
    {
        if (popupsActive == 0)
        {
            if (Input.GetKeyDown(KeyCode.Escape) && !optionsPopup.IsActive() && !settingsPopup.IsActive())
            {

                optionsPopup.Open();
            }
        }

    }
    // update score display
    public void UpdateScore(int newScore)
    {
        scoreValue.text = newScore.ToString();
    }

    public void SetGameActive(bool active)
    {
        if (active)
        {
            Time.timeScale = 1; // unpause the game
            Cursor.lockState = CursorLockMode.Locked; // lock cursor at center
            Cursor.visible = false; // hide cursor
            //crossHair.gameObject.SetActive(true); // show the crosshair
            //Messenger.Broadcast(GameEvent.GAME_ACTIVE);

        }
        else
        {
            Time.timeScale = 0; // pause the game
            Cursor.lockState = CursorLockMode.None; // let cursor move freely
            Cursor.visible = true; // show the cursor
            //crossHair.gameObject.SetActive(false); // turn off the crosshair
            //Messenger.Broadcast(GameEvent.GAME_INACTIVE);
        }
    }
    private void UpdateHealth(int healthPoints)
    {
        healthText.text = healthPoints.ToString();
        if (healthPoints >= 0) {
            healthBar[healthPoints].enabled = false;
            // Debug.Log("Image was hidden");
        }
        //healthBar.color = Color.Lerp(Color.red, Color.green, healthPercentage);
        //healthBar.fillAmount = healthPercentage;
    }
    private void OnHealthChanged(int healthPoints)
    {
        UpdateHealth(healthPoints);
    }
}
