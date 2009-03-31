using System;
using System.Collections.Generic;
using System.Linq;
using Fohjin.Core.Domain;
using Fohjin.Core.Persistence;
using FubuMVC.Core;

namespace Fohjin.Core.Web.Controllers
{
    public class TagController
    {
        private readonly IRepository _repository;

        public TagController(IRepository repository)
        {
            _repository = repository;
        }

        public TagViewModel Index(TagSetupViewModel inModel)
        {
            if (inModel.Tag.IsEmpty()) return new TagViewModel();

            var tag = _repository.Query<Tag>().Where(p => p.Name == inModel.Tag).FirstOrDefault(); // TODO: Currently tags are not unique 

            if (tag == null) return new TagViewModel();

            return new TagViewModel
            {
                Tag = tag
            };
        }
    }

    public class TagSetupViewModel : ViewModel
    {
        public string Tag { get; set; }
    }

    [Serializable]
    public class TagViewModel : ViewModel
    {
        public Tag Tag { get; set; }
        public IEnumerable<Post> Posts { get; set; }
    }
}