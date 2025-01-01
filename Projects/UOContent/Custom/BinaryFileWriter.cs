/*************************************************************************
 * ModernUO                                                              *
 * Copyright 2019-2024 - ModernUO Development Team                       *
 * Email: hi@modernuo.com                                                *
 * File: BinaryFileWriter.cs                                             *
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
using System.IO;
using System.Runtime.CompilerServices;

namespace Server;

public sealed class BinaryFileWriter : IDisposable, IGenericWriter
{
    private readonly bool _usePrefixes;
    private readonly FileStream _fs;
    private readonly MemoryMapFileWriter _writer;

    public BinaryFileWriter(string path, bool usePrefixes = false)
    {
        _usePrefixes = usePrefixes;
        _fs = new FileStream(path, FileMode.Create);
        _writer = new MemoryMapFileWriter(_fs, 1024 * 1024);
    }

    public void Dispose()
    {
        _writer?.Dispose();
        _fs?.Dispose();
    }

    public long Position => _writer.Position;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void Write(string value)
    {
        if (_usePrefixes)
        {
            _writer.Write(value);
        }
        else
        {
            _writer.WriteStringRaw(value);
        }
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void WriteStringRaw(ReadOnlySpan<char> value) => _writer.WriteStringRaw(value);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void Write(long value) => _writer.Write(value);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void Write(ulong value) => _writer.Write(value);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void Write(int value) => _writer.Write(value);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void Write(uint value) => _writer.Write(value);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void Write(short value) => _writer.Write(value);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void Write(ushort value) => _writer.Write(value);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void Write(double value) => _writer.Write(value);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void Write(float value) => _writer.Write(value);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void Write(byte value) => _writer.Write(value);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void Write(sbyte value) => _writer.Write(value);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void Write(bool value) => _writer.Write(value);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void Write(Serial serial) => _writer.Write(serial);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void Write(Type type) => _writer.Write(type);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void Write(decimal value) => _writer.Write(value);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void Write(byte[] bytes) => _writer.Write(bytes);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void Write(byte[] bytes, int offset, int count) => _writer.Write(bytes, offset, count);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void Write(ReadOnlySpan<byte> bytes) => _writer.Write(bytes);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public long Seek(long offset, SeekOrigin origin) => _writer.Seek(offset, origin);
}
