using System.Collections;
using UnityEngine;

public class Burger : MonoBehaviour
{
    [SerializeField] float speedBonusTime;
    [SerializeField] float speedBonusAmount;
    [SerializeField] AudioClip burgerTimeSong;

    static int _count = 0;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        var player = collision.gameObject.GetComponentInParent<PlayerController>();

        if(player)
        {
            var src = player.gameObject.AddComponent<AudioSource>();
            src.clip = burgerTimeSong;
            src.pitch = 1f + _count * 0.1f;
            _count++;
            src.Play();
            player.StartCoroutine(ApplySpeedBoost(player, src));
        }

        Destroy(gameObject);
    }

    IEnumerator ApplySpeedBoost(PlayerController player, AudioSource src)
    {
        player.AddSpeedBonus(speedBonusAmount);
        yield return new WaitForSeconds(speedBonusTime);
        player.AddSpeedBonus(-speedBonusAmount);
        Destroy(src, 2f);
    }

    public void Destroy()
    {
        Destroy(gameObject);
    }
}
