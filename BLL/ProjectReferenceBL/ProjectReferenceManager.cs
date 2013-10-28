using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Context;
using DAL.Entities;

namespace BLL.ProjectReferenceBL
{
    public class ProjectReferenceManager
    {
        public static List<ProjectReferences> GetProjectReferenceList(string language)
        {
            using (DeneysanContext db = new DeneysanContext())
            {
                var list = db.ProjectReferences.Where(d =>  d.Language == language).OrderBy(d=>d.SortOrder).ToList();
                return list;
            }
        }

        public static List<ProjectReferences> GetProjectReferenceListForFront(string language)
        {
            using (DeneysanContext db = new DeneysanContext())
            {
                var list = db.ProjectReferences.Where(d => d.Language == language && d.Online==true).OrderBy(d => d.SortOrder).ToList();
                return list;
            }
        }

        public static bool AddProjectReference(ProjectReferences record)
        {
            using (DeneysanContext db = new DeneysanContext())
            {
                try
                {
                    record.TimeCreated = DateTime.Now;
                    record.SortOrder = 9999;
                    record.Online = true;
                    db.ProjectReferences.Add(record);
                    db.SaveChanges();

                    return true;
                }
                catch (Exception ex)
                {
                    return false;
                }
            }

        }


        public static bool UpdateStatus(int id)
        {
            using (DeneysanContext db = new DeneysanContext())
            {
                var list = db.ProjectReferences.SingleOrDefault(d => d.ProjectReferenceId == id);
                try
                {

                    if (list != null)
                    {
                        list.Online = list.Online == true ? false : true;
                        db.SaveChanges();

                    }
                    return list.Online;

                }
                catch (Exception)
                {
                    return list.Online;
                }
            }
        }


        public static bool Delete(int id)
        {
            using (DeneysanContext db = new DeneysanContext())
            {
                try
                {
                    var record = db.ProjectReferences.FirstOrDefault(d => d.ProjectReferenceId == id);
                    db.ProjectReferences.Remove(record);
                    db.SaveChanges();
                    return true;
                }
                catch (Exception)
                {
                    return false;
                }
            }
        }

        public static ProjectReferences GetProjectReferenceById(int nid)
        {
            using (DeneysanContext db = new DeneysanContext())
            {
                try
                {
                    ProjectReferences record = db.ProjectReferences.Where(d => d.ProjectReferenceId == nid).SingleOrDefault();
                    if (record != null)
                        return record;
                    else
                        return null;
                }
                catch (Exception ex)
                {
                    return null;
                }
            }
        }

        public static bool EditProjectReference(ProjectReferences ProjectReferencemodel)
        {
            using (DeneysanContext db = new DeneysanContext())
            {
                try
                {
                    ProjectReferences record = db.ProjectReferences.Where(d => d.ProjectReferenceId == ProjectReferencemodel.ProjectReferenceId).SingleOrDefault();
                    if (record != null)
                    {
                        record.Content = ProjectReferencemodel.Content;
                        record.Name = ProjectReferencemodel.Name;
                        
                        record.Language = ProjectReferencemodel.Language;
                        if (!string.IsNullOrEmpty(ProjectReferencemodel.ProjectReferenceFile))
                        {
                            record.ProjectReferenceFile = ProjectReferencemodel.ProjectReferenceFile;
                        }
                        record.Content = ProjectReferencemodel.Content;
                        db.SaveChanges();

                       

                        return true;
                    }
                    else
                        return false;

                }
                catch (Exception ex)
                {
                    return false;
                }
            }
        }


        public static bool SortRecords(string[] idsList)
        {
            using (DeneysanContext db = new DeneysanContext())
            {
                try
                {

                    int row = 0;
                    foreach (string id in idsList)
                    {
                        int mid = Convert.ToInt32(id);
                        ProjectReferences sortingrecord = db.ProjectReferences.SingleOrDefault(d => d.ProjectReferenceId == mid);
                        sortingrecord.SortOrder = Convert.ToInt32(row);
                        db.SaveChanges();
                        row++;
                    }
                    return true;
                }
                catch (Exception)
                {
                    return false;
                }
            }
        }
    }
}
