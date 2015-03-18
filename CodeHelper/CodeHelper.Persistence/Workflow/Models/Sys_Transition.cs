using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CodeHelper.Persistence.Workflow.Models
{
    public class Sys_Transition 
    {
        public Sys_Transition()
        {
        }

        public Guid Id { get; set; }

        /// <summary>
        ///
        /// </summary>
        public String Condition
        { get; set; }

        /// <summary>
        ///
        /// </summary>
        public DateTime? CreateTime
        { get; set; }

        /// <summary>
        ///
        /// </summary>
        public Guid? FromNodeId
        { get; set; }

        /// <summary>
        ///
        /// </summary>
        public Guid? ToNodeId
        { get; set; }

        /// <summary>
        ///
        /// </summary>
        public DateTime? UpdateTime
        { get; set; }

        public void AssignFrom(Sys_Transition other)
        {
            this.Condition = other.Condition;
            this.CreateTime = other.CreateTime;
            this.FromNodeId = other.FromNodeId;
            this.ToNodeId = other.ToNodeId;
            this.UpdateTime = other.UpdateTime;
        }
    }
}