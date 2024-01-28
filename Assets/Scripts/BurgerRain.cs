using System.Collections;
using UnityEngine;

public class BurgerRain : MonoBehaviour
{
    [SerializeField] Rect bounds;
    [SerializeField] float spawnDelayMin;
    [SerializeField] float spawnDelayMax;
    [SerializeField] Burger prefab;

    private void OnEnable()
    {
        StartCoroutine(KeepSpawning());
    }

    private IEnumerator KeepSpawning()
    {
        for (; ; )
        {
            yield return new WaitForSeconds(UnityEngine.Random.Range(spawnDelayMin, spawnDelayMax));

            var par = transform;
            while(par.parent)
            {
                par = par.parent;
            }
            var instance = Instantiate(prefab,par);
            instance.transform.position = (Vector2)transform.position + new Vector2(UnityEngine.Random.Range(bounds.xMin, bounds.xMax), UnityEngine.Random.Range(bounds.yMin, bounds.yMax));

        }
    }

    public void MakeItRain()
    {
        spawnDelayMin = 0.5f;
        spawnDelayMax = 1.2f;
    }
}
