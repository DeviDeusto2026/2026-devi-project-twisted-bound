using UnityEngine;

public class ParticleManager : MonoBehaviour
{
    [SerializeField] ParticleSystem particleSystem;
    [SerializeField] float timerMax;
    float timer;

    private void Start()
    {
        timer = timerMax;
    }


    void Update()
    {
        timer -= Time.deltaTime;

        if (timer > 0) return;

        timer = timerMax;
        particleSystem.Stop();
        particleSystem.Play();
    }
}
