using System.Collections;
using UnityEngine;

public class TreantHealer : Enemy
{
    [SerializeField] private GameObject healPrefab;
    private float healMultiplier = 0.4f;
    [SerializeField] private AudioClip healSFX;

    private void Heal()
    {
        if (CanAttack() && AttackRange >= CheckDistance()) StartCoroutine(HealCoroutine());
    }

    private IEnumerator HealCoroutine()
    {
        SetActionCooldown(AttackDelay);
        Animator.SetBool("Healing", true);
        yield return new WaitForSeconds(2f);
        Enemy[] enemies = (Enemy[])GameObject.FindObjectsOfType(typeof(Enemy));
        foreach (Enemy enemy in enemies)
        {
            GameObject obj = Instantiate(healPrefab, enemy.transform.position, Quaternion.identity);
            Heal heal = obj.GetComponent<Heal>();
            heal.Target = enemy.transform;
            heal.HealAmount = enemy.MaxHp * healMultiplier;
        }
        Animator.SetBool("Healing", false);
        HealSFX();
    }

    private void HealSFX()
    {
        GameManager.Instance.GetComponent<AudioSource>().clip = healSFX;
        GameManager.Instance.GetComponent<AudioSource>().Play();
    }

    // Update is called once per frame
    void Update()
    {
        EnemyUpdate();
        Heal();
    }
}
