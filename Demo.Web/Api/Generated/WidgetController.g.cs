
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
    [Route("api/Widget")]
    [Authorize]
    [ServiceFilter(typeof(IApiActionFilter))]
    public partial class WidgetController
        : BaseApiController<Demo.Data.Models.Widget, WidgetDtoGen, Demo.Data.AppDbContext>
    {
        public WidgetController(CrudContext<Demo.Data.AppDbContext> context) : base(context)
        {
            GeneratedForClassViewModel = context.ReflectionRepository.GetClassViewModel<Demo.Data.Models.Widget>();
        }

        [HttpGet("get/{id}")]
        [Authorize]
        public virtual Task<ItemResult<WidgetDtoGen>> Get(
            int id,
            DataSourceParameters parameters,
            IDataSource<Demo.Data.Models.Widget> dataSource)
            => GetImplementation(id, parameters, dataSource);

        [HttpGet("list")]
        [Authorize]
        public virtual Task<ListResult<WidgetDtoGen>> List(
            ListParameters parameters,
            IDataSource<Demo.Data.Models.Widget> dataSource)
            => ListImplementation(parameters, dataSource);

        [HttpGet("count")]
        [Authorize]
        public virtual Task<ItemResult<int>> Count(
            FilterParameters parameters,
            IDataSource<Demo.Data.Models.Widget> dataSource)
            => CountImplementation(parameters, dataSource);

        [HttpPost("save")]
        [Authorize]
        public virtual Task<ItemResult<WidgetDtoGen>> Save(
            [FromForm] WidgetDtoGen dto,
            [FromQuery] DataSourceParameters parameters,
            IDataSource<Demo.Data.Models.Widget> dataSource,
            IBehaviors<Demo.Data.Models.Widget> behaviors)
            => SaveImplementation(dto, parameters, dataSource, behaviors);

        [HttpPost("bulkSave")]
        [Authorize]
        public virtual Task<ItemResult<WidgetDtoGen>> BulkSave(
            [FromBody] BulkSaveRequest dto,
            [FromQuery] DataSourceParameters parameters,
            [FromServices] IDataSourceFactory dataSourceFactory,
            [FromServices] IBehaviorsFactory behaviorsFactory)
            => BulkSaveImplementation(dto, parameters, dataSourceFactory, behaviorsFactory);

        [HttpPost("delete/{id}")]
        [Authorize]
        public virtual Task<ItemResult<WidgetDtoGen>> Delete(
            int id,
            IBehaviors<Demo.Data.Models.Widget> behaviors,
            IDataSource<Demo.Data.Models.Widget> dataSource)
            => DeleteImplementation(id, new DataSourceParameters(), dataSource, behaviors);
    }
}
