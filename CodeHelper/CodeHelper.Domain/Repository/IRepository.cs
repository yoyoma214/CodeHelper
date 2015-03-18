#region COPYRIGHT MOTOROLA SOLUTIONS
/*******************************************************************************
*                     COPYRIGHT 2014 MOTOROLA SOLUTIONS, INC
*                           ALL RIGHTS RESERVED.
*                     MOTOROLA SOLUTIONS CONFIDENTIAL PROPRIETARY
********************************************************************************
*
*   FILE NAME       : IRepository.cs
*
*--------------------------------- REVISIONS -----------------------------------
* CR/PR             Core ID   Date        Description
* ---------------   --------  ----------  --------------------------------------
* OA000000000000    OA-Team   2/21/2014   Creation
* OA140307201654    amb3616   3/19/2014   Modify GetAll method return IQueryable
*******************************************************************************/
#endregion
using System;
using System.Collections.Generic;
using CodeHelper.Domain.AggregateRoot;
using CodeHelper.Domain.Specification;
using CodeHelper.Data;
using System.Linq;

namespace CodeHelper.Domain.Repository
{
    /// <summary>
    /// Base interface for implement a "Repository Pattern", for
    /// more information about this pattern see http://martinfowler.com/eaaCatalog/repository.html
    /// or http://blogs.msdn.com/adonet/archive/2009/06/16/using-repository-and-unit-of-work-patterns-with-entity-framework-4-0.aspx
    /// </summary>
    /// <typeparam name="TAggregateRoot">Type of aggregateRoot for this repository </typeparam>
    public interface IRepository<TAggregateRoot>
        where TAggregateRoot : class, IAggregateRoot
    {
        /// <summary>
        /// Get the unit of work in this repository
        /// </summary>
        /// <exception cref="ObjectDisposedException"></exception>
        /// <exception cref="RepositoryException"></exception>
        IUnitOfWork UnitOfWork { get; }

        /// <summary>
        /// Add item into repository
        /// </summary>
        /// <param name="item">Item to add to repository</param>
        /// <exception cref="ObjectDisposedException"></exception>
        /// <exception cref="RepositoryException"></exception>
        void Add(TAggregateRoot item);

        /// <summary>
        /// Delete item 
        /// </summary>
        /// <param name="item">Item to delete</param>
        /// <exception cref="ObjectDisposedException"></exception>
        /// <exception cref="RepositoryException"></exception>
        void Remove(TAggregateRoot item);

        /// <summary>
        /// Set item as modified
        /// </summary>
        /// <param name="item">Item to modify</param>
        /// <exception cref="ObjectDisposedException"></exception>
        /// <exception cref="RepositoryException"></exception>
        void Modify(TAggregateRoot item);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="specification"></param>
        /// <returns></returns>
        /// <exception cref="ObjectDisposedException"></exception>
        /// <exception cref="RepositoryException"></exception>
        bool Exists(ISpecification<TAggregateRoot> specification);

        /// <summary>
        /// Get element by entity key
        /// </summary>
        /// <param name="id">Entity key value</param>
        /// <returns></returns>
        /// <exception cref="ObjectDisposedException"></exception>
        /// <exception cref="RepositoryException"></exception>
        TAggregateRoot Get(Guid id);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="specification"></param>
        /// <returns></returns>
        /// <exception cref="ObjectDisposedException"></exception>
        /// <exception cref="RepositoryException"></exception>
        TAggregateRoot Get(ISpecification<TAggregateRoot> specification);

        /// <summary>
        /// Get all elements of type TEntity in repository
        /// </summary>
        /// <returns>List of selected elements</returns>
        /// <exception cref="ObjectDisposedException"></exception>
        /// <exception cref="RepositoryException"></exception>
        IQueryable<TAggregateRoot> GetAll();

        /// <summary>
        /// Get all elements of type TEntity that matching a
        /// Specification <paramref name="specification"/>
        /// </summary>
        /// <param name="specification">Specification that result meet</param>
        /// <returns></returns>
        /// <exception cref="ObjectDisposedException"></exception>
        /// <exception cref="RepositoryException"></exception>
        IQueryable<TAggregateRoot> GetAll(ISpecification<TAggregateRoot> specification);
    }
}
