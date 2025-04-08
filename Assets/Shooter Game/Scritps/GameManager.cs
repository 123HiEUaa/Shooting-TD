using Unity.Cinemachine;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    private int nangLuongHienTai;
    [SerializeField] private int soLuongCanCo = 7;
    [SerializeField] private GameObject boss;
    [SerializeField] private GameObject enemySpawn;
    private bool bossCalled = false;
    [SerializeField] private Image energyBar;
    [SerializeField] GameObject gameUi;

    [SerializeField] private GameObject mainMenu;
    [SerializeField] private GameObject gameOverMenu;
    [SerializeField] private GameObject pauseMenu;
    [SerializeField] private GameObject winMenu;
    [SerializeField] private GameObject red;
    [SerializeField] private AudioManager audioManager;
    [SerializeField] private CinemachineCamera camera;
    void Start()
    {

        nangLuongHienTai = 0;
        UpdateEnergyBar();
        boss.SetActive(false);
        MainMenu();
        audioManager.StopAllSound();
        camera.Lens.OrthographicSize = 5f;
        red.SetActive(false);
    }



    public void AddEnergy()
    {
        if (bossCalled)
        {
            return;
        }
        nangLuongHienTai += 1;
        UpdateEnergyBar();
        if (nangLuongHienTai == soLuongCanCo)
        {
            CallBoss();
        }
    }

    private void CallBoss()
    {
        bossCalled = true;
        boss.SetActive(true);
        enemySpawn.SetActive(false);
        gameUi.SetActive(false);
        audioManager.BossSound();      
        camera.Lens.OrthographicSize = 8f;
        red.SetActive(true);
    }

    private void UpdateEnergyBar()
    {
        
        if (energyBar != null)
        {
            float fillAmount = Mathf.Clamp01((float)nangLuongHienTai / (float)soLuongCanCo);
            energyBar.fillAmount = fillAmount;
        }
    }

    public void MainMenu()
    {
        mainMenu.SetActive(true);
        gameOverMenu.SetActive(false);
        pauseMenu.SetActive(false);
        winMenu.SetActive(false);
        Time.timeScale = 0f;
    }
    public void GameOverMenu()
    {
        gameOverMenu.SetActive(true);
        pauseMenu.SetActive(false);
        mainMenu.SetActive(false);
        winMenu.SetActive(false);
        Time.timeScale = 0f;
    }
    public void PauseMenu() 
    {
        pauseMenu.SetActive(true);
        mainMenu.SetActive(false);
        gameOverMenu.SetActive(false);
        winMenu.SetActive(false);
        Time.timeScale = 0f;
    }
    public void StartGame()
    {
        mainMenu.SetActive(false);
        gameOverMenu.SetActive(false);
        pauseMenu.SetActive(false);
        winMenu.SetActive(false);
        Time.timeScale = 1f;
        audioManager.BackGroundSound();
    }
    public void ContinueGame()
    {
        mainMenu.SetActive(false);
        gameOverMenu.SetActive(false);
        pauseMenu.SetActive(false);
        winMenu.SetActive(false);
        Time.timeScale = 1f;

    }
    public void WinGame()
    {
        winMenu.SetActive(true);
        mainMenu.SetActive(false);
        gameOverMenu.SetActive(false);
        pauseMenu.SetActive(false);
        Time.timeScale = 0f;
    }
}
