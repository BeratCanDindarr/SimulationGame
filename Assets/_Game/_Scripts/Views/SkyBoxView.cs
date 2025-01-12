using System;
using DG.Tweening;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.HighDefinition;

namespace SimulationGame.View
{
    public class SkyBoxView : BaseView
    {
        [SerializeField]private Volume volume;
        private HDRISky _hdriSky;

       public void Init()
       {
           if (volume.profile.TryGet(out _hdriSky))
           {
               Debug.Log("HDRI Sky finded!");
           }
           else
           {
               Debug.LogError("HDRI Sky Volume Profile not finded!");
           }
       }

       public void ChangeSkyBox(Cubemap cubemap)
        {
            if (cubemap == null) return;
            _hdriSky.hdriSky.value = cubemap;
            /* DOTween.To(() => _transition, x => _transition = x, 1, _transition).OnUpdate(() =>
             {
                 _transictionMaterial.SetFloat("_Transition", _transition);
             });*/
        }

    }
}
