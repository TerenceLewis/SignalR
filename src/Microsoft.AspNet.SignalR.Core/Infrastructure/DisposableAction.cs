﻿using System;
using System.Threading;

namespace Microsoft.AspNet.SignalR
{
    internal class DisposableAction : IDisposable
    {
        private Action _action;

        public DisposableAction(Action action)
        {
            _action = action;
        }

        public void Dispose()
        {
            Interlocked.Exchange(ref _action, () => { }).Invoke();
        }
    }

}
