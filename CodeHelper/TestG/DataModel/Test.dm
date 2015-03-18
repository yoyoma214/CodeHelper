using db.cms;//db开头的命名空间为持久化的连接串，cms表示cms连接串。
			 //引用持久阶段的表模型，以下的C_User就是cms库的C_User表。
			 
using ns;//引用ns这个命名空间,包含另外一个文件定义的School表等等

//[name("value")] 是自定义属性，可以随意定义，可以提取成数据词典。

[comments("注释一","注释二")]
class People
{
	Id(int,"int",false,true);//.NET类型为int，数据库类型为int，不能为空，是主键
	
	Name (string,"nvarchar(200)");
	
	UserId(int,"int"); 
	
	[Comments("所在学校")]
	SchoolId(int,"int");

	[Choice("1:创建,2:初始化,3:停用")]
	Status(int,"int");
	
	CreateTime(DateTime,"date");
	
	UpdateTime(DateTime,"date");
	
	Country(string,"nvarchar(50)");//auto append by system.2014/12/03-21:44
}

//关联关系,规则为：主表名.map(主表外键列,导航属性,外键表名,外键表的关联字段,对应关系,在页面显示的关联列名1,列名2...)
People.map(UserId,User,C_Users,UserId,OneToOne,UserName,Email);

People.map(SchoolId,School,School,Id, OneToOne,Name);//School表是ns命名空间引入的，因此可以使用。
