using Content.Server.UserInterface;
using Content.Shared.Instruments;
using Robust.Server.GameObjects;
using Robust.Server.Player;

namespace Content.Server.Instruments;

[RegisterComponent, ComponentReference(typeof(SharedInstrumentComponent))]
public sealed class InstrumentComponent : SharedInstrumentComponent
{
    [Dependency] private readonly IEntityManager _entMan = default!;

    [ViewVariables]
    public float Timer = 0f;

    [ViewVariables]
    public int BatchesDropped = 0;

    [ViewVariables]
    public int LaggedBatches = 0;

    [ViewVariables]
    public int MidiEventCount = 0;

    [ViewVariables]
    public uint LastSequencerTick = 0;

    // TODO Instruments: Make this ECS
    public IPlayerSession? InstrumentPlayer =>
        _entMan.GetComponentOrNull<ActivatableUIComponent>(Owner)?.CurrentSingleUser
        ?? _entMan.GetComponentOrNull<ActorComponent>(Owner)?.PlayerSession;

    [ViewVariables] public BoundUserInterface? UserInterface => Owner.GetUIOrNull(InstrumentUiKey.Key);

    // Parkstation-EndOfRoundStats-Start
    public TimeSpan? TimeStartedPlaying { get; set; }
    // Parkstation-EndOfRoundStats-End
}

[RegisterComponent]
public sealed class ActiveInstrumentComponent : Component {}
