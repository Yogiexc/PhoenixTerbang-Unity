using UnityEngine;
using UnityEngine.UI; // Biar bisa ubah warna tombol (Opsional)

public class CharacterSelector_Bryan : MonoBehaviour
{
    public void PilihPhoenixNomor1()
    {
        // Simpan angka 1 ke memori
        PlayerPrefs.SetInt("PilihanPhoenix", 1);
        Debug.Log("Pilih Phoenix 1");
    }

    public void PilihPhoenixNomor2()
    {
        // Simpan angka 2 ke memori
        PlayerPrefs.SetInt("PilihanPhoenix", 2);
        Debug.Log("Pilih Phoenix 2");
    }
}