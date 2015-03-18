namespace Project;

class QueryType1
{
	attr string Name;
	List<SqlType> Sqls;
	List<QueryType> Queries;
	
	attr_group{
		order = true;
		attr string Name1;
		attr string Name2;
	}
	
	field_group{
		order = true;
		List<SqlType> Sqls;
		List<QueryType> Queries;
	}
}

class QueryType2
{
	attr string Name;
	List<SqlType> Sqls;
	List<QueryType> Queries;
	
	attr_group{
		order = true;
		attr string Name1;
		attr string Name2;
	}
	
	field_group{
		order = true;
		List<SqlType> Sqls;
		List<QueryType> Queries;
	}
}