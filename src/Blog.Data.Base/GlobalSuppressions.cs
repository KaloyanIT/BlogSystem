// This file is used by Code Analysis to maintain SuppressMessage
// attributes that are applied to this project.
// Project-level suppressions either have no target or are given
// a specific target and scoped to a namespace, type, member, etc.

using System.Diagnostics.CodeAnalysis;

[assembly: SuppressMessage("Build", "CA1062:In externally visible method 'void ModuleBuilderExtensions.AddConfiguration<TEntity>(ModelBuilder modelBuilder, IEntityTypeConfiguration<TEntity> configuration)', validate parameter 'modelBuilder' is non-null before using it. If appropriate, throw an ArgumentNullException when the argument is null or add a Code Contract precondition asserting non-null argument.", Justification = "<Pending>", Scope = "member", Target = "~M:Blog.Data.Base.Extensions.ModuleBuilderExtensions.AddConfiguration``1(Microsoft.EntityFrameworkCore.ModelBuilder,Microsoft.EntityFrameworkCore.IEntityTypeConfiguration{``0})")]
[assembly: SuppressMessage("Build", "CA1307:The behavior of 'string.Contains(string)' could vary based on the current user's locale settings. Replace this call in 'Blog.Data.Base.Extensions.ModuleBuilderExtensions.ApplyDbConfiguration(Microsoft.EntityFrameworkCore.ModelBuilder)' with a call to 'string.Contains(string, System.StringComparison)'.", Justification = "<Pending>", Scope = "member", Target = "~M:Blog.Data.Base.Extensions.ModuleBuilderExtensions.ApplyDbConfiguration(Microsoft.EntityFrameworkCore.ModelBuilder)")]
[assembly: SuppressMessage("Build", "CA1040:Avoid empty interfaces", Justification = "<Pending>", Scope = "type", Target = "~T:Blog.Data.Base.ITransientRepository")]
