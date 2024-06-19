// Copyright (c) Pomelo Foundation. All rights reserved.
// Licensed under the MIT. See LICENSE in the project root for license information.

using System.Text.Json;
#if NETSTANDARD2_1
using Microsoft.EntityFrameworkCore.NetStandard2._1;
#else
using System;
#endif
using Microsoft.EntityFrameworkCore.Storage.Json;

namespace Pomelo.EntityFrameworkCore.MySql.Storage.Internal.Json;

public sealed class MySqlJsonByteArrayAsHexStringReaderWriter : JsonValueReaderWriter<byte[]>
{
    public static MySqlJsonByteArrayAsHexStringReaderWriter Instance { get; } = new();

    private MySqlJsonByteArrayAsHexStringReaderWriter()
    {
    }

    public override byte[] FromJsonTyped(ref Utf8JsonReaderManager manager, object existingObject = null)
#if NETSTANDARD2_1
        => ConvertEx.FromHexString(manager.CurrentReader.GetString()!);
#else
        => Convert.FromHexString(manager.CurrentReader.GetString()!);
#endif

    public override void ToJsonTyped(Utf8JsonWriter writer, byte[] value)
#if NETSTANDARD2_1
        => writer.WriteStringValue(ConvertEx.ToHexString(value));
#else
        => writer.WriteStringValue(Convert.ToHexString(value));
#endif
}
