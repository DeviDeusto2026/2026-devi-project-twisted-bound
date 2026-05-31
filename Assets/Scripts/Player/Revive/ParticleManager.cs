using UnityEngine;

public class ParticleManager : MonoBehaviour
{
    [SerializeField] ParticleSystem pSystem;
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
        pSystem.Stop();
        pSystem.Play();
    }
}
