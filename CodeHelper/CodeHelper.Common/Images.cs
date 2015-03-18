using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Reflection;
using System.Windows.Media.Imaging;
using System.Windows.Media;
using System.Windows;

namespace CodeHelper.Common
{
    public class Icons
    {
        public const string PropertiesFileName =
            "PropertiesHS.png";

        #region Fields

        const string nameSpace = "CodeHelper.Common";

        static System.Windows.Controls.Image alignObjectsBottom =
            GetIcon("AlignObjectsBottomHS.png");

        static System.Windows.Controls.Image alignObjectsCenteredHorizontal =
            GetIcon("AlignObjectsCenteredHorizontalHS.png");

        static System.Windows.Controls.Image alignObjectsCenteredVertical =
            GetIcon("AlignObjectsCenteredVerticalHS.png");

        static System.Windows.Controls.Image alignObjectsLeft = GetIcon("AlignObjectsLeftHS.png");

        static System.Windows.Controls.Image alignObjectsRight = GetIcon("AlignObjectsRightHS.png");

        static System.Windows.Controls.Image alignObjectsTop = GetIcon("AlignObjectsTopHS.png");

        static System.Windows.Controls.Image arrow = GetIcon("StandardArrow.png");

        static System.Windows.Controls.Image bold = GetIcon("Bold.png");

        static System.Windows.Controls.Image bringForward = GetIcon("BringForwardHS.png");

        static System.Windows.Controls.Image bringToFront = GetIcon("BringToFrontHS.png");

        static System.Windows.Controls.Image bucketFill = GetIcon("BucketFill.png");

        static System.Windows.Controls.Image centerAlignment = GetIcon(
            "CenterAlignment.png");

        static System.Windows.Controls.Image classShape = GetIcon("ClassShape.png");

        static System.Windows.Controls.Image mClassShape2 = GetIcon("ClassShape2.png");

        static System.Windows.Controls.Image closedFolder = GetIcon("ClosedFolder.png");

        static System.Windows.Controls.Image connection = GetIcon("Connection.png");

        static System.Windows.Controls.Image copy = GetIcon("Copy.png");

        static System.Windows.Controls.Image cut = GetIcon("Cut.png");

        static System.Windows.Controls.Image dashStyles = GetIcon("DashStyles.png");

        static System.Windows.Controls.Image delete = GetIcon("Delete.png");

        static System.Windows.Controls.Image drawEllipse = GetIcon("DrawEllipse.png");

        static System.Windows.Controls.Image drawing = GetIcon("Drawing.png");

        static System.Windows.Controls.Image drawRectangle = GetIcon("DrawRectangle.png");

        static System.Windows.Controls.Image font = GetIcon("FontDialogHS.png");

        static System.Windows.Controls.Image group = GetIcon("Group.png");

        static System.Windows.Controls.Image hand = GetIcon("hand.png");

        static System.Windows.Controls.Image italic = GetIcon("Italic.png");

        static System.Windows.Controls.Image layoutShapes = GetIcon("LayoutShapes.png");

        static System.Windows.Controls.Image leftAlignment = GetIcon(
            "LeftAlignment.png");

        static System.Windows.Controls.Image lineCaps = GetIcon("LineCaps.png");

        static System.Windows.Controls.Image lineWeights = GetIcon("LineWeights.png");

        static System.Windows.Controls.Image moveConnector = GetIcon("ConnectorMover.png");

        static System.Windows.Controls.Image multiLines = GetIcon("StraightLines.png");

        static System.Windows.Controls.Image navigateForward = GetIcon("NavForward.png");

        static System.Windows.Controls.Image navigateBack = GetIcon("NavBack.png");

        static System.Windows.Controls.Image newDocumnet = GetIcon("NewDocumentHS.png");

        static System.Windows.Controls.Image openFolder = GetIcon("OpenFolder.png");

        static System.Windows.Controls.Image openedFolder = GetIcon("OpenedFolder.png");

        static System.Windows.Controls.Image outline = GetIcon(
            "PenDraw.png");

        static System.Windows.Controls.Image page = GetIcon("Page.png");

        static System.Windows.Controls.Image paste = GetIcon("Paste.png");

        static System.Windows.Controls.Image picture = GetIcon("InsertPicture.png");

        static System.Windows.Controls.Image polygon = GetIcon("Polygon.png");

        static System.Windows.Controls.Image print = GetIcon("Print.png");

        static System.Windows.Controls.Image printPreview = GetIcon("PrintPreview.png");

        static System.Windows.Controls.Image printSetup = GetIcon("PrintSetup.png");

        static System.Windows.Controls.Image properties = GetIcon("PropertiesHS.png");

        static System.Windows.Controls.Image redo = GetIcon("Edit_RedoHS.png");

        static System.Windows.Controls.Image rightAlignment = GetIcon(
            "RightAlignment.png");

        static System.Windows.Controls.Image save = GetIcon("Save.png");

        static System.Windows.Controls.Image schema = GetIconFromIcon("Schema.png");

        static System.Windows.Controls.Image scribble = GetIcon("Scribble.png");

        static System.Windows.Controls.Image sendBackwards = GetIcon("SendBackwardHS.png");

        static System.Windows.Controls.Image sendToBack = GetIcon("SendToBackHS.png");

        static System.Windows.Controls.Image showConnectors = GetIcon(
            "ShowConnectors.png");

        static System.Windows.Controls.Image mshowGrid = GetIcon(
            "ShowGridlines2HS.png");

        static System.Windows.Controls.Image textBox = GetIcon("Textbox.png");

        static System.Windows.Controls.Image undo = GetIcon("Edit_UndoHS.png");

        static System.Windows.Controls.Image ungroup = GetIcon("Ungroup.png");

        static System.Windows.Controls.Image viewZoomIn = GetIcon("ViewZoomIn.png");

        static System.Windows.Controls.Image viewZoomOut = GetIcon("ViewZoomOut.png");

        static System.Windows.Controls.Image zoomIn = GetIcon("ZoomIn.png");

        static System.Windows.Controls.Image zoomOut = GetIcon("ZoomOut.png");

        static System.Windows.Controls.Image zoomMarquee = GetIcon("ZoomMarquee.png");

        static System.Windows.Controls.Image generate = GetIcon("Generate.png");
        static System.Windows.Controls.Image build = GetIcon("Build.png");
        static System.Windows.Controls.Image rebuild = GetIcon("Rebuild.png");
        static System.Windows.Controls.Image run = GetIcon("Run.png");
        static System.Windows.Controls.Image step = GetIcon("Step.png");
        static System.Windows.Controls.Image updateModel = GetIcon("UpdateModel.png");
        static System.Windows.Controls.Image _Model = GetIcon("Model.png");
        static System.Windows.Controls.Image _Package = GetIcon("Package.png");
        static System.Windows.Controls.Image _Code = GetIcon("code.png");
        static System.Windows.Controls.Image workflow = GetIcon("workflow.png");
        static System.Windows.Controls.Image setting = GetIcon("Setting.png");
        public static System.Windows.Controls.Image Setting
        {
            get { return Icons.setting; }
            //set { Icons.activeObjectRef = value; }
        }

        public static System.Windows.Controls.Image Workflow
        {
            get { return Icons.workflow; }
            //set { Icons.activeObjectRef = value; }
        }

        public static System.Windows.Controls.Image Code
        {
            get { return Icons._Code; }
            //set { Icons.activeObjectRef = value; }
        }

        public static System.Windows.Controls.Image Package
        {
            get { return Icons._Package; }
            //set { Icons.activeObjectRef = value; }
        }
        public static System.Windows.Controls.Image Model
        {
            get { return Icons._Model; }
            //set { Icons.activeObjectRef = value; }
        }
        public static System.Windows.Controls.Image UpdateModel
        {
            get { return Icons.updateModel; }
            //set { Icons.activeObjectRef = value; }
        }
        public static System.Windows.Controls.Image Run
        {
            get { return Icons.run; }
            //set { Icons.activeObjectRef = value; }
        }
        public static System.Windows.Controls.Image Step
        {
            get { return Icons.step; }
            //set { Icons.activeObjectRef = value; }
        }
        public static System.Windows.Controls.Image Generate
        {
            get { return Icons.generate; }
            //set { Icons.activeObjectRef = value; }
        }
        public static System.Windows.Controls.Image Build
        {
            get { return Icons.build; }
            //set { Icons.activeObjectRef = value; }
        }
        public static System.Windows.Controls.Image Rebuild
        {
            get { return Icons.rebuild; }
            //set { Icons.activeObjectRef = value; }
        }




        static System.Windows.Controls.Image branch = GetIcon("Branch.png");

        public static System.Windows.Controls.Image Branch
        {
            get { return Icons.branch; }
            //set { Icons.branch = value; }
        }

        static System.Windows.Controls.Image chartTimer = GetIcon("ChartTimer.png");

        public static System.Windows.Controls.Image ChartTimer
        {
            get { return Icons.chartTimer; }
            //set { Icons.chartTimer = value; }
        }

        static System.Windows.Controls.Image connector = GetIcon("Connector.png");
        public static System.Windows.Controls.Image CurveConnection
        {
            get { return Icons.connector; }
            //set { Icons.chartTimer = value; }
        }

        static System.Windows.Controls.Image finalState = GetIcon("FinalState.png");

        public static System.Windows.Controls.Image FinalState
        {
            get { return Icons.finalState; }
            //set { Icons.finalState = value; }
        }


        static System.Windows.Controls.Image historyState = GetIcon("HistoryState.png");

        public static System.Windows.Controls.Image HistoryState
        {
            get { return Icons.historyState; }
            //set { Icons.historyState = value; }
        }

        static System.Windows.Controls.Image initialPointer = GetIcon("InitialPointer.png");

        public static System.Windows.Controls.Image InitialPointer
        {
            get { return Icons.initialPointer; }
            //set { Icons.initialPointer = value; }
        }

        static System.Windows.Controls.Image port = GetIcon("Port.png");

        public static System.Windows.Controls.Image Port
        {
            get { return Icons.port; }
            //set { Icons.port = value; }
        }

        static System.Windows.Controls.Image state = GetIcon("State.png");

        public static System.Windows.Controls.Image State
        {
            get { return Icons.state; }
            //set { Icons.state = value; }
        }

        static System.Windows.Controls.Image stateChart =  GetIcon("State.png");//GetIcon("StateChart.png");

        public static System.Windows.Controls.Image StateChart
        {
            get { return Icons.stateChart; }
            //set { Icons.stateChart = value; }
        }

        static System.Windows.Controls.Image transtion = GetIcon("Transtion.png");

        public static System.Windows.Controls.Image Transtion
        {
            get { return Icons.transtion; }
            //set { Icons.transtion = value; }
        }
        static System.Windows.Controls.Image variable = GetIcon("Variable.png");

        public static System.Windows.Controls.Image Variable
        {
            get { return Icons.variable; }
            //set { Icons.variable = value; }
        }

        static System.Windows.Controls.Image _BranchShape = GetIcon("Branch.png");

        public static System.Windows.Controls.Image BranchShape
        {
            get { return Icons._BranchShape; }
            //set { Icons._BranchShape = value; }
        }
        static System.Windows.Controls.Image _FinalStateShape = GetIcon("FinalState.png");

        public static System.Windows.Controls.Image FinalStateShape
        {
            get { return Icons._FinalStateShape; }
            //set { Icons._FinalStateShape = value; }
        }
        static System.Windows.Controls.Image _HistoryStateShape = GetIcon("HistoryState.png");

        public static System.Windows.Controls.Image HistoryStateShape
        {
            get { return Icons._HistoryStateShape; }
            //set { Icons._HistoryStateShape = value; }
        }
        static System.Windows.Controls.Image _InitialPointerShape = GetIcon("InitialPointer.png");

        public static System.Windows.Controls.Image InitialPointerShape
        {
            get { return Icons._InitialPointerShape; }
            //set { Icons._InitialPointerShape = value; }
        }
        static System.Windows.Controls.Image _StateShape = GetIcon("State.png");

        public static System.Windows.Controls.Image StateShape
        {
            get { return Icons._StateShape; }
            //set { Icons._StateShape = value; }
        }
        static System.Windows.Controls.Image _TransitionShape = GetIcon("Transtion.png");

        public static System.Windows.Controls.Image TransitionShape
        {
            get { return Icons._TransitionShape; }
            //set { Icons._TransitionShape = value; }
        }
        static System.Windows.Controls.Image _Error = GetIcon("Error.png");

        public static System.Windows.Controls.Image Error
        {
            get { return Icons._Error; }
            //set { Icons._TransitionShape = value; }
        }
        static System.Windows.Controls.Image _Warn = GetIcon("Warn.png");

        public static System.Windows.Controls.Image Warn
        {
            get { return Icons._Warn; }
            //set { Icons._TransitionShape = value; }
        }
        static System.Windows.Controls.Image _Info = GetIcon("Info.png");

        public static System.Windows.Controls.Image Info
        {
            get { return Icons._Info; }
            //set { Icons._TransitionShape = value; }
        }

        static System.Windows.Controls.Image _CSharpFile = GetIcon("CSharpFile.png");

        public static System.Windows.Controls.Image CSharpFile
        {
            get { return Icons._CSharpFile; }
            //set { Icons._TransitionShape = value; }
        }
        static System.Windows.Controls.Image _DirectoryClosed = GetIcon("DirectoryClosed.png");

        public static System.Windows.Controls.Image DirectoryClosed
        {
            get { return Icons._DirectoryClosed; }
            //set { Icons._TransitionShape = value; }
        }
        static System.Windows.Controls.Image _DirectoryOpened = GetIcon("DirectoryOpened.png");

        public static System.Windows.Controls.Image DirectoryOpened
        {
            get { return Icons._DirectoryOpened; }
            //set { Icons._TransitionShape = value; }
        }
        #endregion

        #region Properties

        // ------------------------------------------------------------------
        /// <summary>
        /// Gets the System.Windows.Controls.Image that represents aligning the bottom edges of
        /// objects.
        /// </summary>
        // ------------------------------------------------------------------
        public static System.Windows.Controls.Image AlignObjectsBottom
        {
            get
            {
                return alignObjectsBottom;
            }
        }

        // ------------------------------------------------------------------
        /// <summary>
        /// Gets the System.Windows.Controls.Image that represents horizontally aligning the center
        /// of objects.
        /// </summary>
        // ------------------------------------------------------------------
        public static System.Windows.Controls.Image AlignObjectsCenteredHorizontal
        {
            get
            {
                return alignObjectsCenteredHorizontal;
            }
        }

        // ------------------------------------------------------------------
        /// <summary>
        /// Gets the System.Windows.Controls.Image that represents vertically aligning the center
        /// of objects.
        /// </summary>
        // ------------------------------------------------------------------
        public static System.Windows.Controls.Image AlignObjectsCenteredVertical
        {
            get
            {
                return alignObjectsCenteredVertical;
            }
        }

        // ------------------------------------------------------------------
        /// <summary>
        /// Gets the System.Windows.Controls.Image that represents aligning the left edge of objects.
        /// </summary>
        // ------------------------------------------------------------------
        public static System.Windows.Controls.Image AlignObjectsLeft
        {
            get
            {
                return alignObjectsLeft;
            }
        }

        // ------------------------------------------------------------------
        /// <summary>
        /// Gets the System.Windows.Controls.Image that represents aligning the right edge of objects.
        /// </summary>
        // ------------------------------------------------------------------
        public static System.Windows.Controls.Image AlignObjectsRight
        {
            get
            {
                return alignObjectsRight;
            }
        }

        // ------------------------------------------------------------------
        /// <summary>
        /// Gets the System.Windows.Controls.Image that represents aligning the top edge of objects.
        /// </summary>
        // ------------------------------------------------------------------
        public static System.Windows.Controls.Image AlignObjectsTop
        {
            get
            {
                return alignObjectsTop;
            }
        }

        // ------------------------------------------------------------------
        /// <summary>
        /// Gets the System.Windows.Controls.Image that represents a arrow (standard cursor arrow).
        /// </summary>
        // ------------------------------------------------------------------
        public static System.Windows.Controls.Image Arrow
        {
            get
            {
                return arrow;
            }
        }

        // ------------------------------------------------------------------
        /// <summary>
        /// Gets the System.Windows.Controls.Image that represents bold font.
        /// </summary>
        // ------------------------------------------------------------------
        public static System.Windows.Controls.Image Bold
        {
            get
            {
                return bold;
            }
        }

        // ------------------------------------------------------------------
        /// <summary>
        /// Gets the System.Windows.Controls.Image that represents bringing an object all the way to
        /// to the front in the z-order.
        /// </summary>
        // ------------------------------------------------------------------
        public static System.Windows.Controls.Image BringToFront
        {
            get
            {
                return bringToFront;
            }
        }

        // ------------------------------------------------------------------
        /// <summary>
        /// Gets the System.Windows.Controls.Image that represents bring an object forward in the 
        /// z-order.
        /// </summary>
        // ------------------------------------------------------------------
        public static System.Windows.Controls.Image BringForward
        {
            get
            {
                return bringForward;
            }
        }

        // ------------------------------------------------------------------
        /// <summary>
        /// Gets an System.Windows.Controls.Image of a bucket of color - used to illustrate fill 
        /// color.
        /// </summary>
        // ------------------------------------------------------------------
        public static System.Windows.Controls.Image BucketFill
        {
            get
            {
                return bucketFill;
            }
        }

        // ------------------------------------------------------------------
        /// <summary>
        /// Gets the System.Windows.Controls.Image that represents text being centered.
        /// </summary>
        // ------------------------------------------------------------------
        public static System.Windows.Controls.Image CenterAlignment
        {
            get
            {
                return centerAlignment;
            }
        }

        // ------------------------------------------------------------------
        /// <summary>
        /// Gets the System.Windows.Controls.Image that represents a ClassShape.
        /// </summary>
        // ------------------------------------------------------------------
        public static System.Windows.Controls.Image ClassShape
        {
            get
            {
                return classShape;
            }
        }

        // ------------------------------------------------------------------
        /// <summary>
        /// Gets another System.Windows.Controls.Image that represents a ClassShape.
        /// </summary>
        // ------------------------------------------------------------------
        public static System.Windows.Controls.Image ClassShape2
        {
            get
            {
                return mClassShape2;
            }
        }

        // ------------------------------------------------------------------
        /// <summary>
        /// Gets the System.Windows.Controls.Image that represents a folder that's closed.  This is
        /// used by the DiagramExplorer to represent a TreeNode that is
        /// not expanded.
        /// </summary>
        // ------------------------------------------------------------------
        public static System.Windows.Controls.Image ClosedFolder
        {
            get
            {
                return closedFolder;
            }
        }

        // ------------------------------------------------------------------
        /// <summary>
        /// Gets the System.Windows.Controls.Image that represents a connection line.
        /// </summary>
        // ------------------------------------------------------------------
        public static System.Windows.Controls.Image Connection
        {
            get
            {
                return connection;
            }
        }

        // ------------------------------------------------------------------
        /// <summary>
        /// Gets the System.Windows.Controls.Image that represents copying an item.
        /// </summary>
        // ------------------------------------------------------------------
        public static System.Windows.Controls.Image Copy
        {
            get
            {
                return copy;
            }
        }

        // ------------------------------------------------------------------
        /// <summary>
        /// Gets the System.Windows.Controls.Image that represents cutting an item.
        /// </summary>
        // ------------------------------------------------------------------
        public static System.Windows.Controls.Image Cut
        {
            get
            {
                return cut;
            }
        }

        // ------------------------------------------------------------------
        /// <summary>
        /// Gets the System.Windows.Controls.Image that represents different dashstyles.
        /// </summary>
        // ------------------------------------------------------------------
        public static System.Windows.Controls.Image DashStyles
        {
            get
            {
                return dashStyles;
            }
        }

        // ------------------------------------------------------------------
        /// <summary>
        /// Gets the System.Windows.Controls.Image that has an 'x' to represent deleting something.
        /// </summary>
        // ------------------------------------------------------------------
        public static System.Windows.Controls.Image Delete
        {
            get
            {
                return delete;
            }
        }

        // ------------------------------------------------------------------
        /// <summary>
        /// Gets the System.Windows.Controls.Image that represents an ellipse.
        /// </summary>
        // ------------------------------------------------------------------
        public static System.Windows.Controls.Image DrawEllipse
        {
            get
            {
                return drawEllipse;
            }
        }

        // ------------------------------------------------------------------
        /// <summary>
        /// Gets the System.Windows.Controls.Image that represents a drawing, such as a Icon.
        /// </summary>
        // ------------------------------------------------------------------
        public static System.Windows.Controls.Image Drawing
        {
            get
            {
                return drawing;
            }
        }

        // ------------------------------------------------------------------
        /// <summary>
        /// Gets the System.Windows.Controls.Image that represents a rectangle.
        /// </summary>
        // ------------------------------------------------------------------
        public static System.Windows.Controls.Image DrawRectangle
        {
            get
            {
                return drawRectangle;
            }
        }

        // ------------------------------------------------------------------
        /// <summary>
        /// Gets the System.Windows.Controls.Image that represents font.
        /// </summary>
        // ------------------------------------------------------------------
        public static System.Windows.Controls.Image Font
        {
            get
            {
                return font;
            }
        }

        // ------------------------------------------------------------------
        /// <summary>
        /// Gets the System.Windows.Controls.Image that represents grouping objects together.
        /// </summary>
        // ------------------------------------------------------------------
        public static System.Windows.Controls.Image Group
        {
            get
            {
                return group;
            }
        }

        // ------------------------------------------------------------------
        /// <summary>
        /// Gets an System.Windows.Controls.Image of a hand (used to indicate panning).
        /// </summary>
        // ------------------------------------------------------------------
        public static System.Windows.Controls.Image Hand
        {
            get
            {
                return hand;
            }
        }

        // ------------------------------------------------------------------
        /// <summary>
        /// Gets an System.Windows.Controls.Image of italic font.
        /// </summary>
        // ------------------------------------------------------------------
        public static System.Windows.Controls.Image Italic
        {
            get
            {
                return italic;
            }
        }

        // ------------------------------------------------------------------
        /// <summary>
        /// Gets the System.Windows.Controls.Image that represents different shape layouts.
        /// </summary>
        // ------------------------------------------------------------------
        public static System.Windows.Controls.Image LayoutShapes
        {
            get
            {
                return layoutShapes;
            }
        }

        // ------------------------------------------------------------------
        /// <summary>
        /// Gets the System.Windows.Controls.Image that represents text being aligned to the left.
        /// </summary>
        // ------------------------------------------------------------------
        public static System.Windows.Controls.Image LeftAlignment
        {
            get
            {
                return leftAlignment;
            }
        }

        // ------------------------------------------------------------------
        /// <summary>
        /// Gets the System.Windows.Controls.Image that represents different linecaps.
        /// </summary>
        // ------------------------------------------------------------------
        public static System.Windows.Controls.Image LineCaps
        {
            get
            {
                return lineCaps;
            }
        }

        // ------------------------------------------------------------------
        /// <summary>
        /// Gets the System.Windows.Controls.Image that represents different line weights.
        /// </summary>
        // ------------------------------------------------------------------
        public static System.Windows.Controls.Image LineWeights
        {
            get
            {
                return lineWeights;
            }
        }

        // ------------------------------------------------------------------
        /// <summary>
        /// Gets the System.Windows.Controls.Image that represents a connection line.
        /// </summary>
        // ------------------------------------------------------------------
        public static System.Windows.Controls.Image MoveConnector
        {
            get
            {
                return moveConnector;
            }
        }

        // ------------------------------------------------------------------
        /// <summary>
        /// Gets the System.Windows.Controls.Image that represents straight lines, used for the
        /// MultiLine tool.
        /// </summary>
        // ------------------------------------------------------------------
        public static System.Windows.Controls.Image MultiLines
        {
            get
            {
                return multiLines;
            }
        }

        // ------------------------------------------------------------------
        /// <summary>
        /// Gets the System.Windows.Controls.Image that represents navigating to the next page.
        /// </summary>
        // ------------------------------------------------------------------
        public static System.Windows.Controls.Image NavigateForward
        {
            get
            {
                return navigateForward;
            }
        }

        // ------------------------------------------------------------------
        /// <summary>
        /// Gets the System.Windows.Controls.Image that represents navigating to the previous page.
        /// </summary>
        // ------------------------------------------------------------------
        public static System.Windows.Controls.Image NavigateBack
        {
            get
            {
                return navigateBack;
            }
        }

        // ------------------------------------------------------------------
        /// <summary>
        /// Gets the System.Windows.Controls.Image that represents creating a new diagram.
        /// </summary>
        // ------------------------------------------------------------------
        public static System.Windows.Controls.Image NewDocument
        {
            get
            {
                return newDocumnet;
            }
        }

        // ------------------------------------------------------------------
        /// <summary>
        /// Gets the System.Windows.Controls.Image that represents opening a file.
        /// </summary>
        // ------------------------------------------------------------------
        public static System.Windows.Controls.Image OpenFolder
        {
            get
            {
                return openFolder;
            }
        }

        // ------------------------------------------------------------------
        /// <summary>
        /// Gets the System.Windows.Controls.Image that represents a folder that's opened.  This is
        /// used by the DiagramExplorer to represent a TreeNode that is
        /// expanded.
        /// </summary>
        // ------------------------------------------------------------------
        public static System.Windows.Controls.Image OpenedFolder
        {
            get
            {
                return openedFolder;
            }
        }

        // ------------------------------------------------------------------
        /// <summary>
        /// Gets the System.Windows.Controls.Image that represents a pen drawing a line with a
        /// color - used to illustrate line color.
        /// </summary>
        // ------------------------------------------------------------------
        public static System.Windows.Controls.Image Outline
        {
            get
            {
                return outline;
            }
        }

        // ------------------------------------------------------------------
        /// <summary>
        /// Gets the System.Windows.Controls.Image that represents a page in a book.  This is used
        /// by the DiagramExplorer's PageNode.
        /// </summary>
        // ------------------------------------------------------------------
        public static System.Windows.Controls.Image Page
        {
            get
            {
                return page;
            }
        }

        // ------------------------------------------------------------------
        /// <summary>
        /// Gets the System.Windows.Controls.Image that represents pasting an item from the clipboard.
        /// </summary>
        // ------------------------------------------------------------------
        public static System.Windows.Controls.Image Paste
        {
            get
            {
                return paste;
            }
        }

        // ------------------------------------------------------------------
        /// <summary>
        /// Gets the System.Windows.Controls.Image that represents a picture or Icon.
        /// </summary>
        // ------------------------------------------------------------------
        public static System.Windows.Controls.Image Picture
        {
            get
            {
                return picture;
            }
        }

        // ------------------------------------------------------------------
        /// <summary>
        /// Gets the System.Windows.Controls.Image that represents a polygon.
        /// </summary>
        // ------------------------------------------------------------------
        public static System.Windows.Controls.Image Polygon
        {
            get
            {
                return polygon;
            }
        }

        // ------------------------------------------------------------------
        /// <summary>
        /// Gets the System.Windows.Controls.Image of a printer.
        /// </summary>
        // ------------------------------------------------------------------
        public static System.Windows.Controls.Image Print
        {
            get
            {
                return print;
            }
        }

        // ------------------------------------------------------------------
        /// <summary>
        /// Gets the System.Windows.Controls.Image for items that perform a print preview.
        /// </summary>
        // ------------------------------------------------------------------
        public static System.Windows.Controls.Image PrintPreview
        {
            get
            {
                return printPreview;
            }
        }

        // ------------------------------------------------------------------
        /// <summary>
        /// Gets the System.Windows.Controls.Image for items that perform a print setup.
        /// </summary>
        // ------------------------------------------------------------------
        public static System.Windows.Controls.Image PageSetup
        {
            get
            {
                return printSetup;
            }
        }

        // ------------------------------------------------------------------
        /// <summary>
        /// Gets the System.Windows.Controls.Image that represents properties.
        /// </summary>
        // ------------------------------------------------------------------
        public static System.Windows.Controls.Image Properties
        {
            get
            {
                return properties;
            }
        }

        // ------------------------------------------------------------------
        /// <summary>
        /// Gets the System.Windows.Controls.Image that represents redoing a command.
        /// </summary>
        // ------------------------------------------------------------------
        public static System.Windows.Controls.Image Redo
        {
            get
            {
                return redo;
            }
        }

        // ------------------------------------------------------------------
        /// <summary>
        /// Gets the System.Windows.Controls.Image that represents text being aligned to the right.
        /// </summary>
        // ------------------------------------------------------------------
        public static System.Windows.Controls.Image RightAlignment
        {
            get
            {
                return rightAlignment;
            }
        }

        // ------------------------------------------------------------------
        /// <summary>
        /// Gets the System.Windows.Controls.Image that represents saving to disk.
        /// </summary>
        // ------------------------------------------------------------------
        public static System.Windows.Controls.Image Save
        {
            get
            {
                return save;
            }
        }

        // ------------------------------------------------------------------
        /// <summary>
        /// Gets the System.Windows.Controls.Image that represents a database schema.
        /// </summary>
        // ------------------------------------------------------------------
        public static System.Windows.Controls.Image Schema
        {
            get
            {
                return schema;
            }
        }

        // ------------------------------------------------------------------
        /// <summary>
        /// Gets the System.Windows.Controls.Image that represents drawing arcs.
        /// </summary>
        // ------------------------------------------------------------------
        public static System.Windows.Controls.Image Scribble
        {
            get
            {
                return scribble;
            }
        }

        // ------------------------------------------------------------------
        /// <summary>
        /// Gets the System.Windows.Controls.Image that represents sending an object back in the 
        /// z-order.
        /// </summary>
        // ------------------------------------------------------------------
        public static System.Windows.Controls.Image SendBackwards
        {
            get
            {
                return sendBackwards;
            }
        }

        // ------------------------------------------------------------------
        /// <summary>
        /// Gets the System.Windows.Controls.Image that represents sending an object all the way back
        /// in the z-order.
        /// </summary>
        // ------------------------------------------------------------------
        public static System.Windows.Controls.Image SendToBack
        {
            get
            {
                return sendToBack;
            }
        }

        // ------------------------------------------------------------------
        /// <summary>
        /// Gets the System.Windows.Controls.Image for showing/hiding connectors.
        /// </summary>
        // ------------------------------------------------------------------
        public static System.Windows.Controls.Image ShowConnectors
        {
            get
            {
                return showConnectors;
            }
        }

        // ------------------------------------------------------------------
        /// <summary>
        /// Gets the System.Windows.Controls.Image for showing/hiding grid lines.
        /// </summary>
        // ------------------------------------------------------------------
        public static System.Windows.Controls.Image ShowGrid
        {
            get
            {
                return mshowGrid;
            }
        }

        // ------------------------------------------------------------------
        /// <summary>
        /// Gets the System.Windows.Controls.Image of a text box.  This is used to represent the
        /// simple TextOnlyShape.
        /// </summary>
        // ------------------------------------------------------------------
        public static System.Windows.Controls.Image TextBox
        {
            get
            {
                return textBox;
            }
        }

        // ------------------------------------------------------------------
        /// <summary>
        /// Gets the System.Windows.Controls.Image that represents undoing a command.
        /// </summary>
        // ------------------------------------------------------------------
        public static System.Windows.Controls.Image Undo
        {
            get
            {
                return undo;
            }
        }

        // ------------------------------------------------------------------
        /// <summary>
        /// Gets the System.Windows.Controls.Image that represents ungrouping objects.
        /// </summary>
        // ------------------------------------------------------------------
        public static System.Windows.Controls.Image Ungroup
        {
            get
            {
                return ungroup;
            }
        }

        // ------------------------------------------------------------------
        /// <summary>
        /// Gets the System.Windows.Controls.Image that represents zooming in.  The System.Windows.Controls.Image is a 
        /// magnifying glass with a plus sign.
        /// </summary>
        // ------------------------------------------------------------------
        public static System.Windows.Controls.Image ViewZoomIn
        {
            get
            {
                return viewZoomIn;
            }
        }

        // ------------------------------------------------------------------
        /// <summary>
        /// Gets the System.Windows.Controls.Image that represents zooming out.  The System.Windows.Controls.Image is a 
        /// magnifying glass with a minus sign.
        /// </summary>
        // ------------------------------------------------------------------
        public static System.Windows.Controls.Image ViewZoomOut
        {
            get
            {
                return viewZoomOut;
            }
        }

        // ------------------------------------------------------------------
        /// <summary>
        /// Gets the System.Windows.Controls.Image that represents zooming in.  The System.Windows.Controls.Image is a simple
        /// plus sign in a circle.
        /// </summary>
        // ------------------------------------------------------------------
        public static System.Windows.Controls.Image ZoomIn
        {
            get
            {
                return zoomIn;
            }
        }

        // ------------------------------------------------------------------
        /// <summary>
        /// Gets the System.Windows.Controls.Image that represents zooming in/out on an area.
        /// </summary>
        // ------------------------------------------------------------------
        public static System.Windows.Controls.Image ZoomMarquee
        {
            get
            {
                return zoomMarquee;
            }
        }

        // ------------------------------------------------------------------
        /// <summary>
        /// Gets the System.Windows.Controls.Image that represents zooming out.  The System.Windows.Controls.Image is a simple
        /// minus sign in a circle.
        /// </summary>
        // ------------------------------------------------------------------
        public static System.Windows.Controls.Image ZoomOut
        {
            get
            {
                return zoomOut;
            }
        }

        #endregion

        #region Helpers

        // ------------------------------------------------------------------
        /// <summary>
        /// Gets the System.Windows.Controls.Image from the embedded resources for the specified 
        /// filename and sets the Icon's transparent color to the one
        /// specified..
        /// </summary>
        /// <param name="filename">string: The filename from the embedded
        /// resources.</param>
        /// <param name="transparentColor">Color: The transparent color
        /// for the Icon.</param>
        /// <returns>Icon</returns>
        // ------------------------------------------------------------------
        static System.Windows.Controls.Image GetIcon(string filename, Color transparentColor)
        {
            System.Windows.Controls.Image bmp = GetIcon(filename);
            //bmp.MakeTransparent(transparentColor);
            return bmp;
        }

        // ------------------------------------------------------------------
        /// <summary>
        /// Gets the System.Windows.Controls.Image from the embedded resources for the specified 
        /// filename.
        /// </summary>
        /// <param name="filename">string: The filename from the embedded
        /// resources.</param>
        /// <returns>Icon</returns>
        // ------------------------------------------------------------------
        static System.Windows.Controls.Image GetIcon(string filename)
        {
            //GetStream(filename);
            //return new System.Windows.Controls.Image() { Source = new BitmapImage() { StreamSource = (GetStream(filename));
            return new System.Windows.Controls.Image() { Source = new BitmapImage(FilePath(filename)) };

        }

        static Uri FilePath(string filename)
        {
            var dir = Path.Combine(System.AppDomain.CurrentDomain.BaseDirectory , "Resources\\Icons");
            //dir = Path.Combine(dir, "icons");

            var uri = new Uri(dir + "\\" + filename, UriKind.Absolute);
            //if (Application.GetResourceStream(uri) == null)
            //{
            //    Console.WriteLine("no image : " + filename);
            //}
            //else
            //{
            //}

            if (filename == "StateChart.png")
            {

            }
            return uri;
        }

        // ------------------------------------------------------------------
        /// <summary>
        /// Gets the System.Windows.Controls.Image from the embedded resources for the specified 
        /// filename and converts it to an Icon.
        /// </summary>
        /// <param name="filename">string: The filename from the embedded
        /// resources.</param>
        /// <returns>Icon</returns>
        // ------------------------------------------------------------------
        static System.Windows.Controls.Image GetIconFromIcon(string filename)
        {
            //System.Windows.Controls.Image System.Windows.Controls.Image = new Icon(GetStream(filename));
            //Icon System.Windows.Controls.Image = Icon.FromHicon(icon.Handle);
            //GetStream(filename);
            return new System.Windows.Controls.Image() { Source = new BitmapImage(FilePath(filename)) };
            //return icon;
        }

        // ------------------------------------------------------------------
        /// <summary>
        /// Returns a Stream from the manifest resources for the specified 
        /// filename.
        /// </summary>
        /// <param name="filename">string</param>
        /// <returns>Stream</returns>
        // ------------------------------------------------------------------
        public static Stream GetStream(string filename)
        {
            try
            {
                //Application.GetResourceStream(
                var dir = "Resources";
                dir = Path.Combine(dir, "icons");
                if (!Directory.Exists(dir))
                {
                    Directory.CreateDirectory(dir);
                }
                var file = dir + "/" + filename;
                if (File.Exists(file))
                {
                    return null;
                }

                //filename = "SendBackwardHS.png";
                if (filename.Equals("UpdateModel.png"))
                {
                }
                //filename = "code.png";
                //nameSpace = "CodeHelper.Common";

                Stream obj = typeof(Icons).Assembly.GetManifestResourceStream(
                    nameSpace +
                    ".Resources." +
                    filename);
                if (obj == null)
                {
                }
                obj.Seek(0, SeekOrigin.Begin);


                var f = new FileStream(file, FileMode.CreateNew);

                var buff = new byte[obj.Length];
                obj.Read(buff, 0, buff.Length);
                f.Write(buff, 0, (int)buff.Length);
                f.Flush();
                f.Dispose();
                obj.Dispose();

                return obj;
            }
            catch (Exception e)
            {
                return null;
            }
        }

        #endregion
    }
}
