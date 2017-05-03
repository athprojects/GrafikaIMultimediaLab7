using UnityEngine;

public class FireBehaviour : MonoBehaviour
{

    public ParticleSystem Fire;
    public ParticleSystem Smoke;

    private bool _keyFWasReleased;
    private bool _keySWasReleased;
    private bool _fireShouldBeOn;
    private bool _smokeShouldBeOn;
	// Use this for initialization
	void Start ()
	{
	    _fireShouldBeOn = false;
	    _smokeShouldBeOn = false;
	    _keyFWasReleased = true;
	    _keySWasReleased = true;
	}
	
	// Update is called once per frame
	void Update ()
	{
	    if (CheckIfKeyPressedRightNow(KeyCode.F, ref _keyFWasReleased))
	        _fireShouldBeOn = !_fireShouldBeOn;

	    if (CheckIfKeyPressedRightNow(KeyCode.S, ref _keySWasReleased))
	        _smokeShouldBeOn = !_smokeShouldBeOn;

        HandleParticleSystem(Fire, _fireShouldBeOn);
        HandleParticleSystem(Smoke, _smokeShouldBeOn);
	}

    private static bool CheckIfKeyPressedRightNow(KeyCode keyCode, ref bool keyWasReleased)
    {
        if (Input.GetKeyDown(keyCode) && keyWasReleased)
        {
            keyWasReleased = false;
            return true;
        }
        if (Input.GetKeyUp(keyCode) && !keyWasReleased)
            keyWasReleased = true;
        return false;
    }

    private static void HandleParticleSystem(ParticleSystem particles, bool shouldBeEnabled)
    {
        if (shouldBeEnabled)
        {
            if (!particles.isPlaying)
                particles.Play();
        }
        else
        {
            if(particles.isPlaying)
                particles.Stop();
        }
    }
}
