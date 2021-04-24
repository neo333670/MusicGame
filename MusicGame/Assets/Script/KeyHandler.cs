using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyHandler : MonoBehaviour
{
    [SerializeField] GameObject upTrigger;
    [SerializeField] GameObject rightTrigger;
    [SerializeField] GameObject leftTrigger;
    [SerializeField] GameObject downTrigger;

    void KeyPressedUp(GameObject trigger, MusicButton type) {
        trigger.GetComponentInChildren<Light>().intensity /= 10;
    }

    void KeyPressedDown(GameObject trigger, MusicButton type) {
        trigger.GetComponentInChildren<Light>().intensity *= 10;
        EvaluateResult(type);
    }
    void EvaluateResult(MusicButton type) {
        GameObject[] m_list = GameObject.FindGameObjectsWithTag(type.ToString());

        if (m_list.Length != 0) {
            var closest = m_list[0].gameObject;
            float disantce = Mathf.Abs(closest.transform.position.z - GameManeger.Endz);

            if (disantce < 1) { GameManeger.UpdateScore(MusicResult.Perfect); }
            else if (disantce < 3) { GameManeger.UpdateScore(MusicResult.Good); }
            else if (disantce < 5) { GameManeger.UpdateScore(MusicResult.bad); }
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow)) { KeyPressedDown(upTrigger, MusicButton.Up); }
        if (Input.GetKeyDown(KeyCode.RightArrow)) { KeyPressedDown(rightTrigger, MusicButton.Right); }
        if (Input.GetKeyDown(KeyCode.LeftArrow)) { KeyPressedDown(leftTrigger, MusicButton.Left); }
        if (Input.GetKeyDown(KeyCode.DownArrow)) { KeyPressedDown(downTrigger, MusicButton.Down); }

        if (Input.GetKeyUp(KeyCode.UpArrow)) { KeyPressedUp(upTrigger, MusicButton.Up); }
        if (Input.GetKeyUp(KeyCode.RightArrow)) { KeyPressedUp(rightTrigger, MusicButton.Right); }
        if (Input.GetKeyUp(KeyCode.LeftArrow)) { KeyPressedUp(leftTrigger, MusicButton.Left); }
        if (Input.GetKeyUp(KeyCode.DownArrow)) { KeyPressedUp(downTrigger, MusicButton.Down); }
    }
}
