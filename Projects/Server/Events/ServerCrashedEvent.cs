/*************************************************************************
 * ModernUO                                                              *
 * Copyright 2019-2023 - ModernUO Development Team                       *
 * Email: hi@modernuo.com                                                *
 * File: ServerCrashedEvent.cs                                           *
 *                                                                       *
 * This program is free software: you can redistribute it and/or modify  *
 * it under the terms of the GNU General Public License as published by  *
 * the Free Software Foundation, either version 3 of the License, or     *
 * (at your option) any later version.                                   *
 *                                                                       *
 * You should have received a copy of the GNU General Public License     *
 * along with this program.  If not, see <http://www.gnu.org/licenses/>. *
 *************************************************************************/

using System;
using System.Runtime.CompilerServices;

namespace Server;

public class ServerCrashedEventArgs
{
    public ServerCrashedEventArgs(Exception e) => Exception = e;

    public Exception Exception { get; }

    public bool Close { get; set; }
}

public static partial class EventSink
{
    public static Action<Mobile> PlayerDeath { get; set; }

    public static event Action<ServerCrashedEventArgs> ServerCrashed;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void InvokeServerCrashed(ServerCrashedEventArgs e) => ServerCrashed?.Invoke(e);
}
