#region COPYRIGHT MOTOROLA SOLUTIONS
/*******************************************************************************
*                     COPYRIGHT 2014 MOTOROLA SOLUTIONS, INC
*                           ALL RIGHTS RESERVED.
*                     MOTOROLA SOLUTIONS CONFIDENTIAL PROPRIETARY
********************************************************************************
*
*   FILE NAME       : Sys_WorkflowDataMap.cs
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
using System.Data.Entity.ModelConfiguration;
using CodeHelper.Persistence.Workflow.Models;

namespace CodeHelper.Persistence.Workflow.Mappings
{

    public class Sys_WorkflowStateMap : EntityTypeConfiguration<Sys_WorkflowState>
    {
        public Sys_WorkflowStateMap()
        {

            // Primary Key
            HasKey(t => t.Id);

            ToTable("Sys_WorkflowState");

            Property(t => t.CreateTime);
            Property(t => t.Creator).HasMaxLength(500);
            Property(t => t.CurrentNodeId);
            Property(t => t.Id).IsRequired();
            Property(t => t.Status);
            Property(t => t.UpdateTime).IsRequired();
            Property(t => t.WFId);

            Property(t => t.CreateTime).HasColumnName("CreateTime");
            Property(t => t.Creator).HasColumnName("Creator");
            Property(t => t.CurrentNodeId).HasColumnName("CurrentNodeId");
            Property(t => t.Id).HasColumnName("Id");
            Property(t => t.Status).HasColumnName("Status");
            Property(t => t.UpdateTime).HasColumnName("UpdateTime");
            Property(t => t.WFId).HasColumnName("WFId");
        }
    }
}