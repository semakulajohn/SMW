﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace SMW.EF.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    using SMW.EF.Context;
    
    public partial class SMWEntities : DbContext,IDbContext
    {
        public SMWEntities()
            : base("name=SMWEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<AspNetRole> AspNetRoles { get; set; }
        public virtual DbSet<AspNetUserClaim> AspNetUserClaims { get; set; }
        public virtual DbSet<AspNetUserLogin> AspNetUserLogins { get; set; }
        public virtual DbSet<AspNetUser> AspNetUsers { get; set; }
        public virtual DbSet<Comment> Comments { get; set; }
        public virtual DbSet<ExtensionType> ExtensionTypes { get; set; }
        public virtual DbSet<MediaType> MediaTypes { get; set; }
        public virtual DbSet<Project> Projects { get; set; }
        public virtual DbSet<WebQuery> WebQueries { get; set; }
        public virtual DbSet<Property> Properties { get; set; }
        public virtual DbSet<Media> Media { get; set; }
    
        public virtual ObjectResult<Media_GetDescendants_Result> Media_GetDescendants(Nullable<long> mediaId)
        {
            var mediaIdParameter = mediaId.HasValue ?
                new ObjectParameter("MediaId", mediaId) :
                new ObjectParameter("MediaId", typeof(long));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Media_GetDescendants_Result>("Media_GetDescendants", mediaIdParameter);
        }
    
        public virtual ObjectResult<string> Media_GetPath(Nullable<long> mediaId)
        {
            var mediaIdParameter = mediaId.HasValue ?
                new ObjectParameter("MediaId", mediaId) :
                new ObjectParameter("MediaId", typeof(long));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<string>("Media_GetPath", mediaIdParameter);
        }
    
        public virtual ObjectResult<string> Media_GetPathCsvMediaId(Nullable<long> mediaId)
        {
            var mediaIdParameter = mediaId.HasValue ?
                new ObjectParameter("MediaId", mediaId) :
                new ObjectParameter("MediaId", typeof(long));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<string>("Media_GetPathCsvMediaId", mediaIdParameter);
        }
    
        public virtual int Media_SetPath(Nullable<long> mediaId)
        {
            var mediaIdParameter = mediaId.HasValue ?
                new ObjectParameter("MediaId", mediaId) :
                new ObjectParameter("MediaId", typeof(long));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("Media_SetPath", mediaIdParameter);
        }
    }
}