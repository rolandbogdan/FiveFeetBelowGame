// <copyright file="IStorageRepository.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>
[assembly: System.CLSCompliant(false)]

namespace Repository
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    /// <summary>
    /// The interface for the repository of the game.
    /// </summary>
    /// <typeparam name="T"> The type of the entity stored. </typeparam>
    public interface IStorageRepository<T>
        where T : class
    {
        /// <summary>
        /// Inserts an entity to the repository.
        /// </summary>
        /// <param name="toInsert"> The type of the inserted entity. </param>
        void Insert(T toInsert);

        /// <summary>
        /// Returns the entity with the given id.
        /// </summary>
        /// <param name="id">The id of the wanted entity.</param>
        /// <returns>The entity with the given id.</returns>
        T GetOne(string id);

        /// <summary>
        /// Gets all entities in the repository.
        /// </summary>
        /// <returns>All entities of the repository.</returns>
        IQueryable<T> GetAll();

        /// <summary>
        /// Deletes an entity by reference.
        /// </summary>
        /// <param name="toDelete">The entity to be deleted.</param>
        void Delete(T toDelete);

        /// <summary>
        /// Saves all changes in the repository.
        /// </summary>
        void SaveChanges();
    }
}
