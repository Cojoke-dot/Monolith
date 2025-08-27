using Robust.Shared.Physics.Components;

namespace Content.Server._Mono.Grids;

public sealed class GridDebrisCleanupSystem : EntitySystem
{
    public override void Initialize()
    {
        SubscribeLocalEvent<PostGridSplitEvent>(OnGridSplitEvent);
    }

    private void OnGridSplitEvent(ref PostGridSplitEvent args)
    {
        if (TryComp<PhysicsComponent>(args.OldGrid, out var bodyOld) &&
            TryComp<PhysicsComponent>(args.Grid, out var bodyNew) &&
            bodyOld.Mass >= 3 * bodyNew.Mass )
            QueueDel(args.Grid);
    }
}
