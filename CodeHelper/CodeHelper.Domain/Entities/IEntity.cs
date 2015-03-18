#region COPYRIGHT MOTOROLA SOLUTIONS
/*******************************************************************************
*                     COPYRIGHT 2014 MOTOROLA SOLUTIONS, INC
*                           ALL RIGHTS RESERVED.
*                     MOTOROLA SOLUTIONS CONFIDENTIAL PROPRIETARY
********************************************************************************
*
*   FILE NAME       : IEntity.cs
*
*--------------------------------- REVISIONS -----------------------------------
* CR/PR             Core ID   Date        Description
* ---------------   --------  ----------  --------------------------------------
* OA000000000000    OA-Team   2/21/2014   Creation
*******************************************************************************/
#endregion
using System;

namespace CodeHelper.Domain.Entities
{
    public interface IEntity : IEquatable<IEntity>
    {
        Guid Id { get; }
    }
}
