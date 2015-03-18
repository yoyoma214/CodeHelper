using System;
using System.Collections.Generic;
//using ICSharpCode.SharpDevelop.Dom;
using ICSharpCode.TextEditor.Document;
using CodeHelper.Core.Parse.ParseResults.DataModels;
using CodeHelper.Core.Parser;
using CodeHelper.Domain.Model.DataModels;

namespace CodeHelper.Editors
{
    public class DM_ParserFoldingStrategy : IFoldingStrategy
    {

        /// <remarks>
        /// Calculates the fold level of a specific line.
        /// </remarks>
        public List<FoldMarker> GenerateFoldMarkers(IDocument document, string fileName, object parseInfo)
        {
            var parseInformation = parseInfo as DmModelDB;
            if (parseInformation == null || parseInformation.Models == null || parseInformation.Models.Count == 0)
            {
                return null;
            }

            List<FoldMarker> foldMarkers = new List<FoldMarker>();

            foreach (var model in parseInformation.Models.Values)
            {
                
                var startLine = model.TokenPair.BeginToken.Line -1;
                var startColumn = model.TokenPair.BeginToken.CharPositionInLine;
                var endLine = model.TokenPair.EndToken.Line -1;
                var endColumn = model.TokenPair.EndToken.CharPositionInLine + 1;

                var fold = new FoldMarker(document, startLine, startColumn, endLine, endColumn, FoldType.Unspecified, "class " + model.Name);
                foldMarkers.Add(fold);
            }

           
            //if (parseInformation.BestCompilationUnit != parseInformation.MostRecentCompilationUnit)
            //{
            //    List<FoldMarker> oldFoldMarkers = GetFoldMarkers(document, parseInformation.BestCompilationUnit);
            //    int lastLine = (foldMarkers.Count == 0) ? 0 : foldMarkers[foldMarkers.Count - 1].EndLine;
            //    int totalNumberOfLines = document.TotalNumberOfLines;
            //    foreach (FoldMarker marker in oldFoldMarkers)
            //    {
            //        if (marker.StartLine > lastLine && marker.EndLine < totalNumberOfLines)
            //            foldMarkers.Add(marker);
            //    }
            //}
            return foldMarkers;
        }
    }
}
