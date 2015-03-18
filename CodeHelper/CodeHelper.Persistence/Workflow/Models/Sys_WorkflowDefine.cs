#region COPYRIGHT MOTOROLA SOLUTIONS
/*******************************************************************************
*                     COPYRIGHT 2014 MOTOROLA SOLUTIONS, INC
*                           ALL RIGHTS RESERVED.
*                     MOTOROLA SOLUTIONS CONFIDENTIAL PROPRIETARY
********************************************************************************
*
*   FILE NAME       : Sys_WorkflowDefine.cs
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

    public class Sys_WorkflowDefine
    {
        public Sys_WorkflowDefine()
        {
        }

        public Guid Id { get; set; }
        /// <summary>
        ///
        /// </summary>
        public String AssembleName
        { get; set; }

        /// <summary>
        ///
        /// </summary>
        public DateTime? CreateTime
        { get; set; }

        /// <summary>
        ///
        /// </summary>
        public String Description
        { get; set; }

        /// <summary>
        ///
        /// </summary>
        public String Name
        { get; set; }

        /// <summary>
        ///
        /// </summary>
        public String Namespace
        { get; set; }

        /// <summary>
        ///
        /// </summary>
        public Int32? Status
        { get; set; }

        /// <summary>
        ///
        /// </summary>
        public DateTime? UpdateTime
        { get; set; }

        public void AssignFrom(Sys_WorkflowDefine other)
        {
            this.AssembleName = other.AssembleName;
            this.CreateTime = other.CreateTime;
            this.Description = other.Description;
            this.Name = other.Name;
            this.Namespace = other.Namespace;
            this.Status = other.Status;
            this.UpdateTime = other.UpdateTime;
        }
    }
}