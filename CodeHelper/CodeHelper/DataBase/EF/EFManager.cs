using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CodeHelper.DataBaseHelper.EF
{
    public class EFManager
    {
        private EFManager()
        {
        }

        private static EFManager _instance = new EFManager();

        public static EFManager Instance()
        {
            return _instance;
        }

        private Dictionary<string, EntityRelation> relations = new Dictionary<string, EntityRelation>();

        public void Reset()
        {
            Dictionary<string, EntityRelation> relations = new Dictionary<string, EntityRelation>();
            //relations.TableName = this.Model
            //var tableName =  this.tableNode.Name;
            if (DBGlobalService.EFStorageModels != null && DBGlobalService.EFConceptualModels != null &&
                DBGlobalService.EFMappings != null)
            {
                foreach (var set in DBGlobalService.EFStorageModels.EntityContainer.AssociationSets)
                {
                    if (!DBGlobalService.EFStorageModels.Associations.ContainsKey(set.Key))
                        continue;

                    var ass = DBGlobalService.EFStorageModels.Associations[set.Key];

                    foreach (var end in set.Value.Ends)
                    {

                        if (!relations.ContainsKey(end.Value.EntitySetId))
                        {
                            relations.Add(end.Value.EntitySetId, new EntityRelation());
                        }


                        var r = relations[end.Value.EntitySetId];
                        r.Associations.Add(ass);
                        r.AssociationSets.Add(set.Value);
                        r.TableName = end.Value.EntitySetId;

                    }
                }

                var tables = DBGlobalService.CurrentProject.GetTables();

                foreach (var r in relations.Values)
                {
                    for(int index = 0 ; index < r.AssociationSets.Count ; index ++ )
                    {
                        var fk = new EntityRelation.FKRelation();
                        var set = r.AssociationSets[index];
                        var ass = r.Associations[index];
                        foreach (var end in set.Ends)
                        {
                            if (end.Key == ass.ReferentialConstraint.Principal.Role)
                            {
                                fk.FromTableType = tables[end.Value.EntitySetId];
                                var end1 = ass.Ends[end.Key];
                                fk.FromMulitplicity = end1.Multiplicity;
                                fk.FromColumn = ass.ReferentialConstraint.Principal.PropertyRef.Name;
                            }
                            else
                            {
                                fk.ToTableType = tables[end.Value.EntitySetId];
                                var end1 = ass.Ends[end.Key];
                                fk.ToMulitplicity = end1.Multiplicity;
                                fk.ToColumn = ass.ReferentialConstraint.Dependent.PropertyRef.Name;
                            }

                        }
                        r.FKRelations.Add(fk);
                
                        
                        //foreach (var end1 in set.Ends)
                        //{
                        //    foreach (var end2 in ass.Ends)
                        //    {
                        //        if (end1.Key == end2.Key)
                        //        {
                                    
                        //            foreach(var m in models)
                        //            {

                        //            }
                        //            fk.FromTableType = models.
                        //        }
                        //    }
                        //}

                        //foreach(
                        //fk.FromColumn = r.Associations[index].Ends
                        //r.FKRelations.a
                    }
                }

                //foreach(var ass in GlobalService.EFStorageModels.Associations)
                //{
                //    foreach (var relation in relations.Values)
                //    {
                //        foreach (var set in relation.AssociationSets)
                //        {
                //            if (set.Association == ass.Key) {

                //                var fkR = new EntityRelation.FKRelation() ;
                //                foreach(var end in ass.Value.Ends)
                //                {
                //                    if (end.Value.Role == set.Ends
                //                }

                //            }
                //        }
                //    }
                //    foreach(var end in ass.Value.Ends)
                //    {

                //    }
                //}



                foreach (var table_name in relations.Keys)
                {
                    foreach (var relation in relations[table_name].FKRelations)
                    {
                        //relation.FromColumn
                    }
                }

                //foreach (var type in GlobalService.EFConceptualModels.EntityTypes)
                //{
                //    if (type.Key == this.Model.Name.Value)
                //    {
                //        foreach (var nav in type.Value.NavigationPropertys)
                //        {

                //        }
                //    }
                //}

                foreach (var maps in DBGlobalService.EFMappings.EntityContainerMapping.AssociationSetMappings)
                {
                    //foreach (var map in maps)
                    //{

                    //}
                }



            
                }
            }

        //private ModelType GetModel(string tableName)
        //{

        //}

        public EntityRelation Get(string tableName)
        {
            if (relations.ContainsKey(tableName))
                return relations[tableName];

            return null;
        }
    }
}
