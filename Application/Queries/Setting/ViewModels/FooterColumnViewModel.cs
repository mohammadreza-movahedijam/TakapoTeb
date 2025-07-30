using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Queries.Setting.ViewModels;

public sealed record FooterColumnViewModel
{
    #region ColumnOne

    public string? ColumnOneTitleFa { get; set; }
    public string? ColumnOneTitleEn { get; set; }


    public string? ColumnOneItemOneTitleEn { get; set; }
    public string? ColumnOneItemOneTitleFa { get; set; }
    public string? ColumnOneItemOneLink { get; set; }

    public string? ColumnOneItemTwoTitleEn { get; set; }
    public string? ColumnOneItemTwoTitleFa { get; set; }
    public string? ColumnOneItemTwoLink { get; set; }


    public string? ColumnOneItemThreeTitleEn { get; set; }
    public string? ColumnOneItemThreeTitleFa { get; set; }
    public string? ColumnOneItemThreeLink { get; set; }


    public string? ColumnOneItemFourTitleEn { get; set; }
    public string? ColumnOneItemFourTitleFa { get; set; }
    public string? ColumnOneItemFourLink { get; set; }


    #endregion

    #region ColumnTwo

    public string? ColumnTwoTitleFa { get; set; }
    public string? ColumnTwoTitleEn { get; set; }


    public string? ColumnTwoItemOneTitleEn { get; set; }
    public string? ColumnTwoItemOneTitleFa { get; set; }
    public string? ColumnTwoItemOneLink { get; set; }


    public string? ColumnTwoItemTwoTitleEn { get; set; }
    public string? ColumnTwoItemTwoTitleFa { get; set; }
    public string? ColumnTwoItemTwoLink { get; set; }


    public string? ColumnTwoItemThreeTitleEn { get; set; }
    public string? ColumnTwoItemThreeTitleFa { get; set; }
    public string? ColumnTwoItemThreeLink { get; set; }


    public string? ColumnTwoItemFourTitleEn { get; set; }
    public string? ColumnTwoItemFourTitleFa { get; set; }
    public string? ColumnTwoItemFourLink { get; set; }
    #endregion
}
