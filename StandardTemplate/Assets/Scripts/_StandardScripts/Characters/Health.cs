using UnityEngine;

public class Health : MonoBehaviour
{
    public int maxValue;
    public int currentValue;

    public bool onDeathDestroy;
    public float destructionDelay;

    public bool onDeathAnimate;
    public string onDeathInvokeFuntion;

    public bool player;

    public bool useHealthBar;
    private HealthBar healthBar;

    public bool canTakeDamage = true;

    public string[] deathSFX;
    public string[] hitSFX;

    private void Start()
    {
        if (useHealthBar && healthBar == null)
        {
            healthBar = GetComponentInChildren<HealthBar>();
            healthBar.InitializeHPBar(maxValue);
        }
    }

    public void TakeDamage(int damage)
    {
        if (canTakeDamage)
        {
            if (AudioManager.instance != null && hitSFX.Length > 0)
            {
                int sfxToPlay = Random.Range(0, hitSFX.Length - 1);
                if (AudioManager.instance != null)
                {
                    AudioManager.instance.Play(hitSFX[sfxToPlay]);
                }
            }

            currentValue -= damage;

            if (useHealthBar)
            {
                healthBar.UpdateHealthBar(currentValue);
            }

            if (currentValue <= 0)
            {
                Death();
            }
        }
    }

    public void Death()
    {
        if (AudioManager.instance != null && deathSFX.Length > 0)
        {
            int sfxToPlay = Random.Range(0, deathSFX.Length - 1);
            if (AudioManager.instance != null)
            {
                AudioManager.instance.Play(deathSFX[sfxToPlay]);
            }
        }

        if (onDeathDestroy)
        {
            Destroy(gameObject, destructionDelay);
        }
        if (onDeathAnimate)
        {
            GetComponent<Animator>().SetTrigger("death");
        }
        if (onDeathInvokeFuntion != "")
        {
            Invoke(onDeathInvokeFuntion,0);
        }
        if (player)
        {
            //special player death jazz
        }
    }
}
