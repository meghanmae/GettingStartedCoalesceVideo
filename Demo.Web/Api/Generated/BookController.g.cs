
using Demo.Web.Models;
using IntelliTect.Coalesce;
using IntelliTect.Coalesce.Api;
using IntelliTect.Coalesce.Api.Behaviors;
using IntelliTect.Coalesce.Api.Controllers;
using IntelliTect.Coalesce.Api.DataSources;
using IntelliTect.Coalesce.Mapping;
using IntelliTect.Coalesce.Mapping.IncludeTrees;
using IntelliTect.Coalesce.Models;
using IntelliTect.Coalesce.TypeDefinition;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace Demo.Web.Api
{
    [Route("api/Book")]
    [Authorize]
    [ServiceFilter(typeof(IApiActionFilter))]
    public partial class BookController
        : BaseApiController<Demo.Data.Models.Book, BookDtoGen, Demo.Data.AppDbContext>
    {
        public BookController(CrudContext<Demo.Data.AppDbContext> context) : base(context)
        {
            GeneratedForClassViewModel = context.ReflectionRepository.GetClassViewModel<Demo.Data.Models.Book>();
        }

        [HttpGet("get/{id}")]
        [AllowAnonymous]
        public virtual Task<ItemResult<BookDtoGen>> Get(
            int id,
            DataSourceParameters parameters,
            IDataSource<Demo.Data.Models.Book> dataSource)
            => GetImplementation(id, parameters, dataSource);

        [HttpGet("list")]
        [AllowAnonymous]
        public virtual Task<ListResult<BookDtoGen>> List(
            ListParameters parameters,
            IDataSource<Demo.Data.Models.Book> dataSource)
            => ListImplementation(parameters, dataSource);

        [HttpGet("count")]
        [AllowAnonymous]
        public virtual Task<ItemResult<int>> Count(
            FilterParameters parameters,
            IDataSource<Demo.Data.Models.Book> dataSource)
            => CountImplementation(parameters, dataSource);

        [HttpPost("save")]
        [AllowAnonymous]
        public virtual Task<ItemResult<BookDtoGen>> Save(
            [FromForm] BookDtoGen dto,
            [FromQuery] DataSourceParameters parameters,
            IDataSource<Demo.Data.Models.Book> dataSource,
            IBehaviors<Demo.Data.Models.Book> behaviors)
            => SaveImplementation(dto, parameters, dataSource, behaviors);

        [HttpPost("bulkSave")]
        [AllowAnonymous]
        public virtual Task<ItemResult<BookDtoGen>> BulkSave(
            [FromBody] BulkSaveRequest dto,
            [FromQuery] DataSourceParameters parameters,
            [FromServices] IDataSourceFactory dataSourceFactory,
            [FromServices] IBehaviorsFactory behaviorsFactory)
            => BulkSaveImplementation(dto, parameters, dataSourceFactory, behaviorsFactory);
    }
}
