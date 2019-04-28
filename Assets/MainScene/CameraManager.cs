using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PostProcessing;

public class CameraManager : MonoBehaviour
{

    public static CameraManager Instance;

    public Vector3 desirePos;
    public PostProcessingProfile profile;

    void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        desirePos = transform.position;
        ResetFocusDistance();
    }

    public void GoUp()
    {
        desirePos += Vector3.up;
    }

    void Update()
    {
        transform.position = Vector3.Lerp(transform.position, desirePos, Time.deltaTime * 2);
    }

    void ResetFocusDistance()
    {
        DepthOfFieldModel.Settings a = profile.depthOfField.settings;
        a.focusDistance = 8f;
        profile.depthOfField.settings = a;
    }

    public IEnumerator Blur()
    {
        float duration = 1.5f;
        float timer = Time.time;

        DepthOfFieldModel.Settings a = profile.depthOfField.settings;

        float originalDis = profile.depthOfField.settings.focusDistance;
        float deltaDis = originalDis - 1f;

        while ((Time.time - timer) < duration)
        {
            a.focusDistance -= (deltaDis / duration) * Time.deltaTime;
            profile.depthOfField.settings = a;
            yield return null;
        }
    }

    public IEnumerator Focus()
    {
        float duration = 1.5f;
        float timer = Time.time;

        DepthOfFieldModel.Settings a = profile.depthOfField.settings;

        float originalDis = profile.depthOfField.settings.focusDistance;
        float deltaDis = 8f - originalDis;

        while ((Time.time - timer) < duration)
        {
            a.focusDistance += (deltaDis / duration) * Time.deltaTime;
            profile.depthOfField.settings = a;
            yield return null;
        }
    }
}
