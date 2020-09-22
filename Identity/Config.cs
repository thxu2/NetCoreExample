// Copyright (c) Brock Allen & Dominick Baier. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.


using System.Collections.Generic;
using IdentityServer4.Models;

namespace Project
{
    public static class Config
    {
        public static IEnumerable<IdentityResource> IdentityResources =>
            new IdentityResource[]
            {
                new IdentityResources.OpenId(),
                new IdentityResources.Profile()
            };

        public static IEnumerable<ApiScope> ApiScopes =>
            new[]
            {
                new ApiScope("sampleapi")
            };


        public static IEnumerable<ApiResource> ApiResources =>
            new[]
            {
                new ApiResource
                {
                    Name = "sampleapi",
                    Scopes =
                    {
                        "sampleapi"
                    }
                }
            };

        public static IEnumerable<Client> Clients =>
            new[]
            {
                new Client
                {
                    ClientId = "blazor",
                    AllowedGrantTypes = GrantTypes.Code,
                    RequirePkce = true,
                    RequireClientSecret = false,
                    AllowedCorsOrigins = {"http://localhost:5001"},
                    AllowedScopes = {"openid", "profile", "sampleapi"},
                    RedirectUris = {"http://localhost:5001/authentication/login-callback"},
                    PostLogoutRedirectUris = {"http://localhost:5001/"},
                    Enabled = true
                }
            };
    }
}