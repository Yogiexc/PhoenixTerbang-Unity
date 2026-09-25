using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager_Bryan : MonoBehaviour
{
    [Header("UI & Teks")]
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI timerText;
    public TextMeshProUGUI bestTimeText;

    [Header("Objek Gambar/Panel")]
    public GameObject winImageObject;
    public GameObject gameOverObject;
    public GameObject pausePanel;

    [Header("Setting Level")]
    public int targetScore = 5;

    [Header("Audio System")]
    public AudioSource musicSource; // Buat Lagu Latar
    public AudioSource sfxSource;   // Buat Suara Menang/Kalah

    [Header("Audio Clips")]
    public AudioClip bgmMusic;      // Lagu Background
    public AudioClip winSound;      // Suara Menang (TETAP ADA)
    public AudioClip loseSound;     // Suara Kalah (TETAP ADA)
    // Score Sound SUDAH DIHAPUS

    // Variabel Internal
    int score = 0;
    float waktuBerjalan = 0;
    bool isGameActive = true;
    bool isPaused = false;

    void Start()
    {
        // NYALAIN MUSIK
        if (musicSource != null && bgmMusic != null)
        {
            musicSource.enabled = true;
            musicSource.clip = bgmMusic;
            musicSource.loop = true;
            musicSource.Play();
        }
    }

    void Update()
    {
        // LOGIKA TIMER
        if (isGameActive && !isPaused)
        {
            waktuBerjalan += Time.deltaTime;
            if (timerText != null)
                timerText.text = FormatWaktu(waktuBerjalan);
        }

        // TOMBOL PAUSE
        if (Input.GetKeyDown(KeyCode.Escape) && isGameActive)
        {
            if (isPaused) ResumeGame(); else PauseGame();
        }
    }

    // --- LOGIKA UTAMA ---

    public void TambahSkor()
    {
        if (isGameActive)
        {
            score++;
            scoreText.text = "Score: " + score + " / " + targetScore;

            // BAGIAN "TING" SUDAH DIHAPUS TOTAL DI SINI
            // Jadi pas ambil skor, hening (cuma musik yang bunyi)
        }
    }

    public void LevelComplete()
    {
        if (score >= targetScore)
        {
            if (isGameActive)
            {
                winImageObject.SetActive(true);
                CekRekorWaktu();

                // Matikan Musik Latar
                if (musicSource != null) musicSource.Stop();

                // Mainkan Suara Menang (TETAP ADA)
                if (sfxSource != null && winSound != null)
                    sfxSource.PlayOneShot(winSound);

                Time.timeScale = 0f;
                isGameActive = false;
                Debug.Log("MENANG!");
            }
        }
        else
        {
            Debug.Log("BELUM CUKUP RING!");
        }
    }

    public void GameOver()
    {
        if (isGameActive)
        {
            if (gameOverObject != null) gameOverObject.SetActive(true);

            // Matikan Musik Latar
            if (musicSource != null) musicSource.Stop();

            // Mainkan Suara Kalah (TETAP ADA)
            if (sfxSource != null && loseSound != null)
                sfxSource.PlayOneShot(loseSound);

            Time.timeScale = 0f;
            isGameActive = false;
            Debug.Log("KALAH!");
        }
    }

    // --- FITUR TAMBAHAN (Rekor & Format Waktu) ---

    void CekRekorWaktu()
    {
        if (bestTimeText == null) return;
        bestTimeText.gameObject.SetActive(true);

        float rekorLama = PlayerPrefs.GetFloat("BestTime", 9999f);

        if (waktuBerjalan < rekorLama)
        {
            PlayerPrefs.SetFloat("BestTime", waktuBerjalan);
            bestTimeText.text = "NEW RECORD! \n" + FormatWaktu(waktuBerjalan);
            bestTimeText.color = Color.yellow;
        }
        else
        {
            bestTimeText.text = "Your Time: " + FormatWaktu(waktuBerjalan) + "\nBest Time: " + FormatWaktu(rekorLama);
            bestTimeText.color = Color.white;
        }
    }

    string FormatWaktu(float waktu)
    {
        int menit = Mathf.FloorToInt(waktu / 60);
        int detik = Mathf.FloorToInt(waktu % 60);
        return string.Format("{0:00}:{1:00}", menit, detik);
    }

    // --- SISTEM PAUSE ---

    public void PauseGame()
    {
        pausePanel.SetActive(true);
        if (musicSource != null) musicSource.Pause();
        Time.timeScale = 0f;
        isPaused = true;
    }

    public void ResumeGame()
    {
        pausePanel.SetActive(false);
        if (musicSource != null) musicSource.UnPause();
        Time.timeScale = 1f;
        isPaused = false;
    }

    public void RestartGame()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void KeMenuUtama()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainMenu_Bryan");
    }
}