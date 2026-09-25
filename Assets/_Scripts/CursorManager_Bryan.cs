using UnityEngine;

public class CursorManager_Bryan : MonoBehaviour
{
    [Header("Pengaturan Kursor")]
    [Tooltip("Tarik gambar kursor yang Texture Type-nya sudah diubah jadi 'Cursor' ke sini.")]
    public Texture2D kursorBaru;

    [Header("Titik Sentuh (Hotspot)")]
    [Tooltip("Titik di mana klik akan terdeteksi (dalam pixel dari pojok kiri atas gambar).")]
    public Vector2 hotspot = Vector2.zero;

    [Header("Mode")]
    [Tooltip("Biarkan Auto agar Unity menyesuaikan dengan platform.")]
    public CursorMode cursorMode = CursorMode.Auto;

    void Start()
    {
        // Ini baris ajaib yang mengganti kursor saat scene dimulai
        // Parameter: (Gambar Tekstur, Titik Hotspot, Mode Kursor)
        Cursor.SetCursor(kursorBaru, hotspot, cursorMode);
    }
}