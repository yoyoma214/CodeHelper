#region COPYRIGHT MOTOROLA SOLUTIONS
/*******************************************************************************
*                     COPYRIGHT 2014 MOTOROLA SOLUTIONS, INC
*                           ALL RIGHTS RESERVED.
*                     MOTOROLA SOLUTIONS CONFIDENTIAL PROPRIETARY
********************************************************************************
*
*   FILE NAME       : Sys_NodeDataMap.cs
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

    public class Sys_NodeStateMap : EntityTypeConfiguration<Sys_NodeState>
    {
        public Sys_NodeStateMap()
        {
            // Primary Key
            HasKey(t => t.Id);

            ToTable("Sys_NodeState");

            Property(t => t.CreateTime);
            Property(t => t.Id).IsRequired();
            Property(t => t.NodeId);
            Property(t => t.Operator).HasMaxLength(500);
            Property(t => t.State);
            Property(t => t.UpdateTime);

            Property(t => t.CreateTime).HasColumnName("CreateTime");
            Property(t => t.Id).HasColumnName("Id");
            Property(t => t.NodeId).HasColumnName("NodeId");
            Property(t => t.Operator).HasColumnName("Operator");
            Property(t => t.State).HasColumnName("State");
            Property(t => t.UpdateTime).HasColumnName("UpdateTime");
        }
    }
}