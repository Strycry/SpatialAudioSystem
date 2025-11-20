using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.InputSystem;   // ← necesario para VR buttons

public class AudioModeController : MonoBehaviour
{
    [Header("Assign radios (AudioSource) and rooms (AudioReverbZone)")]
    public List<AudioSource> radios = new List<AudioSource>();
    public List<AudioReverbZone> reverbZones = new List<AudioReverbZone>();
    public TextMeshProUGUI modeText;

    [Header("VR Input")]
    public InputActionReference toggleAction;   // ← AHORA ES UN REFERENCE

    [Header("Settings")]
    public float transitionTime = 0.5f;
    [Range(0, 1)] public float planarBlend = 0.3f;
    [Range(0, 1)] public float spatialBlend = 1f;

    bool isSpatial = false;
    Coroutine transitionCoroutine;


    void OnEnable()
    {
        if (toggleAction != null)
            toggleAction.action.Enable();   // ← NUEVO
    }

    void OnDisable()
    {
        if (toggleAction != null)
            toggleAction.action.Disable();  // ← NUEVO
    }


    void Start()
    {
        foreach (var radio in radios)
        {
            if (radio == null) continue;
            radio.volume = 1f;
            radio.spatialBlend = planarBlend;
            if (!radio.isPlaying)
                radio.Play();
        }

        ApplyMode(isSpatial, true);
        UpdateModeText();
    }


    void Update()
    {
        // Ahora se usa toggleAction.action en vez de toggleAction
        if (toggleAction != null && toggleAction.action.WasPressedThisFrame())
        {
            isSpatial = !isSpatial;

            if (transitionCoroutine != null)
                StopCoroutine(transitionCoroutine);

            transitionCoroutine = StartCoroutine(TransitionMode(isSpatial, transitionTime));
            UpdateModeText();
        }
    }


    void UpdateModeText()
    {
        if (modeText != null)
        {
            modeText.text = isSpatial ?
                "Modo B: Sonido Espacializado con Reverb Ambiental" :
                "Modo A: Sonido Estéreo Plano";
        }
    }


    IEnumerator TransitionMode(bool toSpatial, float time)
    {
        float elapsed = 0f;
        float startBlend = radios.Count > 0 ? radios[0].spatialBlend : planarBlend;
        float targetBlend = toSpatial ? spatialBlend : planarBlend;

        List<float> startReverb = new List<float>();
        List<float> targetReverb = new List<float>();

        for (int i = 0; i < reverbZones.Count; i++)
        {
            startReverb.Add(reverbZones[i].enabled ? 1f : 0f);
            targetReverb.Add(toSpatial ? 1f : 0f);
        }

        while (elapsed < time)
        {
            float t = elapsed / time;
            float blend = Mathf.Lerp(startBlend, targetBlend, t);

            foreach (var a in radios)
                if (a != null) a.spatialBlend = blend;

            for (int i = 0; i < reverbZones.Count; i++)
                reverbZones[i].enabled = Mathf.Lerp(startReverb[i], targetReverb[i], t) > 0.5f;

            elapsed += Time.unscaledDeltaTime;
            yield return null;
        }

        ApplyMode(toSpatial, true);
    }


    void ApplyMode(bool toSpatial, bool instant = false)
    {
        float targetBlend = toSpatial ? spatialBlend : planarBlend;

        foreach (var a in radios)
        {
            if (a == null) continue;
            a.spatialBlend = targetBlend;
            if (!a.isPlaying)
                a.Play();
        }

        foreach (var z in reverbZones)
        {
            if (z == null) continue;
            z.enabled = toSpatial;
        }
    }
}
