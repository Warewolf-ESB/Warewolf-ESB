﻿using System;
using System.Collections.Generic;

namespace Dev2.Workspaces
{
    /// <summary>
    /// Defines the requirments for an <see cref="IWorkspace"/> repository.
    /// </summary>
    public interface IWorkspaceRepository
    {
        /// <summary>
        /// Gets the number of items in the repository.
        /// </summary>
        int Count
        {
            get;
        }

        /// <summary>
        /// Overwrites this workspace with the server versions except for those provided.
        /// </summary>
        /// <param name="workspace">The workspace to be queried.</param>
        /// <param name="servicesToIgnore">The services being to be ignored.</param>
        void GetLatest(IWorkspace workspace, IList<string> servicesToIgnore);

        /// <summary>
        /// Gets the <see cref="IWorkspace"/> with the specified ID from storage if it does not exist in the repository.
        /// </summary>
        /// <param name="workspaceID">The workspace ID to be queried.</param>
        /// <param name="force"><code>true</code> if the workspace should be re-read even it is found; <code>false</code> otherwise.</param>
        /// <returns>The <see cref="IWorkspace"/> with the specified ID, or <code>null</code> if not found.</returns>
        IWorkspace Get(Guid workspaceID, bool force = false);

        /// <summary>
        /// Saves the specified workspace to storage.
        /// </summary>
        /// <param name="workspace">The workspace to be saved.</param>
        void Save(IWorkspace workspace);

        /// <summary>
        /// Deletes the specified workspace from storage.
        /// </summary>
        /// <param name="workspace">The workspace to be deleted.</param>
        void Delete(IWorkspace workspace);

        /// <summary>
        /// Refreshes all workspaces from storage.
        /// </summary>
        void RefreshWorkspaces();
    }
}
