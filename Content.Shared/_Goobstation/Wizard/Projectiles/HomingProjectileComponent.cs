// SPDX-FileCopyrightText: 2025 Aiden
// SPDX-FileCopyrightText: 2025 Aviu00
// SPDX-FileCopyrightText: 2025 Misandry
// SPDX-FileCopyrightText: 2025 ark1368
// SPDX-FileCopyrightText: 2025 gus
//
// SPDX-License-Identifier: AGPL-3.0-or-later

using Robust.Shared.GameStates;

namespace Content.Shared._Goobstation.Wizard.Projectiles;

[RegisterComponent, NetworkedComponent, AutoGenerateComponentState]
public sealed partial class HomingProjectileComponent : Component
{
    [ViewVariables(VVAccess.ReadOnly), AutoNetworkedField]
    public EntityUid? Target;

    [DataField, AutoNetworkedField]
    public float? HomingSpeed = 720f;

    [DataField]
    public Angle Tolerance = Angle.FromDegrees(1);

    /// <summary>
    /// The less this value is, the smoother homing will be, but also more laggy.
    /// Changing this also changes homing speed, so you need to tweak <see cref="HomingSpeed"/> datafield.
    /// </summary>
    [DataField]
    public float HomingTime = 0.1f;

    [ViewVariables(VVAccess.ReadOnly)]
    public float HomingAccumulator;
}