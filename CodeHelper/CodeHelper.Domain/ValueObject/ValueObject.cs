#region COPYRIGHT MOTOROLA SOLUTIONS
/*******************************************************************************
*                     COPYRIGHT 2014 MOTOROLA SOLUTIONS, INC
*                           ALL RIGHTS RESERVED.
*                     MOTOROLA SOLUTIONS CONFIDENTIAL PROPRIETARY
********************************************************************************
*
*   FILE NAME       : ValueObject.cs
*
*--------------------------------- REVISIONS -----------------------------------
* CR/PR             Core ID   Date        Description
* ---------------   --------  ----------  --------------------------------------
* OA000000000000    OA-Team   2/21/2014   Creation
*******************************************************************************/
#endregion
using System;

namespace CodeHelper.Domain.ValueObject
{
    /// <summary>
    /// Base class for value objects in domain.
    /// </summary>
    /// <typeparam name="TValueObject">The type of this value object</typeparam>
    public abstract class ValueObject<TValueObject> : IEquatable<TValueObject>
        where TValueObject : ValueObject<TValueObject>
    {
        #region Override

        public override bool Equals(object other)
        {
            if (ReferenceEquals(other, null))
            {
                return false;
            }

            if (ReferenceEquals(this, other))
            {
                return true;
            }

            if (this.GetType() != other.GetType())
            {
                return false;
            }

            return this.Equals((TValueObject)other);
        }

        public abstract override int GetHashCode();

        public static bool operator ==(
            ValueObject<TValueObject> left,
            ValueObject<TValueObject> right)
        {
            if (Equals(left, null))
            {
                return (Equals(right, null));
            }

            return left.Equals(right);
        }

        public static bool operator !=(
            ValueObject<TValueObject> left,
            ValueObject<TValueObject> right)
        {
            return !(left == right);
        }

        #endregion

        #region IEquatable Members

        public abstract bool Equals(TValueObject other);

        #endregion
    }
}
