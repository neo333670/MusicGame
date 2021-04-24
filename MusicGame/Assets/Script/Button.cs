using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour
{
    public float moveSpeed;

    // Start is called before the first frame update
    void Start()
    {
        moveSpeed = 50f;
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.position -= Vector3.forward * moveSpeed * Time.deltaTime;

        if (this.transform.position.z - (GameManeger.Endz - GameManeger.End_Dis) < 0.005) {
            GameManeger.UpdateScore(MusicResult.Miss);
            Destroy(this.gameObject);
        }
    }


}
