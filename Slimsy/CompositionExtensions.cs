﻿using System;
using Umbraco.Core.Composing;

namespace Slimsy
{
    public static class CompositionExtensions
    {
        public static void SetSlimsyOptions(this Composition composition, Func<IFactory, ISlimsyOptions> factory)
        {
            composition.RegisterUnique(factory);
        }
    }
}
