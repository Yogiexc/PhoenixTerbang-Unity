using UnityEngine;

public class FinishTrigger_Bryan : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        // CCTV 1: Lapor kalau ada APAPUN yang nabrak
        Debug.Log("⚠️ ADA YANG NABRAK GARIS FINISH! Namanya: " + other.gameObject.name);

        // Cek apakah dia bawa KTP "Player"?
        if (other.CompareTag("Player"))
        {
            // CCTV 2: Lapor kalau itu benar-benar Player
            Debug.Log("✅ ITU PLAYER! MENANG!");

            // Panggil GameManager_Bryan
            FindObjectOfType<GameManager_Bryan>().LevelComplete();
        }
        else
        {
            // CCTV 3: Lapor kalau yang nabrak ternyata bukan Player (salah Tag)
            Debug.Log("❌ ITU BUKAN PLAYER! Cek Tag objeknya!");
        }
    }
}