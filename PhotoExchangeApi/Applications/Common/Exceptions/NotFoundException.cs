﻿
namespace PhotoExchangeApi.Applications.Common.Exceptions
{
    internal class NotFoundException : Exception
    {
        public NotFoundException(string name, object key) : base($"Entity {name} {key} not found"){}
    }
}
