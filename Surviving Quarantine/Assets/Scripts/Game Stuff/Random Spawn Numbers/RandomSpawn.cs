using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class RandomSpawn : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI xpTextBoredom;
    [SerializeField] private TextMeshProUGUI xpTextHygiene;
    [SerializeField] private TextMeshProUGUI xpTextBodyFat;

    [SerializeField] private GameObject[] spawn;
    private int randomChoice;

    private void Start()
    {
        randomChoice = Random.Range(0, spawn.Length);
        xpTextBoredom.transform.position = new Vector2(spawn[randomChoice].transform.position.x, spawn[randomChoice].transform.position.y);
        xpTextBodyFat.transform.position = new Vector2(spawn[randomChoice].transform.position.x, spawn[randomChoice].transform.position.y);
        xpTextHygiene.transform.position = new Vector2(spawn[randomChoice].transform.position.x, spawn[randomChoice].transform.position.y);
    }

    public void CreatingObject(int whichPrefab)
    {
        if (whichPrefab == 0)
        {
            Instantiate(xpTextBoredom, spawn[randomChoice].transform.position, Quaternion.identity, spawn[randomChoice].transform);
        }
        if (whichPrefab == 1)
        {
            Instantiate(xpTextBodyFat, spawn[randomChoice].transform.position, Quaternion.identity, spawn[randomChoice].transform);
        }
        if (whichPrefab == 2)
        {
            Instantiate(xpTextHygiene, spawn[randomChoice].transform.position, Quaternion.identity, spawn[randomChoice].transform);
        }
        randomChoice = Random.Range(0, spawn.Length);
        xpTextBoredom.transform.position = new Vector2(spawn[randomChoice].transform.position.x, spawn[randomChoice].transform.position.y);
        xpTextBodyFat.transform.position = new Vector2(spawn[randomChoice].transform.position.x, spawn[randomChoice].transform.position.y);
        xpTextHygiene.transform.position = new Vector2(spawn[randomChoice].transform.position.x, spawn[randomChoice].transform.position.y);
    }
}
