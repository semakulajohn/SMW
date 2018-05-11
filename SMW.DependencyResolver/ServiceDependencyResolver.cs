using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ninject.Modules;
using SMW.BAL.Interface;
using SMW.BAL.Concrete;
using SMW.DAL.Interface;
using SMW.DAL.Concrete;

namespace SMW.DependencyResolver
{
 public   class ServiceDependencyResolver : NinjectModule
    {
     public override void Load()
     {
         //BAL
         Bind(typeof(IUserService)).To(typeof(UserService));
         Bind(typeof(IPropertyService)).To(typeof(PropertyService));
         Bind(typeof(IProjectService)).To(typeof(ProjectService));
         Bind(typeof(ICommentService)).To(typeof(CommentService));
         Bind(typeof(IMediaService)).To(typeof(MediaService));



         //DAL
         Bind(typeof(IUserDataService)).To(typeof(UserDataService));
         Bind(typeof(IPropertyDataService)).To(typeof(PropertyDataService));
         Bind(typeof(IProjectDataService)).To(typeof(ProjectDataService));
         Bind(typeof(ICommentDataService)).To(typeof(CommentDataService));
         Bind(typeof(IMediaDataService)).To(typeof(MediaDataService));
     }   
    }
}
