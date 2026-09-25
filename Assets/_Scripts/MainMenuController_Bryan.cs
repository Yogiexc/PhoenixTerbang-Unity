using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController_Bryan : MonoBehaviour
{
    [Header("Scene Settings")]
    // UBAH DISINI: Ganti "GameScene" jadi "IntroScene"
    public string namaScenePermainan = "IntroScene"; 

    [Header("UI Panels")]
    public GameObject panelPanduan; 

    public void TombolMulai()
    {
        // Pastikan namaScenePermainan isinya "IntroScene"
        SceneManager.LoadScene(namaScenePermainan);
    }

    public void TombolPanduan(bool tampilkan)
    {
        panelPanduan.SetActive(tampilkan);
    }

    public void TombolKeluar()
    {
        Debug.Log("Aplikasi Keluar!");
        Application.Quit();
        // Baris di bawah ini hanya agar tombol keluar bekerja saat tes di Unity Editor
        #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
        #endif
    }
}