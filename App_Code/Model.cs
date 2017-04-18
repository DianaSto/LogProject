﻿//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Collections.Generic;

public partial class Pontaje
{
    public int id { get; set; }
    public int id_user { get; set; }
    public int id_project { get; set; }
    public Nullable<System.DateTime> start_time { get; set; }
    public Nullable<System.DateTime> finish_time { get; set; }

    public virtual Project Project { get; set; }
    public virtual User User { get; set; }
}

public partial class Project
{
    public Project()
    {
        this.Pontajes = new HashSet<Pontaje>();
    }

    public int id { get; set; }
    public string name { get; set; }
    public string description { get; set; }

    public virtual ICollection<Pontaje> Pontajes { get; set; }
}

public partial class Right
{
    public int id { get; set; }
    public string name { get; set; }
    public string description { get; set; }
}

public partial class Role
{
    public Role()
    {
        this.UsersToRoles = new HashSet<UsersToRole>();
    }

    public int id { get; set; }
    public string name { get; set; }
    public string description { get; set; }

    public virtual ICollection<UsersToRole> UsersToRoles { get; set; }
}

public partial class User
{
    public User()
    {
        this.UsersToRoles = new HashSet<UsersToRole>();
        this.Pontajes = new HashSet<Pontaje>();
    }

    public int id { get; set; }
    public string first_name { get; set; }
    public string last_name { get; set; }
    public string email { get; set; }
    public string username { get; set; }
    public string password { get; set; }

    public virtual ICollection<UsersToRole> UsersToRoles { get; set; }
    public virtual ICollection<Pontaje> Pontajes { get; set; }
}

public partial class UsersToRole
{
    public int id { get; set; }
    public int user_id { get; set; }
    public int role_id { get; set; }

    public virtual Role Role { get; set; }
    public virtual User User { get; set; }
}
