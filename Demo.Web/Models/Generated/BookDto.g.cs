using IntelliTect.Coalesce;
using IntelliTect.Coalesce.Mapping;
using IntelliTect.Coalesce.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;

namespace Demo.Web.Models
{
    public partial class BookDtoGen : GeneratedDto<Demo.Data.Models.Book>
    {
        public BookDtoGen() { }

        private int? _BookId;
        private string _Title;
        private string _Description;
        private System.DateTime? _PublishDate;
        private int? _AuthorId;
        private Demo.Web.Models.AuthorDtoGen _Author;

        public int? BookId
        {
            get => _BookId;
            set { _BookId = value; Changed(nameof(BookId)); }
        }
        public string Title
        {
            get => _Title;
            set { _Title = value; Changed(nameof(Title)); }
        }
        public string Description
        {
            get => _Description;
            set { _Description = value; Changed(nameof(Description)); }
        }
        public System.DateTime? PublishDate
        {
            get => _PublishDate;
            set { _PublishDate = value; Changed(nameof(PublishDate)); }
        }
        public int? AuthorId
        {
            get => _AuthorId;
            set { _AuthorId = value; Changed(nameof(AuthorId)); }
        }
        public Demo.Web.Models.AuthorDtoGen Author
        {
            get => _Author;
            set { _Author = value; Changed(nameof(Author)); }
        }

        /// <summary>
        /// Map from the domain object to the properties of the current DTO instance.
        /// </summary>
        public override void MapFrom(Demo.Data.Models.Book obj, IMappingContext context, IncludeTree tree = null)
        {
            if (obj == null) return;
            var includes = context.Includes;

            this.BookId = obj.BookId;
            this.Title = obj.Title;
            this.Description = obj.Description;
            this.PublishDate = obj.PublishDate;
            this.AuthorId = obj.AuthorId;
            if (tree == null || tree[nameof(this.Author)] != null)
                this.Author = obj.Author.MapToDto<Demo.Data.Models.Author, AuthorDtoGen>(context, tree?[nameof(this.Author)]);

        }

        /// <summary>
        /// Map from the current DTO instance to the domain object.
        /// </summary>
        public override void MapTo(Demo.Data.Models.Book entity, IMappingContext context)
        {
            var includes = context.Includes;

            if (OnUpdate(entity, context)) return;

            if (ShouldMapTo(nameof(BookId))) entity.BookId = (BookId ?? entity.BookId);
            if (ShouldMapTo(nameof(Title))) entity.Title = Title;
            if (ShouldMapTo(nameof(Description))) entity.Description = Description;
            if (ShouldMapTo(nameof(PublishDate))) entity.PublishDate = PublishDate;
            if (ShouldMapTo(nameof(AuthorId))) entity.AuthorId = (AuthorId ?? entity.AuthorId);
        }

        /// <summary>
        /// Map from the current DTO instance to a new instance of the domain object.
        /// </summary>
        public override Demo.Data.Models.Book MapToNew(IMappingContext context)
        {
            var includes = context.Includes;

            var entity = new Demo.Data.Models.Book()
            {
                Title = Title,
            };

            if (OnUpdate(entity, context)) return entity;
            if (ShouldMapTo(nameof(BookId))) entity.BookId = (BookId ?? entity.BookId);
            if (ShouldMapTo(nameof(Description))) entity.Description = Description;
            if (ShouldMapTo(nameof(PublishDate))) entity.PublishDate = PublishDate;
            if (ShouldMapTo(nameof(AuthorId))) entity.AuthorId = (AuthorId ?? entity.AuthorId);

            return entity;
        }
    }
}
