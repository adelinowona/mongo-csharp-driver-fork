﻿/* Copyright 2015-present MongoDB Inc.
*
* Licensed under the Apache License, Version 2.0 (the "License");
* you may not use this file except in compliance with the License.
* You may obtain a copy of the License at
*
* http://www.apache.org/licenses/LICENSE-2.0
*
* Unless required by applicable law or agreed to in writing, software
* distributed under the License is distributed on an "AS IS" BASIS,
* WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
* See the License for the specific language governing permissions and
* limitations under the License.
*/

using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using MongoDB.Driver.Core.Misc;
using MongoDB.Driver.Core.Servers;

namespace MongoDB.Driver.Core.Bindings
{
    /// <summary>
    /// Represents a handle to a read binding.
    /// </summary>
    public sealed class ReadBindingHandle : IReadBindingHandle
    {
        // fields
        private bool _disposed;
        private readonly ReferenceCounted<IReadBinding> _reference;

        // constructors
        /// <summary>
        /// Initializes a new instance of the <see cref="ReadBindingHandle"/> class.
        /// </summary>
        /// <param name="readBinding">The read binding.</param>
        public ReadBindingHandle(IReadBinding readBinding)
            : this(new ReferenceCounted<IReadBinding>(readBinding))
        {
        }

        private ReadBindingHandle(ReferenceCounted<IReadBinding> reference)
        {
            _reference = reference;
        }

        // properties
        /// <inheritdoc/>
        public ReadPreference ReadPreference
        {
            get { return _reference.Instance.ReadPreference; }
        }

        /// <inheritdoc/>
        public ICoreSessionHandle Session
        {
            get { return _reference.Instance.Session; }
        }

        /// <inheritdoc />
        public IChannelSourceHandle GetReadChannelSource(CancellationToken cancellationToken, IReadOnlyCollection<ServerDescription> deprioritizedServers = null)
        {
            ThrowIfDisposed();
            return _reference.Instance.GetReadChannelSource(cancellationToken, deprioritizedServers);
        }

        /// <inheritdoc />
        public Task<IChannelSourceHandle> GetReadChannelSourceAsync(CancellationToken cancellationToken, IReadOnlyCollection<ServerDescription> deprioritizedServers = null)
        {
            ThrowIfDisposed();
            return _reference.Instance.GetReadChannelSourceAsync(cancellationToken, deprioritizedServers);
        }

        /// <inheritdoc/>
        public void Dispose()
        {
            if (!_disposed)
            {
                _reference.DecrementReferenceCount();
                _disposed = true;
                GC.SuppressFinalize(this);
            }
        }

        /// <inheritdoc/>
        public IReadBindingHandle Fork()
        {
            ThrowIfDisposed();
            _reference.IncrementReferenceCount();
            return new ReadBindingHandle(_reference);
        }

        private void ThrowIfDisposed()
        {
            if (_disposed)
            {
                throw new ObjectDisposedException(GetType().Name);
            }
        }
    }
}
