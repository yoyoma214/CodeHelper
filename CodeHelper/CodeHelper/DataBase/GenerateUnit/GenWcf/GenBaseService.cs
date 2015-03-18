using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Project;
using CodeHelper.DataBaseHelper.Items.DBItems;
using CodeHelper.DataBaseHelper.Common;
using CodeHelper.DataBaseHelper.Extensions;

namespace CodeHelper.DataBaseHelper.GenerateUnit.GenWcf
{
    class GenBaseService: BaseGen
    {
        ModelType Model = null;
        ColumnSetNode ColumnSetNode = null;
        public GenBaseService(ModelType model, ColumnSetNode columnSetNode)
        {
            this.Model = model;
            this.ColumnSetNode = columnSetNode;
        }

        public override void Generate(StringBuilder builder)
        {
            var entityName = Helper.GetClassName(this.Model.Name);
            var varEntityName = Helper.GetVarName(this.Model.Name);
            var dtoName = entityName + "Dto";
            var dtoVariable = Helper.GetVarName(dtoName);

            #region App Service

            builder.AppendLine("        #region App Service Interface");
            builder.AppendLine();
            builder.AppendLine("        ReturnInfoDto Add" + this.Model.Name + "(" + dtoName
                + " " + dtoVariable + ");");
            builder.AppendLine();

            builder.AppendLine("        ReturnInfoDto Update" + this.Model.Name + "(" + dtoName
                + " " + dtoVariable + ");");
            builder.AppendLine();

            builder.AppendLine(string.Format("        ReturnInfoDto<{0}> Get{1}(Guid id);", dtoName,entityName));
            builder.AppendLine();

            builder.AppendLine(string.Format("        ReturnInfoDto<List<{0}>> Get{1}List(List<Guid> id_list);", dtoName,entityName));
            builder.AppendLine();

            builder.AppendLine("        ReturnInfoDto Delete" + this.Model.Name + "(Guid id);");
            builder.AppendLine();


            builder.AppendLine("        ReturnInfoDto Delete" + this.Model.Name + "(List<Guid> id_list);");
            builder.AppendLine();
            builder.AppendLine("        #endregion");
            builder.AppendLine();

            builder.AppendLine("        #region App Service Implement");
            builder.AppendLine();
            builder.AppendLine("        public ReturnInfoDto Add" + this.Model.Name + "(" + dtoName
                + " " + dtoVariable + ")");
            builder.AppendLine("        {");
            builder.AppendLine("        \tvar rtnInfo = new ReturnInfoDto();");
            builder.AppendLine("        \trtnInfo.Message = string.Empty;");
            builder.AppendLine("        \trtnInfo.IsSuccess = false;");


            builder.AppendLine("        \ttry");
            builder.AppendLine("        \t{");

            builder.AppendLine("        \t\t" + DBGlobalService.DbContexUsingClause);
            builder.AppendLine("        \t\t{");
            
            builder.AppendLine(string.Format("        \t\t\tvar {0}DB = new {1}Repository(unitOfWork);", varEntityName, entityName));
            if (!DBGlobalService.UseAutoMapper)
            {
                builder.AppendLine(string.Format("        \t\t\tvar {0} = DataConverter.ConvertTo{1}({2});", varEntityName, entityName, dtoVariable));
            }
            else
            {
                builder.AppendLine(string.Format("        \t\t\tvar {0} = Mapper.Map<{1},{2}>({3});", varEntityName, dtoName, entityName, dtoVariable));
            }
            
            builder.AppendLine(string.Format("        \t\t\t{0}DB.Add({0});", varEntityName));
            builder.AppendLine("        \t\t\tunitOfWork.Commit();");
            builder.AppendLine("        \t\t}");
            builder.AppendLine("        \t}");
            builder.AppendLine("        \tcatch (Exception ex)");
            builder.AppendLine("        \t{");
            builder.AppendLine("        \t\trtnInfo.Message = ex.Message;");
            builder.AppendLine("        \t\treturn rtnInfo;");
            builder.AppendLine("        \t}");
            builder.AppendLine();
            builder.AppendLine("        \trtnInfo.IsSuccess = true;");
            builder.AppendLine("        \treturn rtnInfo;");
            builder.AppendLine("        }");
            builder.AppendLine();

            //builder.AppendLine();

            builder.AppendLine("        public ReturnInfoDto Update" + this.Model.Name + "(" + dtoName
                + " " + dtoVariable + ")");
            builder.AppendLine("        {");
            builder.AppendLine("        \tvar rtnInfo = new ReturnInfoDto();");
            builder.AppendLine("        \trtnInfo.Message = string.Empty;");
            builder.AppendLine("        \trtnInfo.IsSuccess = false;");         

            builder.AppendLine("        \ttry");
            builder.AppendLine("        \t{");
            //builder.AppendLine("        \t\tusing (var unitOfWork = UnitOfWorkFactory.Create(DbOption.OA))");
            builder.AppendLine("        \t\t" + DBGlobalService.DbContexUsingClause);
            builder.AppendLine("        \t\t{");
            builder.AppendLine(string.Format("        \t\t\tvar {0}DB = new {1}Repository(unitOfWork);", varEntityName, entityName));

            builder.AppendLine(string.Format("        \t\t\tvar info = {0}DB.Get({1}.Id);",varEntityName, dtoVariable));
            builder.AppendLine(string.Format("        \t\t\tif (info == null)"));
            builder.AppendLine("        \t\t\t{");
            builder.AppendLine(string.Format("        \t\t\t\trtnInfo.Message = \"the data is not in system.\";"));
            builder.AppendLine(string.Format("        \t\t\t\treturn rtnInfo;"));
            builder.AppendLine("        \t\t\t}");
            if (!DBGlobalService.UseAutoMapper)
            {
                builder.AppendLine(string.Format("        \t\t\tvar other = DataConverter.ConvertTo{1}({2});", varEntityName, entityName, dtoVariable));
            }
            else
            {
                builder.AppendLine(string.Format("        \t\t\tvar other = Mapper.Map<{0},{1}>({2});", dtoName, entityName, dtoVariable));
            }
            builder.AppendLine(string.Format("        \t\t\tinfo.AssignFrom(other);"));
            builder.AppendLine(string.Format("        \t\t\t{0}DB.Modify(info);", varEntityName));
            builder.AppendLine("        \t\t\tunitOfWork.Commit();");
            builder.AppendLine("        \t\t}");
            builder.AppendLine("        \t}");
            builder.AppendLine("        \tcatch (Exception ex)");
            builder.AppendLine("        \t{");
            builder.AppendLine("        \t\trtnInfo.Message = ex.Message;");
            builder.AppendLine("        \t\treturn rtnInfo;");
            builder.AppendLine("        \t}");
            builder.AppendLine();
            builder.AppendLine("        \trtnInfo.IsSuccess = true;");
            builder.AppendLine("        \treturn rtnInfo;");
            builder.AppendLine("        }");
            builder.AppendLine();

            //builder.AppendLine();

            builder.AppendLine(string.Format("        public ReturnInfoDto<{0}> Get{1}(Guid id)", dtoName,entityName));
            builder.AppendLine("        {");
            builder.AppendLine(string.Format("        \tvar rtnInfo = new ReturnInfoDto<{0}>();",dtoName));
            builder.AppendLine("        \trtnInfo.Message = string.Empty;");
            builder.AppendLine("        \trtnInfo.IsSuccess = false;");
            builder.AppendLine("        \ttry");
            builder.AppendLine("        \t{");
            //builder.AppendLine("        \t\tusing (var unitOfWork = UnitOfWorkFactory.Create(DbOption.OA))");
            builder.AppendLine("        \t\t" + DBGlobalService.DbContexUsingClause);
            builder.AppendLine("        \t\t{");
            builder.AppendLine(string.Format("        \t\t\tvar {0}DB = new {1}Repository(unitOfWork);", varEntityName, entityName));
            builder.AppendLine(string.Format("        \t\t\tvar {0} = {1}DB.Get(id);", varEntityName, varEntityName));
            builder.AppendLine(string.Format("        \t\t\tif({0} != null)", varEntityName));
            builder.AppendLine("        \t\t\t{");
            if (!DBGlobalService.UseAutoMapper)
            {
                builder.AppendLine(string.Format("        \t\t\t\trtnInfo.Data = DataConverter.ConvertTo{0}({1});", dtoName, varEntityName));
            }
            else
            {
                builder.AppendLine(string.Format("        \t\t\t\trtnInfo.Data = Mapper.Map<{0},{1}>({2});", entityName, dtoName, varEntityName));
            }
            builder.AppendLine("        \t\t\t}");
            //builder.AppendLine(string.Format("        \t\t\trtnInfo.Data = {0};",dtoVariable));
            //builder.AppendLine("        \t\t\tunitOfWork.Commit();");
            builder.AppendLine("        \t\t}");
            builder.AppendLine("        \t}");
            builder.AppendLine("        \tcatch (Exception ex)");
            builder.AppendLine("        \t{");
            builder.AppendLine("        \t\trtnInfo.Message = ex.Message;");
            builder.AppendLine("        \t\treturn rtnInfo;");
            builder.AppendLine("        \t}");
            builder.AppendLine();
            builder.AppendLine("        \trtnInfo.IsSuccess = true;");
            builder.AppendLine("        \treturn rtnInfo;");
            builder.AppendLine("        }");
            builder.AppendLine();

            builder.AppendLine(string.Format("        public ReturnInfoDto<List<{0}>> Get{1}List(List<Guid> id_list)", dtoName,entityName));
            builder.AppendLine("        {");
            builder.AppendLine(string.Format("        \tvar rtnInfo = new ReturnInfoDto<List<{0}>>();", dtoName));
            builder.AppendLine("        \trtnInfo.Message = string.Empty;");
            builder.AppendLine("        \trtnInfo.IsSuccess = false;");
            builder.AppendLine(string.Format("        \trtnInfo.Data = new List<{0}>();",dtoName));
            builder.AppendLine("        \ttry");
            builder.AppendLine("        \t{");
            //builder.AppendLine("        \t\tusing (var unitOfWork = UnitOfWorkFactory.Create(DbOption.OA))");
            builder.AppendLine("        \t\t" + DBGlobalService.DbContexUsingClause);
            builder.AppendLine("        \t\t{");
            builder.AppendLine(string.Format("        \t\t\tvar {0}DB = new {1}Repository(unitOfWork);", varEntityName, entityName));
            builder.AppendLine(string.Format("        \t\t\tvar list = {0}DB.GetList(id_list);", varEntityName));
            builder.AppendLine(string.Format("        \t\t\tif(list != null && list.Count > 0 )", varEntityName));
            builder.AppendLine("        \t\t\t{");
            if (!DBGlobalService.UseAutoMapper)
            {
                builder.AppendLine(string.Format("        \t\t\t\tlist.ForEach( x => rtnInfo.Data.Add(DataConverter.ConvertTo{0}(x)));", dtoName));
            }
            else
            {
                builder.AppendLine(string.Format("        \t\t\t\tlist.ForEach( x => rtnInfo.Data.Add(Mapper.Map<{0}, {1}>(x)));", entityName, dtoName));
            }
            builder.AppendLine("        \t\t\t}");
            builder.AppendLine("        \t\t}");
            builder.AppendLine("        \t}");
            builder.AppendLine("        \tcatch (Exception ex)");
            builder.AppendLine("        \t{");
            builder.AppendLine("        \t\trtnInfo.Message = ex.Message;");
            builder.AppendLine("        \t\treturn rtnInfo;");
            builder.AppendLine("        \t}");
            builder.AppendLine();
            builder.AppendLine("        \trtnInfo.IsSuccess = true;");
            builder.AppendLine("        \treturn rtnInfo;");
            builder.AppendLine("        }");
            builder.AppendLine();


            builder.AppendLine("        public ReturnInfoDto Delete" + this.Model.Name + "(Guid id)");
            builder.AppendLine("        {");
            builder.AppendLine("        \tvar rtnInfo = new ReturnInfoDto();");
            builder.AppendLine("        \trtnInfo.Message = string.Empty;");
            builder.AppendLine("        \trtnInfo.IsSuccess = false;");
            builder.AppendLine("        \ttry");
            builder.AppendLine("        \t{");
            //builder.AppendLine("        \t\tusing (var unitOfWork = UnitOfWorkFactory.Create(DbOption.OA))");
            builder.AppendLine("        \t\t" + DBGlobalService.DbContexUsingClause);
            builder.AppendLine("        \t\t{");
            builder.AppendLine(string.Format("        \t\t\tvar {0}DB = new {1}Repository(unitOfWork);", varEntityName, entityName));
            builder.AppendLine(string.Format("        \t\t\tvar {0} = {0}DB.Get(id);", varEntityName, entityName, dtoVariable));
            builder.AppendLine(string.Format("        \t\t\tif({0} == null )", varEntityName));
            builder.AppendLine(("        \t\t\t{"));
            builder.AppendLine(string.Format("        \t\t\t\trtnInfo.Message = \"the data is not in system.\";"));
            builder.AppendLine(string.Format("        \t\t\t\treturn rtnInfo;"));
            builder.AppendLine(("        \t\t\t}"));
            builder.AppendLine(string.Format("        \t\t\t//{0}.Available = false;", varEntityName));
            builder.AppendLine(string.Format("        \t\t\t//{0}DB.Modify({0});", varEntityName));
            builder.AppendLine(string.Format("        \t\t\t{0}DB.Remove({0});", varEntityName));
            builder.AppendLine("        \t\t\tunitOfWork.Commit();");
            builder.AppendLine("        \t\t}");
            builder.AppendLine("        \t}");
            builder.AppendLine("        \tcatch (Exception ex)");
            builder.AppendLine("        \t{");
            builder.AppendLine("        \t\trtnInfo.Message = ex.Message;");
            builder.AppendLine("        \t\treturn rtnInfo;");
            builder.AppendLine("        \t}");
            builder.AppendLine();
            builder.AppendLine("        \trtnInfo.IsSuccess = true;");
            builder.AppendLine("        \treturn rtnInfo;");
            builder.AppendLine("        }");
            builder.AppendLine();

            //builder.AppendLine();

            builder.AppendLine("        public ReturnInfoDto Delete" + this.Model.Name + "(List<Guid> id_list)");
            builder.AppendLine("        {");
            builder.AppendLine("        \tvar rtnInfo = new ReturnInfoDto();");
            builder.AppendLine("        \trtnInfo.Message = string.Empty;");
            builder.AppendLine("        \trtnInfo.IsSuccess = false;");
            builder.AppendLine("        \ttry");
            builder.AppendLine("        \t{");
            //builder.AppendLine("        \t\tusing (var unitOfWork = UnitOfWorkFactory.Create(DbOption.OA))");
            builder.AppendLine("        \t\t" + DBGlobalService.DbContexUsingClause);
            builder.AppendLine("        \t\t{");
            builder.AppendLine(string.Format("        \t\t\tvar {0}DB = new {1}Repository(unitOfWork);", varEntityName, entityName));
            builder.AppendLine(string.Format("        \t\t\tvar {0}_list = {0}DB.GetList(id_list);", varEntityName, entityName));
            builder.AppendLine(string.Format("        \t\t\tforeach (var {0} in {0}_list)",varEntityName));
            builder.AppendLine(("        \t\t\t{"));
            builder.AppendLine(string.Format("        \t\t\t\t//{0}.Available = false;", varEntityName));
            builder.AppendLine(string.Format("        \t\t\t\t//{0}DB.Modify({0});", varEntityName));
            builder.AppendLine(string.Format("        \t\t\t\t{0}DB.Remove({0});", varEntityName));
            builder.AppendLine(("        \t\t\t}"));
            //builder.AppendLine(string.Format("        \t\t\tif({0} == null )", varEntityName));
            //builder.AppendLine(("        \t\t\t{"));
            //builder.AppendLine(string.Format("        \t\t\t\trtnInfo.Message = \"the data is not in system.\";"));
            //builder.AppendLine(string.Format("        \t\t\t\treturn rtnInfo;"));
            //builder.AppendLine(("        \t\t\t}"));
            //builder.AppendLine(string.Format("        \t\t\t{0}DB.Modify({0});", varEntityName));
            builder.AppendLine("        \t\t\tunitOfWork.Commit();");
            builder.AppendLine("        \t\t}");
            builder.AppendLine("        \t}");
            builder.AppendLine("        \tcatch (Exception ex)");
            builder.AppendLine("        \t{");
            builder.AppendLine("        \t\trtnInfo.Message = ex.Message;");
            builder.AppendLine("        \t\treturn rtnInfo;");
            builder.AppendLine("        \t}");
            builder.AppendLine();
            builder.AppendLine("        \trtnInfo.IsSuccess = true;");
            builder.AppendLine("        \treturn rtnInfo;");
            builder.AppendLine("        }");
            builder.AppendLine();
            builder.AppendLine("        #endregion");
            builder.AppendLine();

            #endregion

            #region Distribute Service
            builder.AppendLine("        #region Distribute Service Interface");
            builder.AppendLine();
            builder.AppendLine(@"        [OperationContract]
        [WithoutAuthorization]
        [FaultContractAttribute(typeof(UnAuthorization))]");

            builder.AppendLine("        ReturnInfoDto Add" + this.Model.Name + "(" + dtoName 
                +" " + dtoVariable + ");");
            builder.AppendLine();

            builder.AppendLine(@"        [OperationContract]
        [WithoutAuthorization]
        [FaultContractAttribute(typeof(UnAuthorization))]");

            builder.AppendLine("        ReturnInfoDto Update" + this.Model.Name + "(" + dtoName
                + " " + dtoVariable + ");");
            builder.AppendLine();

            builder.AppendLine(@"        [OperationContract]
        [WithoutAuthorization]
        [FaultContractAttribute(typeof(UnAuthorization))]");

            builder.AppendLine(string.Format("        ReturnInfoDto<{0}> Get{1}(Guid id);",dtoName, entityName));
            builder.AppendLine();

            builder.AppendLine(@"        [OperationContract]
        [WithoutAuthorization]
        [FaultContractAttribute(typeof(UnAuthorization))]");

            builder.AppendLine(string.Format("        ReturnInfoDto<List<{0}>> Get{1}List(List<Guid> id_list);",dtoName, entityName));
            builder.AppendLine();

            builder.AppendLine(@"        [OperationContract]
        [WithoutAuthorization]
        [FaultContractAttribute(typeof(UnAuthorization))]");

            builder.AppendLine("        ReturnInfoDto Delete" + this.Model.Name + "(Guid id);");
            builder.AppendLine();

            builder.AppendLine(@"        [OperationContract]
        [WithoutAuthorization]
        [FaultContractAttribute(typeof(UnAuthorization))]");

            builder.AppendLine("        ReturnInfoDto Delete" + this.Model.Name + "List(List<Guid> id_list);");
            builder.AppendLine();
            builder.AppendLine("        #endregion");
            builder.AppendLine();

            builder.AppendLine("        #region Distribute Service Implement");
            builder.AppendLine();
            builder.AppendLine("        public ReturnInfoDto Add" + this.Model.Name + "(" + dtoName
                + " " + dtoVariable + ")");
            builder.AppendLine("        {");
            builder.AppendLine("        \treturn _appService.Add" + this.Model.Name + "(" + dtoVariable + ");");

            builder.AppendLine("        }");
            builder.AppendLine();

            builder.AppendLine("        public ReturnInfoDto Update" + this.Model.Name + "(" + dtoName
              + " " + dtoVariable + ")");

            builder.AppendLine("        {");
            builder.AppendLine("        \treturn _appService.Update" + this.Model.Name + "(" + dtoVariable + ");");

            builder.AppendLine("        }");
            builder.AppendLine();

            builder.AppendLine(string.Format("        public ReturnInfoDto<{0}> Get{1}(Guid id)", dtoName,entityName));
            builder.AppendLine("        {");
            builder.AppendLine("        \treturn _appService.Get" + this.Model.Name + "( id );");

            builder.AppendLine("        }");
            builder.AppendLine();

            builder.AppendLine(string.Format("        public ReturnInfoDto<List<{0}>> Get{1}List(List<Guid> id_list)", dtoName,entityName));
            builder.AppendLine("        {");
            builder.AppendLine(string.Format("        \treturn _appService.Get{0}List( id_list );", entityName));

            builder.AppendLine("        }");

            builder.AppendLine();

            builder.AppendLine("        public ReturnInfoDto Delete" + this.Model.Name + "(Guid id)");
            builder.AppendLine("        {");
            builder.AppendLine("        \treturn _appService.Delete" + this.Model.Name + "( id );");

            builder.AppendLine("        }");
            builder.AppendLine();

            builder.AppendLine("        public ReturnInfoDto Delete" + this.Model.Name + "List(List<Guid> id_list)");
            builder.AppendLine("        {");
            builder.AppendLine("        \treturn _appService.Delete" + this.Model.Name + "( id_list );");

            builder.AppendLine("        }");
            builder.AppendLine();
            builder.AppendLine("        #endregion");
            builder.AppendLine();
            #endregion

            #region Service Layer

            var viewModel = Helper.GetViewMode(entityName);
            var varViewModel = Helper.GetVarName(viewModel);

            builder.AppendLine("        #region Service Layer");
            builder.AppendLine();
            builder.AppendLine("        public ReturnInfo Add" + this.Model.Name + "(" + viewModel
                + " " + varViewModel + ")");
            builder.AppendLine("        {");
            builder.AppendLine("        \tvar result = new ReturnInfo();");
            builder.AppendLine();
            builder.AppendLine("        \ttry");
            builder.AppendLine("        \t{");
            if (!DBGlobalService.UseAutoMapper)
            {
                builder.AppendLine(string.Format("        \t\tvar dto = DataConverter.ConvertTo{0}({1});", dtoName, varViewModel));
            }
            else
            {
                builder.AppendLine(string.Format("        \t\tvar dto = Mapper.Map<{0}, {1}>({2});", viewModel, dtoName, varViewModel));
            }
            builder.AppendLine(string.Format("        \t\tvar rslt = serviceClient.Invoke<ReturnInfoDto>(x => x.Add{0}(dto));",entityName));
            builder.AppendLine("        \t\tresult.IsSuccess = rslt.IsSuccess;");
            builder.AppendLine("        \t\tresult.Message = rslt.Message;");
            builder.AppendLine("        \t\t");
            builder.AppendLine("        \t}");
            builder.AppendLine("        \tcatch (Exception e)");
            builder.AppendLine("        \t{");
            builder.AppendLine("        \t\tLogHelper.Error(e);");
            builder.AppendLine("        \t\tresult.IsSuccess = false;");
            builder.AppendLine("        \t\tresult.Message = \"call service error\";");
            builder.AppendLine("        \t}");
            builder.AppendLine("");
            builder.AppendLine("        \treturn result;");
            builder.AppendLine("        }");
            builder.AppendLine();

            builder.AppendLine("        public ReturnInfo Update" + this.Model.Name + "(" + viewModel
                + " " + varViewModel + ")");
            builder.AppendLine("        {");
            builder.AppendLine("        \tvar result = new ReturnInfo();");
            builder.AppendLine();
            builder.AppendLine("        \ttry");
            builder.AppendLine("        \t{");
            if (!DBGlobalService.UseAutoMapper)
            {
                builder.AppendLine(string.Format("        \t\tvar dto = DataConverter.ConvertTo{0}({1});", dtoName, varViewModel));
            }
            else
            {
                builder.AppendLine(string.Format("        \t\tvar dto = Mapper.Map<{0}, {1}>({2});", viewModel, dtoName, varViewModel));
            }
            builder.AppendLine(string.Format("        \t\tvar rslt = serviceClient.Invoke<ReturnInfoDto>(x => x.Update{0}(dto));", entityName));
            builder.AppendLine("        \t\tresult.IsSuccess = rslt.IsSuccess;");
            builder.AppendLine("        \t\tresult.Message = rslt.Message;");
            builder.AppendLine("        \t\t");
            builder.AppendLine("        \t}");
            builder.AppendLine("        \tcatch (Exception e)");
            builder.AppendLine("        \t{");
            builder.AppendLine("        \t\tLogHelper.Error(e);");
            builder.AppendLine("        \t\tresult.IsSuccess = false;");
            builder.AppendLine("        \t\tresult.Message = \"call service error\";");
            builder.AppendLine("        \t}");
            builder.AppendLine("");
            builder.AppendLine("        \treturn result;");
            builder.AppendLine("        }");
            builder.AppendLine();

            builder.AppendLine(string.Format("        public ReturnInfo<{0}> Get{1}(Guid id)", viewModel, entityName));
            builder.AppendLine("        {");
            builder.AppendLine(string.Format("        \tvar result = new ReturnInfo<{0}>();",viewModel));
            builder.AppendLine();
            builder.AppendLine("        \ttry");
            builder.AppendLine("        \t{");            
            builder.AppendLine(string.Format("        \t\tvar rslt = serviceClient.Invoke<ReturnInfoDto<{0}Dto>>(x => x.Get{0}(id));", entityName));
            if (!DBGlobalService.UseAutoMapper)
            {
                builder.AppendLine(string.Format("        \t\tresult.Data = DataConverter.ConvertTo{0}(rslt.Data);", viewModel));
            }
            else
            {
                builder.AppendLine(string.Format("        \t\tresult.Data = Mapper.Map<{0}, {1}>(rslt.Data);", dtoName, viewModel));
            }
            builder.AppendLine("        \t\tresult.IsSuccess = rslt.IsSuccess;");
            builder.AppendLine("        \t\tresult.Message = rslt.Message;");
            builder.AppendLine("        \t\t");
            builder.AppendLine("        \t}");
            builder.AppendLine("        \tcatch (Exception e)");
            builder.AppendLine("        \t{");
            builder.AppendLine("        \t\tLogHelper.Error(e);");
            builder.AppendLine("        \t\tresult.IsSuccess = false;");
            builder.AppendLine("        \t\tresult.Message = \"call service error\";");
            builder.AppendLine("        \t}");
            builder.AppendLine("");
            builder.AppendLine("        \treturn result;");
            builder.AppendLine("        }");
            builder.AppendLine();

            builder.AppendLine(string.Format("        public ReturnInfo<List<{0}>> Get{1}List(List<Guid> id_list)", viewModel, entityName));
            builder.AppendLine("        {");
            builder.AppendLine(string.Format("        \tvar result = new ReturnInfo<List<{0}>>();", viewModel));
            builder.AppendLine(string.Format("        \tresult.Data = new List<{0}>();",viewModel));
            builder.AppendLine();
            builder.AppendLine("        \ttry");
            builder.AppendLine("        \t{");
            builder.AppendLine(string.Format("        \t\tvar rslt = serviceClient.Invoke<ReturnInfoDto<List<{0}Dto>>>(x => x.Get{0}List(id_list));", entityName));            
            builder.AppendLine("        \t\tresult.IsSuccess = rslt.IsSuccess;");
            builder.AppendLine("        \t\tresult.Message = rslt.Message;");
            builder.AppendLine("        \t\tif (rslt.IsSuccess )");
            builder.AppendLine("        \t\t{");
            builder.AppendLine("        \t\t\tif (rslt.Data != null && rslt.Data.Count > 0)");
            builder.AppendLine("        \t\t\t{");
            if (!DBGlobalService.UseAutoMapper)
            {
                builder.AppendLine(string.Format("        \t\t\t\trslt.Data.ForEach(x => result.Data.Add(DataConverter.ConvertTo{0}(x)));", viewModel));
            }
            else
            {
                builder.AppendLine(string.Format("        \t\t\t\trslt.Data.ForEach(x => result.Data.Add(Mapper.Map<{0}, {1}>(x)));", dtoName, viewModel));
            }
            builder.AppendLine("        \t\t\t}");
            builder.AppendLine("        \t\t}");
            builder.AppendLine("        \t}");
            builder.AppendLine("        \tcatch (Exception e)");
            builder.AppendLine("        \t{");
            builder.AppendLine("        \t\tLogHelper.Error(e);");
            builder.AppendLine("        \t\tresult.IsSuccess = false;");
            builder.AppendLine("        \t\tresult.Message = \"call service error\";");
            builder.AppendLine("        \t}");
            builder.AppendLine("");
            builder.AppendLine("        \treturn result;");
            builder.AppendLine("        }");
            builder.AppendLine();

            builder.AppendLine("        public ReturnInfo Delete" + this.Model.Name + "(Guid id)");
            builder.AppendLine("        {");
            builder.AppendLine("        \tvar result = new ReturnInfo();");
            builder.AppendLine();
            builder.AppendLine("        \ttry");
            builder.AppendLine("        \t{");
            builder.AppendLine(string.Format("        \t\tvar rslt = serviceClient.Invoke<ReturnInfoDto>(x => x.Delete{0}(id));", entityName));
            builder.AppendLine("        \t\tresult.IsSuccess = rslt.IsSuccess;");
            builder.AppendLine("        \t\tresult.Message = rslt.Message;");
            builder.AppendLine("        \t\t");
            builder.AppendLine("        \t}");
            builder.AppendLine("        \tcatch (Exception e)");
            builder.AppendLine("        \t{");
            builder.AppendLine("        \t\tLogHelper.Error(e);");
            builder.AppendLine("        \t\tresult.IsSuccess = false;");
            builder.AppendLine("        \t\tresult.Message = \"call service error\";");
            builder.AppendLine("        \t}");
            builder.AppendLine("");
            builder.AppendLine("        \treturn result;");
            builder.AppendLine("        }");
            builder.AppendLine();


            builder.AppendLine("        public ReturnInfo Delete" + this.Model.Name + "(List<Guid> id_list)");
            builder.AppendLine("        {");
            builder.AppendLine("        \tvar result = new ReturnInfo();");
            builder.AppendLine();
            builder.AppendLine("        \ttry");
            builder.AppendLine("        \t{");
            builder.AppendLine(string.Format("        \t\tvar rslt = serviceClient.Invoke<ReturnInfoDto>(x => x.Delete{0}List(id_list));", entityName));
            builder.AppendLine("        \t\tresult.IsSuccess = rslt.IsSuccess;");
            builder.AppendLine("        \t\tresult.Message = rslt.Message;");
            builder.AppendLine("        \t\t");
            builder.AppendLine("        \t}");
            builder.AppendLine("        \tcatch (Exception e)");
            builder.AppendLine("        \t{");
            builder.AppendLine("        \t\tLogHelper.Error(e);");
            builder.AppendLine("        \t\tresult.IsSuccess = false;");
            builder.AppendLine("        \t\tresult.Message = \"call service error\";");
            builder.AppendLine("        \t}");
            builder.AppendLine("");
            builder.AppendLine("        \treturn result;");
            builder.AppendLine("        }");
            builder.AppendLine();
            builder.AppendLine("        #endregion");
            builder.AppendLine();
            #endregion

            base.Generate(builder);
        }
    }
}

