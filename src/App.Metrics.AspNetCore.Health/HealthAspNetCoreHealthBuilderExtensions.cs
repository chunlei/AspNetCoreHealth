﻿// <copyright file="HealthAspNetCoreHealthBuilderExtensions.cs" company="Allan Hardy">
// Copyright (c) Allan Hardy. All rights reserved.
// </copyright>

using System;
using App.Metrics.AspNetCore.Health.Core;
using App.Metrics.AspNetCore.Health.Core.Internal;
using Microsoft.Extensions.Configuration;

// ReSharper disable CheckNamespace
namespace Microsoft.Extensions.DependencyInjection
    // ReSharper restore CheckNamespace
{
    /// <summary>
    ///     Extension methods for setting up App Metrics AspNet Core health services in an <see cref="IServiceCollection" />.
    /// </summary>
    public static class HealthAspNetCoreHealthBuilderExtensions
    {
        /// <summary>
        ///     Adds essential App Metrics AspNet Core health services to the specified <see cref="IHealthBuilder" />.
        /// </summary>
        /// <param name="builder">The <see cref="IHealthBuilder" /> to add services to.</param>
        /// <returns>An <see cref="IHealthAspNetCoreBuilder"/> that can be used to further configure the App Metrics AspNet Core health services.</returns>
        public static IHealthAspNetCoreBuilder AddAspNetCoreHealth(this IHealthBuilder builder)
        {
            builder.Services.AddAspNetCoreHealthCore();

            return new HealthAspNetCoreBuilder(builder.Services);
        }

        /// <summary>
        ///     Adds essential App Metrics AspNet Core health services to the specified <see cref="IHealthBuilder" />.
        /// </summary>
        /// <param name="builder">The <see cref="IHealthBuilder" /> to add services to.</param>
        /// <param name="configuration">The <see cref="IConfiguration" /> from where to load <see cref="HealthEndpointOptions" />.</param>
        /// <returns>An <see cref="IHealthAspNetCoreBuilder"/> that can be used to further configure the App Metrics AspNet Core health services.</returns>
        public static IHealthAspNetCoreBuilder AddAspNetCoreHealth(
            this IHealthBuilder builder,
            IConfiguration configuration)
        {
            var aspNetCoreBuilder = builder.AddAspNetCoreHealth();

            builder.Services.Configure<HealthEndpointOptions>(configuration);

            return aspNetCoreBuilder;
        }

        /// <summary>
        ///     Adds essential App Metrics AspNet Core health services to the specified <see cref="IHealthBuilder" />.
        /// </summary>
        /// <param name="builder">The <see cref="IHealthBuilder" /> to add services to.</param>
        /// <param name="configuration">The <see cref="IConfiguration" /> from where to load <see cref="HealthEndpointOptions" />.</param>
        /// <param name="setupAction">
        ///     An <see cref="Action{EndpointOptions}" /> to configure the provided <see cref="HealthEndpointOptions" />.
        /// </param>
        /// <returns>An <see cref="IHealthAspNetCoreBuilder"/> that can be used to further configure the App Metrics AspNet Core health services.</returns>
        public static IHealthAspNetCoreBuilder AddAspNetCoreHealth(
            this IHealthBuilder builder,
            IConfiguration configuration,
            Action<HealthEndpointOptions> setupAction)
        {
            var aspNetCoreBuilder = builder.AddAspNetCoreHealth();

            builder.Services.Configure<HealthEndpointOptions>(configuration);
            builder.Services.Configure(setupAction);

            return aspNetCoreBuilder;
        }

        /// <summary>
        ///     Adds essential App Metrics AspNet Core health services to the specified <see cref="IHealthBuilder" />.
        /// </summary>
        /// <param name="builder">The <see cref="IHealthBuilder" /> to add services to.</param>
        /// <param name="setupAction">
        ///     An <see cref="Action{EndpointOptions}" /> to configure the provided <see cref="HealthEndpointOptions" />.
        /// </param>
        /// <param name="configuration">The <see cref="IConfiguration" /> from where to load <see cref="HealthEndpointOptions" />.</param>
        /// <returns>An <see cref="IHealthAspNetCoreBuilder"/> that can be used to further configure the App Metrics AspNet Core health services.</returns>
        public static IHealthAspNetCoreBuilder AddAspNetCoreHealth(
            this IHealthBuilder builder,
            Action<HealthEndpointOptions> setupAction,
            IConfiguration configuration)
        {
            var aspNetCoreBuilder = builder.AddAspNetCoreHealth();

            builder.Services.Configure(setupAction);
            builder.Services.Configure<HealthEndpointOptions>(configuration);

            return aspNetCoreBuilder;
        }

        /// <summary>
        ///     Adds essential App Metrics AspNet Core health services to the specified <see cref="IHealthBuilder" />.
        /// </summary>
        /// <param name="builder">The <see cref="IHealthBuilder" /> to add services to.</param>
        /// <param name="setupAction">
        ///     An <see cref="Action{EndpointOptions}" /> to configure the provided <see cref="HealthEndpointOptions" />.
        /// </param>
        /// <returns>An <see cref="IHealthAspNetCoreBuilder"/> that can be used to further configure the App Metrics AspNet Core health services.</returns>
        public static IHealthAspNetCoreBuilder AddAspNetCoreHealth(
            this IHealthBuilder builder,
            Action<HealthEndpointOptions> setupAction)
        {
            var aspNetCoreBuilder = builder.AddAspNetCoreHealth();

            builder.Services.Configure(setupAction);

            return aspNetCoreBuilder;
        }
    }
}