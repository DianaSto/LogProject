using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

/// <summary>
/// Summary description for Users
/// </summary>
public class Users
{
    public Users()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    public List<User> GetUsers(int startIndex, int maxRows)
    {
        PontajeEntities entities = new PontajeEntities();

        var result = (from user in entities.Users select user).OrderBy(customer => customer.id)
                        .Skip(startIndex)
                        .Take(maxRows).ToList();

        return result;
    }

    public int GetUsersCount()
    {
        using (PontajeEntities entities = new PontajeEntities())
        {
            return entities.Users.Count();
        }
    }
}