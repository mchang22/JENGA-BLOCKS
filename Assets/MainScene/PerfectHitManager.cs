using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PerfectHitManager : MonoBehaviour
{
    public static PerfectHitManager Instance;
    public GameObject NormalHitSquare;
    public GameObject PerfectHitSquare;

    void Awake()
    {
        if (Instance == null)
            Instance = this;
    }


    public void ShowNormalHitEffect(Vector3 pos, Vector3 scale)
    {
        GameObject effect = Instantiate(NormalHitSquare, pos, Quaternion.identity, this.transform.Find("Canvas"));
        effect.transform.position = pos;
        effect.transform.localRotation = Quaternion.identity;
        effect.GetComponent<RectTransform>().sizeDelta = new Vector2(71 * scale.x, 71 * scale.z);
    }

    public void ShowPerfectHitEffect(Vector3 pos, Vector3 scale)
    {
        GameObject effect = Instantiate(NormalHitSquare, pos, Quaternion.identity, this.transform.Find("Canvas"));
        effect.transform.position = pos;
        effect.transform.localRotation = Quaternion.identity;
        effect.GetComponent<RectTransform>().sizeDelta = new Vector2(71 * scale.x, 71 * scale.z);
    }

    public IEnumerator ShowPerfectCombo(int combo, Vector3 pos, Vector3 scale)
    {
        for (int i = 0; i < combo; i++)
        {
            ShowPerfectHitEffect(pos, scale);
            yield return new WaitForSeconds(0.1f);
        }
    }
}
