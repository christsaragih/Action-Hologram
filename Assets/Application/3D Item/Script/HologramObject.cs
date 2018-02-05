using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum ObjectAnimation { Idle, EnginePlayBaling, EnginePecahBody, EngineSatukanBody,FurniturePutar,AyamGerak }
public interface HologramObject {
  
    void PlayAnimation();
    void StopAnimation();
    void ChangeColor(int ObjectNumber);
}
