using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Clinique2000.Data
{
    static public class SeedData
    {
        static public PasswordHasher<IdentityUser> Pass { get; set; } = new PasswordHasher<IdentityUser>();

        static public void AjouterUsager(IServiceProvider serviceProvider)
        {
            using (var Context = new ApplicationDbContext(
                serviceProvider.GetRequiredService<DbContextOptions<ApplicationDbContext>>()))
            {
                IdentityUser[] usagersClinique2000 =
             {
                new IdentityUser()
                {
                    Email = "bugs@bunny.com",
                    UserName = "bugs@bunny.com", //"Bugs Bunny",
                    PasswordHash = "Qwerty123!"
                },
                new IdentityUser()
                {
                    Email = "Bob@leponge.com",
                    UserName = "Bob@leponge.com", // "Bob L'éponge",
                    PasswordHash = "Qwerty123!"
                },
                new IdentityUser()
                {
                    Email = "Bob@builder.com",
                    UserName = "Bob@builder.com", //"Bob Thebuilder",
                    PasswordHash = "Qwerty123!"
                    
                },

            };
                foreach (IdentityUser u in usagersClinique2000)
                {
                    u.NormalizedEmail = u.Email.ToUpper();
                    u.NormalizedUserName = u.UserName.ToUpper();
                    u.SecurityStamp = Guid.NewGuid().ToString();
                    u.LockoutEnabled = true;
                    u.EmailConfirmed = true;
                    u.PasswordHash = Pass.HashPassword(u, u.PasswordHash);
                }

                foreach (IdentityUser u in usagersClinique2000)
                {

                    if (Context.Users.FirstOrDefault(u1 => u1.Email == u.Email) == null)
                        Context.Users.Add(u);
                }
                Context.SaveChanges();
            }


        }

        static public void AjouterRoles(IServiceProvider serviceProvider)
        {
            using (var Context = new ApplicationDbContext(
               serviceProvider.GetRequiredService<DbContextOptions<ApplicationDbContext>>()))
            {
                IdentityRole[] rolesClinique2000 =
            {
                new IdentityRole()
                {
                    Name = "Administrateur"
                },
                new IdentityRole()
                {
                    Name = "Medecin"
                },
                new IdentityRole()
                {
                    Name = "Patient"
                }

            };


                foreach (IdentityRole i in rolesClinique2000)
                    i.NormalizedName = i.Name.ToUpper();

                foreach (IdentityRole i in rolesClinique2000)
                {
                    if (Context.Roles.FirstOrDefault(i1 => i1.Name == i.Name) == null)
                        Context.Roles.Add(i);
                }
                Context.SaveChanges();
            }
        }

        static public void AssociationUsagerRoles(IServiceProvider serviceProvider)
        {
            using (var Context = new ApplicationDbContext(
               serviceProvider.GetRequiredService<DbContextOptions<ApplicationDbContext>>()))
            {
                IdentityUserRole<string>[] usagersRolesClinique2000 =
             {
                new IdentityUserRole<string>()
                {
                    UserId = Context.Users.Single(u => u.Email == "bugs@bunny.com").Id,
                    RoleId = Context.Roles.Single(r => r.Name == "Administrateur").Id
                },
                new IdentityUserRole<string>()
                {
                    UserId = Context.Users.Single(u => u.Email == "Bob@builder.com").Id,
                    RoleId = Context.Roles.Single(r => r.Name == "Medecin").Id
                },
                new IdentityUserRole<string>()
                {
                    UserId = Context.Users.Single(u => u.Email == "Bob@leponge.com").Id,
                    RoleId = Context.Roles.Single(r => r.Name == "Patient").Id
                }
            };
                if (!Context.UserRoles.Any())
                {
                    Context.UserRoles.AddRange(usagersRolesClinique2000);
                    Context.SaveChanges();
                }
            }
        }
    }
}
