using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity;
using CodeHelper.Persistence.Workflow.Models;
using CodeHelper.Persistence.Workflow.Mappings;
using System.Data.Entity.Validation;

namespace CodeHelper.Persistence.Workflow
{
    public class WorkflowContext : DbContext
    {
        static WorkflowContext() 
        {
            Database.SetInitializer<WorkflowContext>(null);
        }

        #region DbSet
        public DbSet<Sys_NodeState> Sys_NodeDatas
        {
            get
            {
                return this.Set<Sys_NodeState>();
            }
        }

        public DbSet<Sys_NodeDefine> Sys_NodeDefines
        {
            get
            {
                return this.Set<Sys_NodeDefine>();
            }
        }

        public DbSet<Sys_WorkflowState> Sys_WorkflowDatas
        {
            get
            {
                return this.Set<Sys_WorkflowState>();
            }
        }

        public DbSet<Sys_WorkflowDefine> Sys_WorkflowDefines
        {
            get
            {
                return this.Set<Sys_WorkflowDefine>();
            }
        }

        public DbSet<Sys_Transition> Sys_Transitions
        {
            get
            {
                return this.Set<Sys_Transition>();
            }
        }
        #endregion

        public WorkflowContext()
            : base()
        {
            string connectionString = System.Configuration.ConfigurationManager.AppSettings["WFConnectionString"];
            this.Database.Connection.ConnectionString = connectionString;            
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new Sys_NodeStateMap());
            modelBuilder.Configurations.Add(new Sys_NodeDefineMap());
            modelBuilder.Configurations.Add(new Sys_WorkflowStateMap());
            modelBuilder.Configurations.Add(new Sys_WorkflowDefineMap());
            modelBuilder.Configurations.Add(new Sys_TransitionMap());
        }

        public void Commit()
        {
            try
            {
                this.SaveChanges();
            }
            catch (DbEntityValidationException dbEx)
            {
                throw dbEx;
            }
        }

        public void RollbackChanges()
        {
            // set all entities in change tracker 
            // as 'unchanged state'
            ChangeTracker.Entries()
                              .ToList()
                              .ForEach(entry => entry.State = System.Data.EntityState.Unchanged);
        }
    }
}

