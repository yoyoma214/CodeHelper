using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity.ModelConfiguration;
using CodeHelper.Persistence.Workflow.Models;

namespace CodeHelper.Persistence.Workflow.Mappings
{
    public class Sys_TransitionMap : EntityTypeConfiguration<Sys_Transition>
    {
        public Sys_TransitionMap()
        {
            // Primary Key
            HasKey(t => t.Id);

            ToTable("Sys_Transition");

            Property(t => t.Condition);
            Property(t => t.CreateTime);
            Property(t => t.FromNodeId);
            Property(t => t.Id).IsRequired();
            Property(t => t.ToNodeId);
            Property(t => t.UpdateTime);

            Property(t => t.Condition).HasColumnName("Condition");
            Property(t => t.CreateTime).HasColumnName("CreateTime");
            Property(t => t.FromNodeId).HasColumnName("FromNodeId");
            Property(t => t.Id).HasColumnName("Id");
            Property(t => t.ToNodeId).HasColumnName("ToNodeId");
            Property(t => t.UpdateTime).HasColumnName("UpdateTime");
        }
    }
}