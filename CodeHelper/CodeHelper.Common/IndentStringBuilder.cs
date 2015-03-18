using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CodeHelper.Common
{
    public class IndentStringBuilder
    {
        private StringBuilder builder = new StringBuilder();
        private bool newLine = true;
        private int indentCount = 0;
        public int LineCount
        {
            get
            {
                return this.builder.ToString().Where(x => x == '\n').Count();
            }
        }

        public int Increase()
        {
            this.indentCount++;
            return this.indentCount;
        }
        public int Increase(string val)
        {
            OnNewLine(this.builder);
            this.builder.Append(val);
            this.indentCount++;            
            return this.indentCount;
        }
        public int Decrease()
        {
            this.indentCount--;
            return this.indentCount;
        }
        public int Decrease(string val)
        {
            this.indentCount--;
            OnNewLine(this.builder);
            this.builder.Append(val);            
            return this.indentCount;
        }

        public IndentStringBuilder()
        {
        }

        public IndentStringBuilder(int indent):this()
        {
            this.indentCount = indent;
        }        

        public void Append(string value)
        {
            OnNewLine(this.builder);
            builder.Append(value);
        }

        public void AppendLine()
        {
            this.builder.AppendLine();
            newLine = true;
        }

        public void AppendLine(string value)
        {
            OnNewLine(this.builder).AppendLine(value);
            newLine = true;
        }

        public void IncreaseIndentLine()
        {
            OnNewLine(this.builder).AppendLine();
            indentCount++;
            newLine = true;
        }

        public void IncreaseIndentLine(string value)
        {
            OnNewLine(this.builder).AppendLine(value);
            indentCount++;
            newLine = true;
        }

        public void IncreaseIndentFormatLine(string format, params object[] args)
        {            
            OnNewLine(this.builder).AppendFormat(format, args).AppendLine();
            indentCount++;
            newLine = true;
        }

        public void DecreaseIndentLine()
        {
            indentCount--;
            OnNewLine(this.builder).AppendLine();
            newLine = true;
        }

        public void DecreaseIndentLine(string value)
        {
            indentCount--;
            OnNewLine(this.builder).AppendLine(value);
            newLine = true;
        }

        public void AppendFormat(string format, params object[] args)
        {
            OnNewLine(this.builder).AppendFormat(format, args);
        }

        public void IncreaseIndentFormat(string format, params object[] args)
        {            
            OnNewLine(this.builder).AppendFormat(format, args);
            indentCount++;
        }

        public void DecreaseIndentFormat(string format, params object[] args)
        {
            indentCount--;
            OnNewLine(this.builder).AppendFormat(format, args);
        }

        public void DecreaseIndentFormatLine(string format, params object[] args)
        {
            indentCount--;
            OnNewLine(this.builder).AppendFormat(format, args).AppendLine();
            newLine = true;
        }

        public void AppendFormatLine(string format, params object[] args)
        {
            OnNewLine(this.builder).AppendFormat(format, args).AppendLine();
            newLine = true;
        }

        public override string ToString()
        {
            return this.builder.ToString();
        }

        private StringBuilder OnNewLine(StringBuilder builder)
        {
            if (this.newLine)
                builder.Append('\t', indentCount);

            this.newLine = false;
            return builder;
        }

        public int Length
        {
            get
            { return this.builder.Length; }
        }

        public void Clear()
        {
            this.builder.Clear();
        }
    }
}
