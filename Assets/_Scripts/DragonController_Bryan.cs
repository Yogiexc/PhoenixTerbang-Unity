using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class DragonController_Bryan : MonoBehaviour
{
    [Header("Pengaturan Kecepatan")]
    public float forwardSpeed = 25f;
    public float boostSpeed = 50f;
    public float slowSpeed = 10f;
    public float turnSpeed = 2f;
    public float pitchSpeed = 2f;

    [Header("Efek Visual")] // BARU
    public ParticleSystem dashEffect; // BARU: Slot buat efeknya

    private Rigidbody rb;
    private float currentSpeed;
    private float horizontalInput;
    private float verticalInput;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.useGravity = false;
        currentSpeed = forwardSpeed;

        // BARU: Pastikan efek mati dulu pas mulai
        if (dashEffect != null) dashEffect.Stop();
    }

    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");

        // --- LOGIKA NGEBUT & EFEK ---
        if (Input.GetKey(KeyCode.LeftShift))
        {
            // Lagi tekan Shift (Ngebut)
            currentSpeed = Mathf.Lerp(currentSpeed, boostSpeed, Time.deltaTime * 2f);

            // BARU: Nyalakan efek kalau belum nyala
            if (dashEffect != null && !dashEffect.isPlaying)
            {
                dashEffect.Play();
            }
        }
        else if (Input.GetKey(KeyCode.Space))
        {
            // Lagi ngerem
            currentSpeed = Mathf.Lerp(currentSpeed, slowSpeed, Time.deltaTime * 2f);

            // BARU: Matikan efek kalau sedang nyala
            if (dashEffect != null && dashEffect.isPlaying) dashEffect.Stop();
        }
        else
        {
            // Kecepatan normal
            currentSpeed = Mathf.Lerp(currentSpeed, forwardSpeed, Time.deltaTime * 2f);

            // BARU: Matikan efek kalau sedang nyala
            if (dashEffect != null && dashEffect.isPlaying) dashEffect.Stop();
        }
    }

    void FixedUpdate()
    {
        rb.velocity = transform.forward * currentSpeed;

        Vector3 yaw = horizontalInput * turnSpeed * transform.up;
        Vector3 pitch = -verticalInput * pitchSpeed * transform.right;

        rb.AddTorque(yaw + pitch);
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            Debug.Log("DARR! Nabrak Gunung! Mati!");
            FindObjectOfType<GameManager_Bryan>().GameOver();
        }
    }
}