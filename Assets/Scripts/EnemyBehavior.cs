using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehavior : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject player;
    void Start()
    {
        var arrayPlayer = GameObject.FindGameObjectsWithTag("Player");
        if (arrayPlayer[0])
        {
            player = arrayPlayer[0];
        }


    }

    // Update is called once per frame
    void Update()
    {
        Debug.DrawLine(player.transform.position, transform.position, Color.red);
        /*transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(player.transform.position - transform.position), 10 * Time.deltaTime);

        if (Vector3.Distance(player.transform.position, transform.position) > 100)
        {
            //$$anonymous$$ove towards target
            transform.position += transform.forward * 10 * Time.deltaTime;



        } */

    }
}
