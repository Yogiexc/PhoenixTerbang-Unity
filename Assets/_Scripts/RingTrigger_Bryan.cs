using UnityEngine;

public class RingTrigger_Bryan : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // 1. Cari GameManager_Bryan dan lapor "Tambah Skor dong!"
            FindObjectOfType<GameManager_Bryan>().TambahSkor();

            // 2. Hancurkan Donat (Bapaknya)
            Destroy(transform.parent.gameObject);
        }
    }
}