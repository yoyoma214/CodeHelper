
namespace CodeHelper.Workflow.Designer.Core.Config;

class WorkflowGraph
{
	attr string Id;
	StartStateNode StartState;
	List<StateNode> States;
	List<ParallelStateNode> ParallelStates;
	List<TransitionNode> Transitions;
	List<SubFlowStateNode> SubFlowStates;
	List<TerminateStateNode> TerminateStates; 
}

class StartStateNode{
	attr string Id;
	attr string Name;
	attr string Text;		
	attr double Left;
	attr double Top;
	attr double Width;
	attr double Height;
	attr int ZIndex;
	ConnectorNode CenterConnector;
}

class ConnectorNode{
	attr string Id;
	attr string Name;
	attr double Center_X;
	attr double Center_Y;
	attr double Left;
	attr double Top;
	attr double Width;
	attr double Height;
	attr string AttachedId;
}

class StateNode
{
	attr string Id;
	attr string ParentId;
	attr string Name;
	attr string Text;
	attr double Left;
	attr double Top;
	attr double Width;
	attr double Height;
	attr int ZIndex;	
	ConnectorNode CenterConnector;
}

class ParallelStateNode
{
	attr string Id;
	attr string ParentId;
	attr string Name;
	attr string Text;
	attr double Left;
	attr double Top;
	attr double Width;
	attr double Height;
	attr int ZIndex;
	attr string Children;
	ConnectorNode InConnector;
	ConnectorNode OutConnector;
} 

class TransitionNode
{
	attr string Id;
	attr string Name;
	attr string Text;
	attr int ZIndex;
	ConnectorNode From;
	ConnectorNode To;
}

class SubFlowStateNode
{
	attr string Id;
	attr string ParentId;
	attr string RefWorkflowId;
	attr string Name;
	attr string Text;
	attr double Left;
	attr double Top;
	attr double Width;
	attr double Height;	
	attr int ZIndex;
	ConnectorNode CenterConnector;
}

class TerminateStateNode
{	
	attr string Id;
	attr string ParentId;
	attr string Name;
	attr string Text;
	attr double Left;
	attr double Top;
	attr double Width;
	attr double Height;	
	attr int ZIndex;
	ConnectorNode CenterConnector;
}
