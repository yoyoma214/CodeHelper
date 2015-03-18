using db.cms;
namespace ns;

[comments("ddd","asd")]
class School
{
	Id(int,"int",false,true);	
	Name(string,"nvarchar(200)");
	Address(string,"nvarchar(200)");
}
