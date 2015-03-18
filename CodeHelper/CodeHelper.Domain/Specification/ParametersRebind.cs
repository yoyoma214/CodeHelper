#region COPYRIGHT MOTOROLA SOLUTIONS
/*******************************************************************************
*                     COPYRIGHT 2014 MOTOROLA SOLUTIONS, INC
*                           ALL RIGHTS RESERVED.
*                     MOTOROLA SOLUTIONS CONFIDENTIAL PROPRIETARY
********************************************************************************
*
*   FILE NAME       : ParametersRebind.cs
*
*--------------------------------- REVISIONS -----------------------------------
* CR/PR             Core ID   Date        Description
* ---------------   --------  ----------  --------------------------------------
* OA000000000000    OA-Team   2/21/2014   Creation
*******************************************************************************/
#endregion
using System.Collections.Generic;
using System.Linq.Expressions;

namespace CodeHelper.Domain.Specification
{
    /// <summary>
    /// Helper for rebinder parameters without use Invoke method in expressions 
    /// ( this methods is not supported in all linq query providers, 
    /// for example in Linq2Entities is not supported)
    /// </summary>
    public sealed class ParameterRebind : ExpressionVisitor
    {
        private readonly Dictionary<ParameterExpression, ParameterExpression> _map;

        /// <summary>
        /// Default construcotr
        /// </summary>
        /// <param name="map">Map specification</param>
        public ParameterRebind(Dictionary<ParameterExpression, ParameterExpression> map)
        {
            this._map = map ?? new Dictionary<ParameterExpression, ParameterExpression>();
        }

        /// <summary>
        /// Replate parameters in expression with a Map information
        /// </summary>
        /// <param name="map">Map information</param>
        /// <param name="exp">Expression to replace parameters</param>
        /// <returns>Expression with parameters replaced</returns>
        public static Expression ReplaceParameters(Dictionary<ParameterExpression, ParameterExpression> map, Expression exp)
        {
            return new ParameterRebind(map).Visit(exp);
        }

        /// <summary>
        /// Visit pattern method
        /// </summary>
        /// <param name="p">A Parameter expression</param>
        /// <returns>New visited expression</returns>
        protected override Expression VisitParameter(ParameterExpression p)
        {
            ParameterExpression replacement;
            if (_map.TryGetValue(p, out replacement))
            {
                p = replacement;
            }

            return base.VisitParameter(p);
        }
    }
}
