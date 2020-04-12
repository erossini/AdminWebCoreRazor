using IdentityServer4;
using IdentityServer4.Models;
using IdentityServer4.Test;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace AdminWebCore.Configurations.IdentityServer
{
    /// <summary>
    /// Class InMemoryConfig.
    /// </summary>
    public static class InMemoryConfig
    {
        /// <summary>
        /// Gets the identity resources for IdentityServer4
        /// </summary>
        /// <returns>IEnumerable&lt;IdentityResource&gt;.</returns>
        public static IEnumerable<IdentityResource> GetIdentityResources() => new List<IdentityResource> {
            new IdentityResources.OpenId(),
            new IdentityResources.Profile()
        };

        /// <summary>
        /// Gets the users.
        /// </summary>
        /// <returns>List&lt;TestUser&gt;.</returns>
        public static List<TestUser> GetUsers() => new List<TestUser> {
            new TestUser {
                SubjectId = "a9ea0f25-b964-409f-bcce-c923266249b4",
                Username = "Enrico",
                Password = "Password",
                Claims = new List<Claim> {
                    new Claim("given_name", "Enrico"),
                    new Claim("family_name", "Rossini")
                }
            }
        };

        /// <summary>
        /// Gets the clients.
        /// </summary>
        /// <returns>IEnumerable&lt;Client&gt;.</returns>
        public static IEnumerable<Client> GetClients() => new List<Client> {
            new Client {
                ClientId = "AdminWebCore",
                ClientSecrets = new [] { new Secret("AdminWebCoreSecret".Sha512()) },
                AllowedGrantTypes = GrantTypes.ResourceOwnerPasswordAndClientCredentials,
                AllowedScopes = { IdentityServerConstants.StandardScopes.OpenId }
            }
        };
    }
}