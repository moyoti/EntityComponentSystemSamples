using Unity.Entities;
using Unity.Jobs;
using Unity.Mathematics;
using Unity.Transforms;

// This system updates all entities in the scene with both a RotationSpeed_ForEach and Rotation component.

// ReSharper disable once InconsistentNaming
public class RotationSpeedSystem_ForEach : SystemBase
{
    // OnUpdate runs on the main thread.
    protected override void OnUpdate()
    {
        float deltaTime = Time.DeltaTime;
        
        // Schedule job to rotate around up vector
        Entities
            .WithName("RotationSpeedSystem_ForEach")//好像没什么用
            .ForEach((ref Rotation rotation, in RotationSpeed_ForEach rotationSpeed) =>
            {
                rotation.Value = math.mul(
                    math.normalize(rotation.Value), 
                    quaternion.AxisAngle(math.up(), rotationSpeed.RadiansPerSecond * deltaTime));
            })//ForEach对Entity进行操作，lambda表达式中进行数据更新
            .ScheduleParallel();
    }
}
