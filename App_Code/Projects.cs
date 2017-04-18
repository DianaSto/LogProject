using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;


/// <summary>
/// se returneaza lista de proiecte existente in baza de date
/// </summary>
public class Projects
{
    public Projects()
    {

    }

    public List<Project> GetProjects(int startIndex, int maxRows)
    {
        PontajeEntities entities = new PontajeEntities();
         
        var result= (from project in entities.Projects select project).OrderBy(customer => customer.id)
                        .Skip(startIndex)
                        .Take(maxRows).ToList(); 

        return result;
    }

    public int GetProjectsCount()
    {
        using (PontajeEntities entities = new PontajeEntities())
        {
            return entities.Projects.Count();
        }
    }


}