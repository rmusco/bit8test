[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(JsonDataWEB.MVCGridConfig), "RegisterGrids")]

namespace JsonDataWEB
{
    using System;
    using System.Web;
    using System.Web.Mvc;
    using System.Linq;
    using System.Collections.Generic;

    using MVCGrid.Models;
    using MVCGrid.Web;
    using JsonDataWEB.Models;
    using JsonDataService.Models;
    using JsonDataService.Interfaces;

    public static class MVCGridConfig
    {
        public static void RegisterGrids()
        {
            MVCGridDefinitionTable.Add("PersonListGrid", new MVCGridBuilder<PersonModel>()
                .WithAuthorizationType(AuthorizationType.AllowAnonymous)
                .WithSorting(sorting: false)
                .WithPaging(paging: true, itemsPerPage: 10, allowChangePageSize: true, maxItemsPerPage: 100)
                .AddColumns(cols =>
                    {
                        cols.Add("Id").WithValueExpression((p, c) => c.UrlHelper.Action("PersonDetail", "Home", new { id = p.Id }))
                            .WithValueTemplate("<a href='{Value}'>{Model.Id}</a>", false)
                            .WithPlainTextValueExpression(p => p.Id.ToString());
                        cols.Add("Name").WithHeaderText("Name")
                            .WithVisibility(true, true)
                            .WithValueExpression(p => p.Name);
                        cols.Add("Age").WithHeaderText("Age")
                            .WithVisibility(true, true)
                            .WithValueExpression(p => p.Age.ToString());
                        cols.Add("Gender").WithValueExpression((p, c) => p.Gender)
                            .WithAllowChangeVisibility(true);
                        cols.Add("Email")
                            .WithVisibility(visible: false, allowChangeVisibility: true)
                            .WithValueExpression(p => p.Email);
                        cols.Add("Url").WithVisibility(false)
                            .WithValueExpression((p, c) => c.UrlHelper.Action("detail", "demo", new { id = p.Id }));
                    })
                    //.WithAdditionalSetting(MVCGrid.Rendering.BootstrapRenderingEngine.SettingNameTableClass, "notreal") // Example of changing table css class
                    .WithRetrieveDataMethod((context) =>
                    {
                        var options = context.QueryOptions;
                        int totalRecords;
                        var repo = DependencyResolver.Current.GetService<IPersonService>();
                        string globalSearch = options.GetAdditionalQueryOptionString("search");
                        string sortColumn = options.GetSortColumnData<string>();

                        var items = repo.GetAll(options.GetLimitOffset() ?? 1, options.GetLimitRowcount() ?? 10, out totalRecords);
                        return new QueryResult<PersonModel>()
                        {
                            Items = items,
                            TotalRecords = totalRecords
                        };
                    })
            );
        }
    }
}