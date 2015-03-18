using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Parser.DataModel
{
    public class MappingInfo
    {
        private String fromModel;
        private String targetModel;
        private String fromField;
        private String targetField;
        private String relation;

        /**
         * @return the fromModel
         */
        public String getFromModel()
        {
            return fromModel;
        }

        /**
         * @param fromModel the fromModel to set
         */
        public void setFromModel(String fromModel)
        {
            this.fromModel = fromModel;
        }

        /**
         * @return the targetModel
         */
        public String getTargetModel()
        {
            return targetModel;
        }

        /**
         * @param targetModel the targetModel to set
         */
        public void setTargetModel(String targetModel)
        {
            this.targetModel = targetModel;
        }

        /**
         * @return the fromField
         */
        public String getFromField()
        {
            return fromField;
        }

        /**
         * @param fromField the fromField to set
         */
        public void setFromField(String fromField)
        {
            this.fromField = fromField;
        }

        /**
         * @return the targetField
         */
        public String getTargetField()
        {
            return targetField;
        }

        /**
         * @param targetField the targetField to set
         */
        public void setTargetField(String targetField)
        {
            this.targetField = targetField;
        }

        /**
         * @return the relation
         */
        public String getRelation()
        {
            return relation;
        }

        /**
         * @param relation the relation to set
         */
        public void setRelation(String relation)
        {
            this.relation = relation;
        }
    }
}
