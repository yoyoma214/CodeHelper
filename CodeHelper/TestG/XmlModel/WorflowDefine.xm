namespace CodeHelper.Workflow.Designer.Core.Config;
//可以指定任何一个元素为dom根节点。
class WorkflowDefine//表示一个xml 元素节点
{
	attr string Id;	//attr 表示xml属性
	attr string Name;
	attr string Description;
	attr string Variable;

	List<FieldDef> Fields;//List<T> 表示xml node的集合
	List<ClassDef> Classes;	
	
	InitDef Init; //表示含有一个名叫Init的InitDef的node
	StartStateDef StartState;
	List<TerminateStateDef> TerminateStates;

	List<StateDef> States;
	List<ParallelDef> Parallels;	
	List<SubFlowStateDef> SubFlowStates;
}
 
class StartStateDef
{
	attr string Id;	
	attr string Name;
	attr string Text;
	attr string Description;
	List<TranslationDef> Transitions;
}

class TerminateStateDef
{
	attr string Id;	
	attr string Name;
	attr string LineId;
	attr int LineIndex;
	attr string Text;
	attr string Description;
}

class StateDef
{	
	attr string Id;	
	attr string Name;
	attr string Text;
	attr string Description;
	attr string LineId;
	attr int LineIndex;
	attr string RefWorkflow;
	attr string Variable;
	
	List<FieldDef> Fields;
	List<ClassDef> Classes;	
	
	InitDef Init;	
	List<TranslationDef> Transitions;
	BeforeAction Before;
	AfterAction After;
	
	FormDef Form;
}

class ClassDef
{
	attr string Id;
	attr string Name;	
	attr string Description;
	List<FieldDef> Fields;	
}

class FieldDef
{
	attr string Id;
	attr string Name;
	attr string Description;
	attr string Type;
	attr bool Nullable;	
	attr bool IsList;
	attr string DefaultValue;
}

class InitDef
{
	attr string Code;
}

class TranslationDef
{
	attr string Id;
	attr string Text;
	attr string Description;		
	attr string TargetId;	
	List<ConditionDef> Conditions;
}

class ConditionDef
{
	attr string Left;
	attr string ConditionType;
	attr string Right;
}

class BeforeAction
{
	attr string Code;
}

class AfterAction
{
	attr string Code;
}

class ParallelDef
{
	attr string Id;
	attr string Name;
	attr string Text;
	attr string Description;
	attr string LineId;
	attr int LineIndex;
	List<ClassDef> Classes;	
	List<FieldDef> Fields;
	InitDef Init;	
	List<TranslationDef> Transitions;
	List<ExecuteLineDef> ExecuteLines;
	BeforeAction Before;
	AfterAction After;		
}

class ExecuteLineDef
{
	attr string Id;
	attr string Name;
	attr string Description;
	attr string ParallelId;
	List<StateDef> States;
	List<ParallelDef> Parallels;
	List<SubFlowStateDef> SubFlowStates;
	List<TerminateStateDef> TerminateStates;
}

class SubFlowStateDef
{
	attr string Id;	
	attr string Name;
	attr string Text;
	attr string Description;
	attr string LineId;
	attr int LineIndex;
	attr string RefWorkflow;
	attr string Variable;
	
	InitDef Init;	
	List<TranslationDef> Transitions;
	BeforeAction Before;
	AfterAction After;
}

class FormDef
{
	attr string Title;
	attr string Description;
	List<FormFieldDef> Fields;
	List<SubFormDef> SubForms;
}

class SubFormDef
{	
	attr string Title;
	attr string Description;
	attr string BindingField;
	List<FormFieldDef> Fields;
}

class FormFieldDef
{
	attr string Name;
	attr string Label;
	attr string Field;
	DataSourceDef Source;
	attr string ControlType;
	attr bool Nullable;
	attr string CommonValidation;
	attr string CustomValidation;
	attr string Description;
}

class DataSourceDef
{
	attr string Field;	
}