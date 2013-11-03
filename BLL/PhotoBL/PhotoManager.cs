﻿using DAL.Context;
using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.PhotoBL
{
    public class PhotoManager
    {
        public static bool Save(Photo p)
        {
            using (MainContext db = new MainContext())
            {
                try
                {
                    db.Photo.Add(p);
                    db.SaveChanges();
                    return true;
                }
                catch (Exception)
                {
                    return false;
                }
            }
        }

        public static List<Photo> GetList(int categoryID, int itemId)
        {
            using (MainContext db = new MainContext())
            {
                return db.Photo.Where(d => d.ItemId == itemId && d.CategoryId == categoryID).ToList();
            }
        }

        public static List<Photo> GetList(string lang, int categoryID)
        {
            using (MainContext db = new MainContext())
            {
                return db.Photo.Where(d => d.Language == lang && d.CategoryId == categoryID).ToList();
            }
        }

        public static List<Photo> GetList(int categoryID)
        {
            using (MainContext db = new MainContext())
            {
                return db.Photo.Where(d => d.CategoryId == categoryID).OrderBy(d=>d.SortOrder).ToList();
            }
        }

        public static bool Delete(int id)
        {
            using (MainContext db = new MainContext())
            {
                try
                {
                    Photo p = db.Photo.First(d => d.PhotoId == id);
                    db.Photo.Remove(p);
                    db.SaveChanges();
                    return true;
                }
                catch (Exception)
                {
                    return false;
                }
            }
        }

        public static bool Edit(int id, string Title, string path)
        {
            using (MainContext db = new MainContext())
            {
                try
                {
                    Photo p = db.Photo.First(d => d.PhotoId == id);
                    p.Title = Title;
                    p.Path = path;
                    db.SaveChanges();
                    return true;
                }
                catch (Exception)
                {
                    return false;
                }
            }
        }

        public static Photo GetById(int id)
        {
            using (MainContext db = new MainContext())
            {
                return db.Photo.First(d => d.PhotoId == id);
            }
        }

        public static bool UpdateStatus(int id)
        {
            using (MainContext db = new MainContext())
            {
                var list = db.Photo.SingleOrDefault(d => d.PhotoId == id);
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

        public static bool SortRecords(string[] idsList)
        {
            using (MainContext db = new MainContext())
            {
                try
                {
                    int row = 0;
                    foreach (string id in idsList)
                    {
                        int mid = Convert.ToInt32(id);
                        Photo sortingrecord = db.Photo.SingleOrDefault(d => d.PhotoId == mid);
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

        public static List<Photo> GetListForFront(string lang, int categoryID)
        {
            using (MainContext db = new MainContext())
            {
                return db.Photo.Where(d => d.Language == lang && d.CategoryId == categoryID && d.Online == true).ToList();
            }
        }
    }
}
