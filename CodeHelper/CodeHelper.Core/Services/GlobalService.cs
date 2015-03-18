using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CodeHelper.Core;
using CodeHelper.Core.Error;
using CodeHelper.Core.Infrastructure.Model;
using System.Threading;
using System.Windows.Forms;
using CodeHelper.Core.Parse.ModuleRelations;
using CodeHelper.Core.Parse.ParseResults.DataViews;

namespace CodeHelper.Core.Services
{    
    public class GlobalService
    {
        public static event EventHandler Idle;
        public static string CurrentPrj_Name { get; set; }
        public static string CurrentPrj_Dir { get; set; }
        public static IResloveTableAgent ResloveTableAgent { get; set; }

        //public static EditorContext EditorContext { get; set; }
        public static IModelManager ModelManager { get; set; }
        private static readonly int MainThreadId;
        public static ImageList Icons { get; private set; }
        public static IDepencyManager DepencyManager { get; set; }
        public static string UserId { get; set; }

        public static EditorContextManager EditorContextManager { get; private set; }

        public static bool InvokeRequired
        {
            get
            {
                return Thread.CurrentThread.ManagedThreadId != MainThreadId;
            }
        }

        static GlobalService()
        {
            MainThreadId = Thread.CurrentThread.ManagedThreadId;            
            Icons = new ImageList();

            EditorContextManager = CodeHelper.Core.EditorContextManager.Instance();            
        }

        public static void Save()
        {
            //throw new NotImplementedException();
        }
        public static void GoIdle(object sender, EventArgs e)
        {
            if (Idle != null)
            {
                Idle(sender, e);
            }
        }
        //public static void PushParseError(string file, List<ParseErrorInfo> errors)
        //{
        //    if (ParseError != null)
        //    {
        //        ParseError(file, errors);
        //    }
        //}
    }
}
