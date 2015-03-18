#region COPYRIGHT MOTOROLA SOLUTIONS
/*******************************************************************************
*                     COPYRIGHT 2014 MOTOROLA SOLUTIONS, INC
*                           ALL RIGHTS RESERVED.
*                     MOTOROLA SOLUTIONS CONFIDENTIAL PROPRIETARY
********************************************************************************
*
*   FILE NAME       : Sys_NodeData.cs
*
*--------------------------------- REVISIONS -----------------------------------
* CR/PR             Core ID   Date        Description
* ---------------   --------  ----------  --------------------------------------
* OA140422183258    amb4114   05/04/2014   Creation
*******************************************************************************/
#endregion

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CodeHelper.Persistence.Workflow.Models
{

    public class Sys_NodeState
    {
        public Sys_NodeState()
        {
        }

        public Guid Id { get; set; }

        /// <summary>
        ///
        /// </summary>
        public DateTime? CreateTime
        { get; set; }

        /// <summary>
        ///
        /// </summary>
        public Guid? NodeId
        { get; set; }

        /// <summary>
        ///
        /// </summary>
        public String Operator
        { get; set; }

        /// <summary>
        ///
        /// </summary>
        public Int32? State
        { get; set; }

        /// <summary>
        ///
        /// </summary>
        public DateTime? UpdateTime
        { get; set; }

        public void AssignFrom(Sys_NodeState other)
        {
            this.CreateTime = other.CreateTime;
            this.NodeId = other.NodeId;
            this.Operator = other.Operator;
            this.State = other.State;
            this.UpdateTime = other.UpdateTime;
        }
    }
}