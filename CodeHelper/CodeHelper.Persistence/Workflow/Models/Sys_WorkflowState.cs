#region COPYRIGHT MOTOROLA SOLUTIONS
/*******************************************************************************
*                     COPYRIGHT 2014 MOTOROLA SOLUTIONS, INC
*                           ALL RIGHTS RESERVED.
*                     MOTOROLA SOLUTIONS CONFIDENTIAL PROPRIETARY
********************************************************************************
*
*   FILE NAME       : Sys_WorkflowData.cs
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

    public class Sys_WorkflowState
    {
        public Sys_WorkflowState()
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
        public String Creator
        { get; set; }

        /// <summary>
        ///
        /// </summary>
        public Guid? CurrentNodeId
        { get; set; }

        /// <summary>
        ///
        /// </summary>
        public Int32? Status
        { get; set; }

        /// <summary>
        ///
        /// </summary>
        public DateTime UpdateTime
        { get; set; }

        /// <summary>
        ///
        /// </summary>
        public Guid? WFId
        { get; set; }

        public void AssignFrom(Sys_WorkflowState other)
        {
            this.CreateTime = other.CreateTime;
            this.Creator = other.Creator;
            this.CurrentNodeId = other.CurrentNodeId;
            this.Status = other.Status;
            this.UpdateTime = other.UpdateTime;
            this.WFId = other.WFId;
        }
    }
}