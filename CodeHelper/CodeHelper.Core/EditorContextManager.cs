using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CodeHelper.Core.Infrastructure.Command;
using CodeHelper.Core.Services;

namespace CodeHelper.Core
{
    public class EditorContextManager : IReceiverHolder
    {
        private Dictionary<Guid, EditorContext> editorContexts = new Dictionary<Guid, EditorContext>();

        public EditorContext CurrentContext { get; set; }

        private EditorContextManager()
        {
            this.Receiver.OnCloseFile += new ReceiverBase.OpenCloseFileHandler(Receiver_OnCloseFile);
        }

        bool Receiver_OnCloseFile(Guid fileId)
        {
            if (this.editorContexts.ContainsKey(fileId))
            {
                this.editorContexts.Remove(fileId);
            }

            
            return false;
        }

        private static EditorContextManager instance = new EditorContextManager();

        public static EditorContextManager Instance()
        {
            return instance;
        }

        public void Add(EditorContext editorContext)
        {
            this.editorContexts.Add(editorContext.Model.FileId, editorContext);
        }

        public void Remove(Guid fileId)
        {
            this.editorContexts.Remove(fileId);
        }

        public EditorContext Get(Guid fileId)
        {
            if (this.editorContexts.ContainsKey(fileId))
                return editorContexts[fileId];

            return null;
        }

        public void SetCurrent(Guid fileId)
        {
            this.CurrentContext = Get(fileId);
        }

        public bool Contains(Guid fileId)
        {
            return editorContexts.ContainsKey(fileId);
        }

        ReceiverBase receiver = new ReceiverBase();

        public ReceiverBase Receiver
        {
            get
            {
                return receiver;
            }
        }
    }
}
