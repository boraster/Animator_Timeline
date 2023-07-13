using UnityEngine;
using UnityEngine.Timeline;

public class ControlAnimation : MonoBehaviour, ITimeControl
{
    public ParticleSystem particles;
    private float timer;
    [SerializeField] private float changeInterval = 1.0f;

    private void Awake()
    {
        var em = particles.emission;
        em.rateOverTime = 10;
    }

    public void SetTime(double time)
    {
        timer += Time.deltaTime;
        var particleRate = Random.Range(10, 1000);
        if (timer >= changeInterval)
        {
            var em = particles.emission;
            em.rateOverTime = particleRate;
        }
    }

    public void OnControlTimeStart()
    {
        // particles.Play();
    }

    public void OnControlTimeStop()
    {
        particles.Stop();
        particles.Clear();
    }
}