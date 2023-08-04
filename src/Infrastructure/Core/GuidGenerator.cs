using MassTransit;
using System;

namespace Infrastructure.Core
{
    public static class GuidGenerator
    {
        public static Guid Generate => new(NewId.Next().ToString("D").ToUpperInvariant());
    }
}