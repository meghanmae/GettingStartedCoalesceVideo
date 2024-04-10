
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
    [Route("api/Author")]
    [Authorize]
    [ServiceFilter(typeof(IApiActionFilter))]
    public partial class AuthorController
        : BaseApiController<Demo.Data.Models.Author, AuthorDtoGen, Demo.Data.AppDbContext>
    {
        public AuthorController(CrudContext<Demo.Data.AppDbContext> context) : base(context)
        {
            GeneratedForClassViewModel = context.ReflectionRepository.GetClassViewModel<Demo.Data.Models.Author>();
        }

        [HttpGet("get/{id}")]
        [Authorize]
        public virtual Task<ItemResult<AuthorDtoGen>> Get(
            int id,
            DataSourceParameters parameters,
            IDataSource<Demo.Data.Models.Author> dataSource)
            => GetImplementation(id, parameters, dataSource);

        [HttpGet("list")]
        [Authorize]
        public virtual Task<ListResult<AuthorDtoGen>> List(
            ListParameters parameters,
            IDataSource<Demo.Data.Models.Author> dataSource)
            => ListImplementation(parameters, dataSource);

        [HttpGet("count")]
        [Authorize]
        public virtual Task<ItemResult<int>> Count(
            FilterParameters parameters,
            IDataSource<Demo.Data.Models.Author> dataSource)
            => CountImplementation(parameters, dataSource);

        [HttpPost("save")]
        [Authorize]
        public virtual Task<ItemResult<AuthorDtoGen>> Save(
            [FromForm] AuthorDtoGen dto,
            [FromQuery] DataSourceParameters parameters,
            IDataSource<Demo.Data.Models.Author> dataSource,
            IBehaviors<Demo.Data.Models.Author> behaviors)
            => SaveImplementation(dto, parameters, dataSource, behaviors);

        [HttpPost("bulkSave")]
        [Authorize]
        public virtual Task<ItemResult<AuthorDtoGen>> BulkSave(
            [FromBody] BulkSaveRequest dto,
            [FromQuery] DataSourceParameters parameters,
            [FromServices] IDataSourceFactory dataSourceFactory,
            [FromServices] IBehaviorsFactory behaviorsFactory)
            => BulkSaveImplementation(dto, parameters, dataSourceFactory, behaviorsFactory);

        [HttpPost("delete/{id}")]
        [Authorize]
        public virtual Task<ItemResult<AuthorDtoGen>> Delete(
            int id,
            IBehaviors<Demo.Data.Models.Author> behaviors,
            IDataSource<Demo.Data.Models.Author> dataSource)
            => DeleteImplementation(id, new DataSourceParameters(), dataSource, behaviors);
    }
}
