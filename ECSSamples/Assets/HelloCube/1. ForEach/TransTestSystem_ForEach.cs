using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Entities;
using Unity.Transforms;
using Unity.Jobs;

public class TransTestSystem_ForEach : SystemBase
{
    protected override void OnUpdate()
    {
        float deltaTime = Time.DeltaTime;
        Entities
            .ForEach((ref Translation translation, in TransTest_ForEach transform) =>
            {
                translation.Value.y += transform.moveSpeed;
            })
            .ScheduleParallel();
    }
}
