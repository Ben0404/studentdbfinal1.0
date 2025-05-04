using studentdb.Models.Repositories;
using studentdb;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using studentdbfinal1._0;
using System;

public class StudentRepository : Istudentrepository
{
    private Model1 db;

    public StudentRepository()
    {
        this.db = new Model1();
    }

    public StudentRepository(Model1 db)
    {
        this.db = db;
    }

    public IEnumerable<Studentquery1> SelectAll()
    {
        try
        {
            return db.Studentquery1.OrderBy(s => s.Surname).ToList();
        }
        catch (Exception ex)
        {
            System.Diagnostics.Debug.WriteLine("Error in SelectAll: " + ex.Message);
            throw;
        }
    }

    public Studentquery1 SelectByID(int id)
    {
        try
        {
            return db.Studentquery1.Find(id);
        }
        catch (Exception ex)
        {
            System.Diagnostics.Debug.WriteLine("Error in SelectByID: " + ex.Message);
            throw;
        }
    }

    public void Insert(Studentquery1 obj)
    {
        try
        {
            if (obj == null)
            {
                throw new ArgumentNullException("obj", "The student object cannot be null");
            }

            if (string.IsNullOrEmpty(obj.FirstName) || string.IsNullOrEmpty(obj.Surname))
            {
                throw new ArgumentException("First Name and Surname are required.");
            }

            db.Studentquery1.Add(obj);
        }
        catch (Exception ex)
        {
            System.Diagnostics.Debug.WriteLine("Error in Insert: " + ex.Message);
            throw;
        }
    }

    public void Update(Studentquery1 obj)
    {
        try
        {
            db.Entry(obj).State = EntityState.Modified;
        }
        catch (Exception ex)
        {
            System.Diagnostics.Debug.WriteLine("Error in Update: " + ex.Message);
            throw;
        }
    }

    public void Delete(int id)
    {
        try
        {
            Studentquery1 existing = db.Studentquery1.Find(id);
            if (existing != null)
            {
                db.Studentquery1.Remove(existing);
            }
        }
        catch (Exception ex)
        {
            System.Diagnostics.Debug.WriteLine("Error in Delete: " + ex.Message);
            throw;
        }
    }

    public void Save()
    {
        try
        {
            db.SaveChanges();
        }
        catch (Exception ex)
        {
            System.Diagnostics.Debug.WriteLine("Error in Save: " + ex.Message);
            throw;
        }
    }
}
