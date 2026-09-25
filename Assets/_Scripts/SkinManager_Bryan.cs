using UnityEngine;

public class SkinManager_Bryan : MonoBehaviour
{
    public GameObject PhoenixSatu; // Drag Naga Awal ke sini
    public GameObject PhoenixDua;  // Drag Naga Baru ke sini

    void Start()
    {
        // Baca memori: Player milih nomor berapa? (Default nomor 1)
        int pilihan = PlayerPrefs.GetInt("PilihanPhoenix", 1);

        if (pilihan == 1)
        {
            PhoenixSatu.SetActive(true);
            PhoenixDua.SetActive(false);
        }
        else
        {
            PhoenixSatu.SetActive(false);
            PhoenixDua.SetActive(true);
        }
    }
}