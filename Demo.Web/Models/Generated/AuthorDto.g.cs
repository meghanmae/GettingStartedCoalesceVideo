using IntelliTect.Coalesce;
using IntelliTect.Coalesce.Mapping;
using IntelliTect.Coalesce.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;

namespace Demo.Web.Models
{
    public partial class AuthorDtoGen : GeneratedDto<Demo.Data.Models.Author>
    {
        public AuthorDtoGen() { }

        private int? _AuthorId;
        private string _Name;
        private System.Collections.Generic.ICollection<Demo.Web.Models.BookDtoGen> _Books;

        public int? AuthorId
        {
            get => _AuthorId;
            set { _AuthorId = value; Changed(nameof(AuthorId)); }
        }
        public string Name
        {
            get => _Name;
            set { _Name = value; Changed(nameof(Name)); }
        }
        public System.Collections.Generic.ICollection<Demo.Web.Models.BookDtoGen> Books
        {
            get => _Books;
            set { _Books = value; Changed(nameof(Books)); }
        }

        /// <summary>
        /// Map from the domain object to the properties of the current DTO instance.
        /// </summary>
        public override void MapFrom(Demo.Data.Models.Author obj, IMappingContext context, IncludeTree tree = null)
        {
            if (obj == null) return;
            var includes = context.Includes;

            this.AuthorId = obj.AuthorId;
            this.Name = obj.Name;
            var propValBooks = obj.Books;
            if (propValBooks != null && (tree == null || tree[nameof(this.Books)] != null))
            {
                this.Books = propValBooks
                    .OrderBy(f => f.BookId)
                    .Select(f => f.MapToDto<Demo.Data.Models.Book, BookDtoGen>(context, tree?[nameof(this.Books)])).ToList();
            }
            else if (propValBooks == null && tree?[nameof(this.Books)] != null)
            {
                this.Books = new BookDtoGen[0];
            }

        }

        /// <summary>
        /// Map from the current DTO instance to the domain object.
        /// </summary>
        public override void MapTo(Demo.Data.Models.Author entity, IMappingContext context)
        {
            var includes = context.Includes;

            if (OnUpdate(entity, context)) return;

            if (ShouldMapTo(nameof(AuthorId))) entity.AuthorId = (AuthorId ?? entity.AuthorId);
            if (ShouldMapTo(nameof(Name))) entity.Name = Name;
        }

        /// <summary>
        /// Map from the current DTO instance to a new instance of the domain object.
        /// </summary>
        public override Demo.Data.Models.Author MapToNew(IMappingContext context)
        {
            var includes = context.Includes;

            var entity = new Demo.Data.Models.Author()
            {
                Name = Name,
            };

            if (OnUpdate(entity, context)) return entity;
            if (ShouldMapTo(nameof(AuthorId))) entity.AuthorId = (AuthorId ?? entity.AuthorId);

            return entity;
        }
    }
}
