﻿using Microsoft.AspNetCore.Identity;
using System;

namespace TodoList.BlazorWasm.Domain.Entities
{
    public class AppRoles : IdentityRole<Guid>
    {
        public AppRoles() : base()
        {
        }

        public AppRoles(string roleName) : base(roleName)
        {
        }
    }
}
