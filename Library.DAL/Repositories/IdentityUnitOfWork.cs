﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library.DAL;
using Library.Entities.Entities;
using Library.DAL.Identity;
using Library.DAL.Interfaces;

namespace Library.DAL.Repositories
{
    public class IdentityUnitOfWork /*: IUnitOfWork*/
    {
        //    private ApplicationContext db;

        //    private ApplicationUserManager userManager;

        //    private ApplicationRoleManager roleManager;

        //    private IClientManager clientManager;

        //    public IdentityUnitOfWork(string connectionString)
        //    {
        //        db = new ApplicationContext(connectionString);
        //        userManager = new ApplicationUserManager(new UserStore<ApplicationUser>(db));

        //        roleManager = new ApplicationRoleManager(new RoleStore<ApplicationRole>(db));
        //        clientManager = new ClientManager(db);
        //    }

        //    public ApplicationUserManager UserManager
        //    {
        //        get { return userManager; }
        //    }

        //    public IClientManager ClientManager
        //    {
        //        get { return clientManager; }
        //    }

        //    public ApplicationRoleManager RoleManager
        //    {
        //        get { return roleManager; }
        //    }

        //    public async Task SaveAsync()
        //    {
        //        await db.SaveChangesAsync();
        //    }

        //    public void Dispose()
        //    {
        //        Dispose(true);
        //        GC.SuppressFinalize(this);
        //    }
        //    private bool disposed = false;

        //    public virtual void Dispose(bool disposing)
        //    {
        //        if (!this.disposed)
        //        {
        //            if (disposing)
        //            {
        //                userManager.Dispose();
        //                roleManager.Dispose();
        //                clientManager.Dispose();
        //            }
        //            this.disposed = true;
        //        }
        //    }
        //}
    }
}
