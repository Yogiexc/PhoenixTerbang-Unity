using UnityEngine;
using UnityEngine.SceneManagement; // Wajib: Untuk pindah scene
using UnityEngine.Video; // Wajib: Untuk mengatur Video Player

public class IntroManager_Bryan : MonoBehaviour
{
    [Header("Setup Komponen")]
    [Tooltip("Tarik komponen Video Player dari kamera ke sini")]
    public VideoPlayer videoPlayer;

    [Header("Tujuan Scene")]
    [Tooltip("Tulis NAMA PERSIS scene gameplay kamu di sini")]
    public string namaSceneGame = "GameScene"; 

    void Start()
    {
        // Pengecekan keamanan
        if (videoPlayer == null)
        {
            Debug.LogError("Video Player belum dimasukkan ke Script IntroManager!");
            return;
        }

        // Mendaftarkan event: "Kalau video habis, panggil fungsi SelesaiVideo"
        videoPlayer.loopPointReached += SelesaiVideo;
    }

    void Update()
    {
        // Fitur Skip: Kalau pemain tekan Spasi atau Enter, langsung masuk game
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.Return))
        {
            MasukKeGame();
        }
    }

    // Fungsi ini otomatis dipanggil Unity saat video selesai
    void SelesaiVideo(VideoPlayer vp)
    {
        MasukKeGame();
    }

    // Fungsi utama untuk pindah scene
    void MasukKeGame()
    {
        Debug.Log("Video Selesai/Diskip. Masuk ke Game...");
        SceneManager.LoadScene(namaSceneGame);
    }
}